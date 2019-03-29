using EmployeeReview.Domain.Entities;
using Microsoft.IdentityModel.Tokens;

namespace EmployeeReview.Domain.Services.Interfaces
{
    public interface ISecurityService
    {
        void Register(User user);
        string Login(string username, string password);
    }
}