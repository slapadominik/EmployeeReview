using System;
using System.Collections.Generic;
using System.Linq;
using EmployeeReview.Domain.Common.Persistence;
using EmployeeReview.Domain.Common.Persistence.DAO;
using EmployeeReview.Domain.UserManagement.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EmployeeReview.Domain.UserManagement.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public UserRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<UserDAO> GetAllUsersDetails()
        {
            return _dbContext.Users.Include(x => x.Title).Include(x => x.UserRole).ThenInclude(x => x.Role);
        }

        public UserDAO GetUserDetailById(Guid userId)
        {
            return _dbContext.Users.Include(x => x.UserRole).ThenInclude(x => x.Role).Single(x => x.Id == userId);            
        }

        public int SaveChanges()
        {
            return _dbContext.SaveChanges();
        }
    }
}