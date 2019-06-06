using System.Collections.Generic;
using EmployeeReview.Domain.UserManagement.DTO;
using Team = EmployeeReview.Domain.Teams.DTO.Team;

namespace EmployeeReview.Domain.Teams.Services.Interfaces
{
    public interface ITeamsService
    {
        IEnumerable<Team> Get();
        IEnumerable<UserDetails> GetUsersDetailedByTeamId(int teamId);
    }
}