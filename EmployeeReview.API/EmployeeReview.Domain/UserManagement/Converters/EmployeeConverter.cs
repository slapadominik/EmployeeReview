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

        public EmployeeConverter(IMapper mapper)
        {
            _mapper = mapper;
        }

        public UserDetails Convert(UserDAO user)
        {
            UserDetails result = new UserDetails();
            result.Id = user.Id;
            result.FirstName = user.FirstName;
            result.LastName = user.LastName;
            result.Roles = user.UserRole.ConvertAll(x => _mapper.Map<Role>(x.Role));
            return result;
        }
    }
}