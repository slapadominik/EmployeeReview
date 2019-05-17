using System.Collections.Generic;
using System.Linq;
using EmployeeReview.Domain.Teams.Converters.Interfaces;
using EmployeeReview.Domain.Teams.DTO;
using EmployeeReview.Domain.Teams.Repositories.Interfaces;
using EmployeeReview.Domain.Teams.Services.Interfaces;

namespace EmployeeReview.Domain.Teams.Services
{
    public class TeamsService : ITeamsService
    {
        private readonly ITeamsRepository _teamsRepository;
        private readonly ITeamConverter _teamConverter;

        public TeamsService(ITeamsRepository teamsRepository, ITeamConverter teamConverter)
        {
            _teamsRepository = teamsRepository;
            _teamConverter = teamConverter;
        }

        public IEnumerable<Team> Get()
        {
            return _teamsRepository.Get().Select(x => _teamConverter.Convert(x));
        }
    }
}