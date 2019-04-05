using System.Security.Claims;
using System.Security.Principal;

namespace EmployeeReview.Domain.Common.Security
{
    public class PrincipalHelper : IPrincipalHelper
    {
        public ClaimsPrincipal Principal { get; set; }
    }
}