using AutoMapper;
using EmployeeReview.Domain.Common.Persistence.DAO;
using EmployeeReview.Domain.Reviews.DTO;
using EmployeeReview.Domain.Teams.Converters.Interfaces;
using EmployeeReview.Domain.Teams.DTO;

namespace EmployeeReview.Domain.Teams.Converters
{
    public class TeamConverter : ITeamConverter
    {
        private readonly IMapper _mapper;

        public TeamConverter()
        {
            var mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<TeamDAO, Team>();                    
            });
            _mapper = mapperConfig.CreateMapper();
        }

        public Team Convert(TeamDAO team)
        {
            return _mapper.Map<Team>(team);
        }
    }
}