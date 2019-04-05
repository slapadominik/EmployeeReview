using EmployeeReview.Domain.Security.DTO;

namespace EmployeeReview.Domain.Security.Helpers
{
    public interface ISecurityHelper
    {
        string CreateToken(Account account);
        (byte[] passwordHash, byte[] salt) HashPassword(string password);
        byte[] HashPassword(string password, byte[] salt);
        bool IsPasswordHashEqual(byte[] passwordHash1, byte[] passwordHash2);
    }
}