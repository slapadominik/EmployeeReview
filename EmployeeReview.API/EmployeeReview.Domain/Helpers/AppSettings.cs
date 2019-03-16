using Microsoft.Extensions.Options;

namespace EmployeeReview.Domain.Helpers
{
    public class AppSettings
    {
        public string JwtSecret { get; set; }
    }
}