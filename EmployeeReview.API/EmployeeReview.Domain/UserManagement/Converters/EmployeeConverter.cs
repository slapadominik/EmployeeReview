using AutoMapper;
using EmployeeReview.Domain.UserManagement.Converters.Interfaces;
using EmployeeReview.Domain.UserManagement.DTO;
using UserDAO = EmployeeReview.Domain.Common.Persistence.DAO.UserDAO;

namespace EmployeeReview.Domain.UserManagement.Converters
{
    public class EmployeeConverter : IEmployeeConverter
    {
        private readonly IMapper _mapper;
        private readonly IRoleConverter _roleConverter;

        public EmployeeConverter(IRoleConverter roleConverter)
        {
            _roleConverter = roleConverter;
            var mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<UserDAO, UserDetails>()
                    .ForMember(x => x.Roles, opt => opt.Ignore())
                    .ForMember(x => x.Supervisor, opt => opt.Ignore());
            });
            _mapper = mapperConfig.CreateMapper();
        }

        public UserDetails Convert(UserDAO user)
        {
            UserDetails result = _mapper.Map<UserDetails>(user);
            if (user.UserRole != null)
            {
                result.Roles = user.UserRole.ConvertAll(x => _roleConverter.Convert(x.Role));
            }
            if (user.Title != null)
            {
                result.JobTitle = new JobTitle {Id = user.Title.Id, Name = user.Title.Name};
            }
            if (user.Supervisor != null)
            {
                result.Supervisor = new UserBrief
                {
                    UserId = user.Supervisor.Id, FirstName = user.Supervisor.FirstName,
                    LastName = user.Supervisor.LastName
                };
            }
            return result;
        }
    }
}