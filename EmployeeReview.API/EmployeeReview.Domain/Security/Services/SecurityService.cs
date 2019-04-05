using System;
using System.Linq;
using AutoMapper;
using EmployeeReview.Domain.Common.Exceptions;
using EmployeeReview.Domain.Security.DTO;
using EmployeeReview.Domain.Security.Helpers;
using EmployeeReview.Domain.Security.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using ApplicationDbContext = EmployeeReview.Domain.Common.Persistence.ApplicationDbContext;
using UserDAO = EmployeeReview.Domain.Common.Persistence.DAO.UserDAO;
using UserRoleDAO = EmployeeReview.Domain.Common.Persistence.DAO.UserRoleDAO;

namespace EmployeeReview.Domain.Security.Services
{
    public class SecurityService : ISecurityService
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly ISecurityHelper _securityTokenHelper;
        private readonly IMapper _mapper;

        public SecurityService(ApplicationDbContext dbContext, ISecurityHelper securityTokenHelper, IMapper mapper)
        {
            _dbContext = dbContext;
            _securityTokenHelper = securityTokenHelper;
            _mapper = mapper;
        }

        public void Register(Account account)
        {
            var existingUser =  _dbContext.Users.SingleOrDefault(x => x.Email == account.Email);
            
            if (existingUser != null)
            {
                throw new EmailAlreadyExistsException($"User with this e-mail already exists.");
            }
            var userDAO = _mapper.Map<Account, UserDAO>(account);
            var (passwordHash, passwordSalt) = _securityTokenHelper.HashPassword(account.Password);
            var employeeRole = _dbContext.Roles.Single(x => x.Name == "Employee");

            userDAO.Id = Guid.NewGuid();
            userDAO.Password = passwordHash;
            userDAO.PasswordSalt = passwordSalt;
            userDAO.UserRole.Add(new UserRoleDAO{Role = employeeRole, RoleId = employeeRole.Id, User = userDAO, UserId = userDAO.Id});
            _dbContext.Users.Add(userDAO);
            if (_dbContext.SaveChanges() != 2)
            {
                throw new DatabaseException($"Something went wrong with database connection");
            }
        }

        public string Login(string email, string password)
        {
            var userDAO = _dbContext.Users.Include(x => x.UserRole).ThenInclude(x => x.Role).SingleOrDefault(x => x.Email == email);
            if (userDAO == null)
            {
                throw new UserNotFoundException($"User with given e-mail doesn't exist.");
            }
            var passwordHash = _securityTokenHelper.HashPassword(password, userDAO.PasswordSalt);
            if (!_securityTokenHelper.IsPasswordHashEqual(passwordHash, userDAO.Password))
            {
                throw new WrongCredentialsException($"Invalid e-mail or password");
            }

            var user = _mapper.Map<Account>(userDAO);
            user.Roles = userDAO.UserRole.ConvertAll(x => _mapper.Map<Role>(x.Role));
            return _securityTokenHelper.CreateToken(user);
        }
    }
}