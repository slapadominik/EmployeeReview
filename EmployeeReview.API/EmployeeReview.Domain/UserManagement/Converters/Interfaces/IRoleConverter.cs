using EmployeeReview.Domain.Common.Persistence.DAO;
using EmployeeReview.Domain.Security.DTO;
using EmployeeReview.Domain.UserManagement.DTO;

namespace EmployeeReview.Domain.UserManagement.Converters.Interfaces
{
    public interface IRoleConverter
    {
        Role Convert(RoleDAO userDAO);
    }
}