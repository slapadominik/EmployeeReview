using EmployeeReview.Domain.UserManagement.DTO;
using UserDAO = EmployeeReview.Domain.Common.Persistence.DAO.UserDAO;

namespace EmployeeReview.Domain.UserManagement.Converters.Interfaces
{
    public interface IEmployeeConverter
    {
        UserDetails Convert(UserDAO user);
    }
}