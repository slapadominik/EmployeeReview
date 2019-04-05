using System.Security.Claims;
using System.Security.Principal;

namespace EmployeeReview.Domain.Common.Security
{
    public interface IPrincipalHelper
    {
        ClaimsPrincipal Principal { get; }
    }
}