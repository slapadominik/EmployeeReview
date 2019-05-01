using AutoMapper;
using EmployeeReview.Domain.Common.Persistence.DAO;
using EmployeeReview.Domain.Security.DTO;
using EmployeeReview.Domain.UserManagement.Converters.Interfaces;
using EmployeeReview.Domain.UserManagement.DTO;

namespace EmployeeReview.Domain.UserManagement.Converters
{
    public class RoleConverter : IRoleConverter
    {
        private IMapper _mapper;

        public RoleConverter()
        {
            var mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Role, RoleDAO>();

            });
            _mapper = mapperConfig.CreateMapper();
        }
        public Role Convert(RoleDAO userDAO)
        {
            return _mapper.Map<Role>(userDAO);
        }
    }
}