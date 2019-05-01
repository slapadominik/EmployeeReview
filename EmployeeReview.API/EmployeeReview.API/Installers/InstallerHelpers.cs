using EmployeeReview.Domain.Common.Security;
using EmployeeReview.Domain.Security.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace EmployeeReview.API.Installers
{
    public static class InstallerHelpers
    {
        public static void InstallHelpers(this IServiceCollection services)
        {
            services.AddScoped<ISecurityHelper, SecurityHelper>();
            services.AddScoped<IPrincipalHelper>(provider =>
            {
                var context = provider.GetService<IHttpContextAccessor>();
                return new PrincipalHelper { Principal = context.HttpContext.User };
            });
        }
    }
}