using EmployeeReview.Domain.UserManagement.Converters;
using EmployeeReview.Domain.UserManagement.Converters.Interfaces;
using EmployeeReview.Domain.UserManagement.Repositories;
using EmployeeReview.Domain.UserManagement.Repositories.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace EmployeeReview.API.Installers
{
    public static class InstallerConverters
    {
        public static void InstallConverters(this IServiceCollection services)
        {
            services.AddScoped<IRoleConverter, RoleConverter>();
            services.AddScoped<IEmployeeConverter, EmployeeConverter>();
            services.AddScoped<IUserRoleDaoConverter, UserRoleDaoConverter>();
        }
    }
}