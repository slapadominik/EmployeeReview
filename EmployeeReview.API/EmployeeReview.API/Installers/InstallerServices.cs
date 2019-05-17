using EmployeeReview.Domain.Reviews.Services;
using EmployeeReview.Domain.Reviews.Services.Interfaces;
using EmployeeReview.Domain.Security.Services;
using EmployeeReview.Domain.Security.Services.Interfaces;
using EmployeeReview.Domain.Teams.Services;
using EmployeeReview.Domain.Teams.Services.Interfaces;
using EmployeeReview.Domain.UserManagement.Services;
using EmployeeReview.Domain.UserManagement.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace EmployeeReview.API.Installers
{
    public static class InstallerServices
    {
        public static void InstallServices(this IServiceCollection services)
        {
            services.AddScoped<ISecurityService, SecurityService>();
            services.AddScoped<IUserManagementService, UserManagementService>();
            services.AddScoped<IRolesService, RolesService>();
            services.AddScoped<IReviewsService, ReviewsService>();
            services.AddScoped<ITeamsService, TeamsService>();
        }
    }
}