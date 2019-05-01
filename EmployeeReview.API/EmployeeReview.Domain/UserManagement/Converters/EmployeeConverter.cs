using AutoMapper;
using EmployeeReview.Domain.Security.DTO;
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
                    .ForMember(x => x.Roles, opt => opt.Ignore());
            });
            _mapper = mapperConfig.CreateMapper();
        }

        public UserDetails Convert(UserDAO user)
        {
            UserDetails result = _mapper.Map<UserDetails>(user);
            result.Roles = user.UserRole.ConvertAll(x => _roleConverter.Convert(x.Role));
            result.Title = user.Title.Name;
            return result;
        }
    }
}