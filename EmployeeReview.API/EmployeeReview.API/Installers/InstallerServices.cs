using EmployeeReview.Domain.Security.Services;
using EmployeeReview.Domain.Security.Services.Interfaces;
using EmployeeReview.Domain.UserManagement.Services;
using EmployeeReview.Domain.UserManagement.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace EmployeeReview.API.Installers
{
    public static class InstallerServices
    {
        public static void InstallServices(this IServiceCollection services)
        {
            services.AddTransient<ISecurityService, SecurityService>();
            services.AddTransient<IUserManagementService, UserManagementService>();
            services.AddTransient<IRolesService, RolesService>();
        }
    }
}