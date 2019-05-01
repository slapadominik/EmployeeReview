using EmployeeReview.Domain.Common.Security;
using EmployeeReview.Domain.Security.Helpers;
using EmployeeReview.Domain.UserManagement.Repositories;
using EmployeeReview.Domain.UserManagement.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace EmployeeReview.API.Installers
{
    public static class InstallerRepositories
    {
        public static void InstallRepositories(this IServiceCollection services)
        {
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IRoleRepository, RoleRepository>();
        }
    }
}