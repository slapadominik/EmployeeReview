using EmployeeReview.Domain.Entities;
using EmployeeReview.Infrastructure.DAO;

namespace EmployeeReview.Domain.Converters.Interfaces
{
    public interface IEmployeeConverter
    {
        Employee Convert(UserDAO user);
    }
}