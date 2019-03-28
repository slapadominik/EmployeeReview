using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using AutoMapper;
using EmployeeReview.Domain.Entities;
using EmployeeReview.Domain.Exceptions;
using EmployeeReview.Domain.Helpers;
using EmployeeReview.Domain.Services.Interfaces;
using EmployeeReview.Infrastructure.DAO;
using EmployeeReview.Infrastructure.DbContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace EmployeeReview.Domain.Services
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

        public void Register(User user)
        {
            var existingUser =  _dbContext.Users.SingleOrDefault(x => x.Email == user.Email);
            
            if (existingUser != null)
            {
                throw new EmailAlreadyExistsException($"User with this e-mail already exists.");
            }
            var userDAO = _mapper.Map<User, UserDAO>(user);
            var (passwordHash, passwordSalt) = _securityTokenHelper.HashPassword(user.Password);
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

            var user = _mapper.Map<User>(userDAO);
            user.Roles = userDAO.UserRole.ConvertAll(x => _mapper.Map<Role>(x.Role));
            return _securityTokenHelper.CreateToken(user);
        }
    }
}