using EmployeeReview.Domain.Entities;

namespace EmployeeReview.Domain.Helpers
{
    public interface ISecurityHelper
    {
        string CreateToken(User user);
        (byte[] passwordHash, byte[] salt) HashPassword(string password);
    }
}