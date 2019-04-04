using EmployeeReview.Domain.Security.DTO;

namespace EmployeeReview.Domain.Security.Services.Interfaces
{
    public interface ISecurityService
    {
        void Register(Account account);
        string Login(string username, string password);
    }
}