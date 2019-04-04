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

        public UserManagementService(IEmployeeConverter employeeConverter, IUserRepository userRepository, IPrincipalHelper principalHelper)
        {
            _employeeConverter = employeeConverter;
            _userRepository = userRepository;
            _principalHelper = principalHelper;
        }

        public IEnumerable<UserDetails> GetAll()
        {
            if (!_principalHelper.Principal.IsInRole("Administrator"))
            {
                throw new UnauthorizedOperationException();
            }
            var usersDAO = _userRepository.GetAllUsersDetails().ToList();
            var userDetails = usersDAO.ConvertAll(x => _employeeConverter.Convert(x));
            return userDetails;
        }

        public UserDetails GetDetailsAboutMe(Guid userId)
        {
            var loggedUser = _principalHelper.Principal.Claims.SingleOrDefault(x => x.Type == "jti");
            if (Guid.Parse(loggedUser.Value) != userId)
            {
                throw new UnauthorizedOperationException();
            }
            var userDao = _userRepository.GetUserDetailById(userId);
            return _employeeConverter.Convert(userDao);
        }

    }
}