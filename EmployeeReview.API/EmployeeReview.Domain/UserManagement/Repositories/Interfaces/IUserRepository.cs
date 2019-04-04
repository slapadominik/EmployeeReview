using System;
using System.Collections.Generic;
using EmployeeReview.Domain.Common.Persistence.DAO;

namespace EmployeeReview.Domain.UserManagement.Repositories.Interfaces
{
    public interface IUserRepository
    {
        IEnumerable<UserDAO> GetAllUsersDetails();
        UserDAO GetUserDetailById(Guid userId);
    }
}