using EmployeeReview.API.Features.JobTitles.Converters;
using EmployeeReview.API.Features.JobTitles.Converters.Interfaces;
using EmployeeReview.Domain.Reviews.Converters;
using EmployeeReview.Domain.Reviews.Converters.Interfaces;
using EmployeeReview.Domain.Teams.Converters;
using EmployeeReview.Domain.Teams.Converters.Interfaces;
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
            services.AddScoped<IReviewConverter, ReviewConverter>();
            services.AddScoped<IJobTitleConverter, JobTitleConverter>();
            services.AddScoped<IReviewAuthorConverter, ReviewAuthorConverter>();
            services.AddScoped<ITeamConverter, TeamConverter>();
        }
    }
}