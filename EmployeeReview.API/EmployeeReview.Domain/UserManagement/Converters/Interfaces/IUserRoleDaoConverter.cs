using System;
using EmployeeReview.Domain.Common.Persistence.DAO;

namespace EmployeeReview.Domain.UserManagement.Converters.Interfaces
{
    public interface IUserRoleDaoConverter
    {
        UserRoleDAO Convert(Guid userId, RoleDAO role);
    }
}