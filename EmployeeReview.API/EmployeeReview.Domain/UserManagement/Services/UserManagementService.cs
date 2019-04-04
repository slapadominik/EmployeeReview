using System;
using System.Collections.Generic;
using System.Linq;
using EmployeeReview.Domain.UserManagement.Converters.Interfaces;
using EmployeeReview.Domain.UserManagement.DTO;
using EmployeeReview.Domain.UserManagement.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using ApplicationDbContext = EmployeeReview.Domain.Common.Persistence.ApplicationDbContext;

namespace EmployeeReview.Domain.UserManagement.Services
{
    public class UserManagementService: IUserManagementService
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IEmployeeConverter _employeeConverter;

        public UserManagementService(ApplicationDbContext dbContext, IEmployeeConverter employeeConverter)
        {
            _dbContext = dbContext;
            _employeeConverter = employeeConverter;
        }

        public IEnumerable<UserDetails> GetAll()
        {
            var usersDAO = _dbContext.Users.Include(x => x.UserRole).ThenInclude(x => x.Role).ToList();
            var userDetails = usersDAO.ConvertAll(x => _employeeConverter.Convert(x));
            return userDetails;
        }

        public UserDetails GetDetailsAboutMe(Guid userId)
        {
            var userDao = _dbContext.Users.Include(x => x.UserRole).ThenInclude(x => x.Role).Single(x => x.Id == userId);

            return _employeeConverter.Convert(userDao);
        }

    }
}