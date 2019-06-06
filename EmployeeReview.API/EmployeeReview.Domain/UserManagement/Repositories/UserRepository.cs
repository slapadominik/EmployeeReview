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

        public IEnumerable<UserDAO> GetByRole(int roleId)
        {
            return _dbContext.Users.Include(x => x.UserRole).Include(x => x.Title).Where(x => x.UserRole.Any(y => y.UserId == x.Id && y.RoleId == roleId));
        }

        public IEnumerable<UserDAO> GetBySupervisorId(Guid supervisorId)
        {
            return _dbContext.Users.Include(x => x.Supervisor).Include(x => x.Title).Include(x => x.UserRole)
                .ThenInclude(x => x.Role).Where(x => x.SupervisorId == supervisorId);
        }

        public UserDAO GetUserWithRolesById(Guid userId)
        {
            return _dbContext.Users.Include(x => x.UserRole).ThenInclude(x => x.Role).SingleOrDefault(x => x.Id == userId);
        }

        public UserDAO GetUserDetailById(Guid userId)
        {
            return _dbContext.Users.Include(x => x.Title).Include(x => x.Team).Include(x => x.Supervisor).Include(x => x.UserRole).ThenInclude(x => x.Role).SingleOrDefault(x => x.Id == userId);            
        }

        public UserDAO GetBrief(Guid userId)
        {
            return _dbContext.Users.SingleOrDefault(x => x.Id == userId);
        }

        public int SaveChanges()
        {
            return _dbContext.SaveChanges();
        }
    }
}