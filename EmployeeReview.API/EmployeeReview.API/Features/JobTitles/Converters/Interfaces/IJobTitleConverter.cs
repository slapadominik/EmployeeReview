using EmployeeReview.API.Features.JobTitles.DTO;
using EmployeeReview.Domain.Common.Persistence.DAO;

namespace EmployeeReview.API.Features.JobTitles.Converters.Interfaces
{
    public interface IJobTitleConverter
    {
        JobTitle Convert(JobTitleDAO jobTitle);
    }
}