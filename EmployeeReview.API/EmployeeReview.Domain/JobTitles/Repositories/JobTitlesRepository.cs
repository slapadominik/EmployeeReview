using System.Collections.Generic;
using System.Linq;
using EmployeeReview.Domain.Common.Persistence;
using EmployeeReview.Domain.Common.Persistence.DAO;
using EmployeeReview.Domain.JobTitles.Repositories.Interfaces;

namespace EmployeeReview.Domain.JobTitles.Repositories
{
    public class JobTitlesRepository : IJobTitlesRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public JobTitlesRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<JobTitleDAO> Get()
        {
            return _dbContext.JobTitles.ToList();
        }
    }
}