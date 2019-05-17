using System.Collections.Generic;
using EmployeeReview.Domain.Teams.DTO;

namespace EmployeeReview.Domain.Teams.Services.Interfaces
{
    public interface ITeamsService
    {
        IEnumerable<Team> Get();
    }
}