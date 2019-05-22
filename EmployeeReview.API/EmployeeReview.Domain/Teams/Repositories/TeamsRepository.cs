using System.Collections.Generic;
using System.Linq;
using EmployeeReview.Domain.Common.Persistence;
using EmployeeReview.Domain.Common.Persistence.DAO;
using EmployeeReview.Domain.Teams.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

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

        public TeamDAO GetById(int teamId)
        {
            return _dbContext.Teams.SingleOrDefault(x => x.Id == teamId);
        }

        public IEnumerable<UserDAO> GetUsersByTeamId(int teamId)
        {
            return _dbContext.Users.Include(x => x.Team).Include(x => x.Title).Where(x => x.TeamId == teamId);
        }
    }
}