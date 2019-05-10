using EmployeeReview.Domain.Common.Security;
using EmployeeReview.Domain.JobTitles.Repositories;
using EmployeeReview.Domain.JobTitles.Repositories.Interfaces;
using EmployeeReview.Domain.Reviews.Repositories;
using EmployeeReview.Domain.Reviews.Repositories.Interfaces;
using EmployeeReview.Domain.UserManagement.Repositories;
using EmployeeReview.Domain.UserManagement.Repositories.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace EmployeeReview.API.Installers
{
    public static class InstallerRepositories
    {
        public static void InstallRepositories(this IServiceCollection services)
        {
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IRoleRepository, RoleRepository>();
            services.AddScoped<IReviewsRepository, ReviewsRepository>();
            services.AddScoped<IJobTitlesRepository, JobTitlesRepository>();
        }
    }
}