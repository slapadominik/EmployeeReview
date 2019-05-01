using EmployeeReview.Domain.Common.Persistence.DAO;
using Role = EmployeeReview.Domain.UserManagement.DTO.Role;

namespace EmployeeReview.Domain.UserManagement.Converters.Interfaces
{
    public interface IRoleConverter
    {
        Role Convert(RoleDAO userDAO);
    }
}