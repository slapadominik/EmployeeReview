using System;
using EmployeeReview.Domain.Common.Persistence.DAO;

namespace EmployeeReview.Domain.UserManagement.Converters.Interfaces
{
    public class UserRoleDaoConverter : IUserRoleDaoConverter
    {
        public UserRoleDAO Convert(Guid userId, RoleDAO role)
        {
            return new UserRoleDAO {UserId = userId, RoleId = role.Id};
        }
    }
}