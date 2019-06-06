using System.Collections.Generic;
using System.Linq;
using EmployeeReview.Domain.Common.Exceptions;
using EmployeeReview.Domain.Teams.Converters.Interfaces;
using EmployeeReview.Domain.Teams.Repositories.Interfaces;
using EmployeeReview.Domain.Teams.Services.Interfaces;
using EmployeeReview.Domain.UserManagement.Converters.Interfaces;
using EmployeeReview.Domain.UserManagement.DTO;
using Team = EmployeeReview.Domain.Teams.DTO.Team;

namespace EmployeeReview.Domain.Teams.Services
{
    public class TeamsService : ITeamsService
    {
        private readonly ITeamsRepository _teamsRepository;
        private readonly ITeamConverter _teamConverter;
        private readonly IUserDetailConverter _userDetailConverter;

        public TeamsService(ITeamsRepository teamsRepository, ITeamConverter teamConverter, IUserDetailConverter userDetailConverter)
        {
            _teamsRepository = teamsRepository;
            _teamConverter = teamConverter;
            _userDetailConverter = userDetailConverter;
        }

        public IEnumerable<Team> Get()
        {
            return _teamsRepository.Get().Select(x => _teamConverter.Convert(x));
        }

        public IEnumerable<UserDetails> GetUsersDetailedByTeamId(int teamId)
        {
            if (_teamsRepository.GetById(teamId) == null)
            {
                throw new EntityNotFoundException($"Team with Id {teamId} not found.");
            }
            return _teamsRepository.GetUsersByTeamId(teamId).ToList().ConvertAll(x => _userDetailConverter.Convert(x));
        }
    }
}