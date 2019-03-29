using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using EmployeeReview.Domain.Converters.Interfaces;
using EmployeeReview.Domain.Entities;
using EmployeeReview.Domain.Services.Interfaces;
using EmployeeReview.Infrastructure.DbContexts;
using Microsoft.EntityFrameworkCore;

namespace EmployeeReview.Domain.Services
{
    public class EmployeeService: IEmployeeService
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IEmployeeConverter _employeeConverter;

        public EmployeeService(ApplicationDbContext dbContext, IEmployeeConverter employeeConverter)
        {
            _dbContext = dbContext;
            _employeeConverter = employeeConverter;
        }

        public IEnumerable<Employee> GetAll()
        {
            var usersDAO = _dbContext.Users.Include(x => x.UserRole).ThenInclude(x => x.Role).ToList();
            var employees = usersDAO.ConvertAll(x => _employeeConverter.Convert(x));
            return employees;
        }

        public Employee GetDetailsAboutMe(Guid userId)
        {
            var userDao = _dbContext.Users.Include(x => x.UserRole).ThenInclude(x => x.Role).Single(x => x.Id == userId);

            return _employeeConverter.Convert(userDao);
        }

    }
}