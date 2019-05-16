using System;
using System.Collections.Generic;
using System.Linq;
using EmployeeReview.Domain.Common.Exceptions;
using EmployeeReview.Domain.Common.Security;
using EmployeeReview.Domain.UserManagement.Converters.Interfaces;
using EmployeeReview.Domain.UserManagement.DTO;
using EmployeeReview.Domain.UserManagement.Repositories.Interfaces;
using EmployeeReview.Domain.UserManagement.Services.Interfaces;


namespace EmployeeReview.Domain.UserManagement.Services
{
    public class UserManagementService: IUserManagementService
    {
        private readonly IEmployeeConverter _employeeConverter;
        private readonly IUserRepository _userRepository;
        private readonly IPrincipalHelper _principalHelper;
        private readonly IRoleRepository _roleRepository;
        private readonly IUserRoleDaoConverter _userRoleDaoConverter;

        public UserManagementService(IEmployeeConverter employeeConverter, IUserRepository userRepository, IPrincipalHelper principalHelper, IRoleRepository roleRepository, IUserRoleDaoConverter userRoleDaoConverter)
        {
            _employeeConverter = employeeConverter;
            _userRepository = userRepository;
            _principalHelper = principalHelper;
            _roleRepository = roleRepository;
            _userRoleDaoConverter = userRoleDaoConverter;
        }

        public IEnumerable<UserDetails> GetAll()
        {
            var usersDAO = _userRepository.GetAllUsersDetails().ToList();
            var userDetails = usersDAO.ConvertAll(x => _employeeConverter.Convert(x));
            return userDetails;
        }

        public IEnumerable<UserDetails> GetByRole(string roleName)
        {
            if (!_principalHelper.Principal.IsInRole("Administrator"))
            {
                throw new UnauthorizedOperationException($"User does not have permissions to do this operation.");
            }

            var role = _roleRepository.GetByName(roleName);
            if (role == null)
            {
                throw new EntityNotFoundException($"Role with name {roleName} not found");
            }
            var usersDAO = _userRepository.GetByRole(role.Id).ToList();
            var userDetails = usersDAO.ConvertAll(x => _employeeConverter.Convert(x));
            return userDetails;
        }

        public IEnumerable<UserDetails> GetBySupervisorId(Guid supervisorId)
        {
            if (!_principalHelper.Principal.IsInRole("Supervisor"))
            {
                throw new UnauthorizedOperationException($"User does not have permissions to do this operation.");
            }
            var usersDAO = _userRepository.GetBySupervisorId(supervisorId).ToList();
            var userDetails = usersDAO.ConvertAll(x => _employeeConverter.Convert(x));
            return userDetails;
        }

        public UserDetails GetDetailsAboutMe(Guid userId)
        {
            var loggedUserId = _principalHelper.Principal.Claims.SingleOrDefault(x => x.Type == "jti");
            var userDao = _userRepository.GetUserDetailById(userId);
            return _employeeConverter.Convert(userDao);
        }

        public void UpdateUsersJobInformation(UserJobInformation jobInformation)
        {
            var loggedUserId = _principalHelper.Principal.Claims.SingleOrDefault(x => x.Type == "jti");
            if (Guid.Parse(loggedUserId.Value) != jobInformation.UserId && !_principalHelper.Principal.IsInRole("Administrator"))
            {
                throw new UnauthorizedOperationException();
            }

            var user = _userRepository.GetUserDetailById(jobInformation.UserId);
            if (user == null)
            {
                throw new UserNotFoundException($"User with id {jobInformation.UserId} not found");
            }

            if (_userRepository.GetBrief(jobInformation.SupervisorId) == null)
            {
                throw new UserNotFoundException($"Supervisor with id {jobInformation.UserId} not found");
            }
            user.SupervisorId = jobInformation.SupervisorId;
            user.TitleId = jobInformation.JobTitle;
            _userRepository.SaveChanges();
        }

        public void EditUserRoles(Guid userId, IEnumerable<Role> roles)
        {
            _userRepository.GetUserDetailById(userId);
            var user = _userRepository.GetUserWithRolesById(userId);
            
            if (user == null)
            {
                throw new UserNotFoundException("User doesn't exist.");
            }

            var rolesDao = _roleRepository.GetByNames(roles.Select(x => x.Name)).ToList();
            user.UserRole = rolesDao.ConvertAll(x => _userRoleDaoConverter.Convert(userId, x));
            _userRepository.SaveChanges();
        }
    }
}