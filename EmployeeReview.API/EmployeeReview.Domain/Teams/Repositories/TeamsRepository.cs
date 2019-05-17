using System.Collections.Generic;
using System.Linq;
using EmployeeReview.Domain.Common.Persistence;
using EmployeeReview.Domain.Common.Persistence.DAO;
using EmployeeReview.Domain.Teams.Repositories.Interfaces;

namespace EmployeeReview.Domain.Teams.Repositories
{
    public class TeamsRepository : ITeamsRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public TeamsRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IEnumerable<TeamDAO> Get()
        {
            return _dbContext.Teams.ToList();
        }
    }
}