using EmployeeReview.Domain.Common.Persistence.DAO;
using EmployeeReview.Domain.Teams.DTO;

namespace EmployeeReview.Domain.Teams.Converters.Interfaces
{
    public interface ITeamConverter
    {
        Team Convert(TeamDAO team);
    }
}