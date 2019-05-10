using System.Collections.Generic;
using EmployeeReview.Domain.Common.Persistence.DAO;

namespace EmployeeReview.Domain.JobTitles.Repositories.Interfaces
{
    public interface IJobTitlesRepository
    {
        IEnumerable<JobTitleDAO> Get();
    }
}