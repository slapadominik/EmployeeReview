using EmployeeReview.Domain.UserManagement.DTO;
using EmployeeReview.Infrastructure.DAO;

namespace EmployeeReview.Domain.UserManagement.Converters.Interfaces
{
    public interface IEmployeeConverter
    {
        UserDetails Convert(UserDAO user);
    }
}