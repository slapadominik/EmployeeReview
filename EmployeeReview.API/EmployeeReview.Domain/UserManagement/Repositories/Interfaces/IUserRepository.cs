using System;
using System.Collections.Generic;
using EmployeeReview.Domain.Common.Persistence.DAO;

namespace EmployeeReview.Domain.UserManagement.Repositories.Interfaces
{
    public interface IUserRepository
    {
        IEnumerable<UserDAO> GetAllUsersDetails();
        IEnumerable<UserDAO> GetByRole(int roleId);
        IEnumerable<UserDAO> GetBySupervisorId(Guid supervisorId);
        UserDAO GetUserWithRolesById(Guid userId);
        UserDAO GetUserDetailById(Guid userId);
        UserDAO GetBrief(Guid userId);
        int SaveChanges();
    }
}