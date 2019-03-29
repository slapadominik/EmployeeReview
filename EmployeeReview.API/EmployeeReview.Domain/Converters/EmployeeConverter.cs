using System.Linq;
using AutoMapper;
using EmployeeReview.Domain.Converters.Interfaces;
using EmployeeReview.Domain.Entities;
using EmployeeReview.Infrastructure.DAO;

namespace EmployeeReview.Domain.Converters
{
    public class EmployeeConverter : IEmployeeConverter
    {
        private readonly IMapper _mapper;

        public EmployeeConverter(IMapper mapper)
        {
            _mapper = mapper;
        }

        public Employee Convert(UserDAO user)
        {
            Employee result = new Employee();
            result.FirstName = user.FirstName;
            result.LastName = user.LastName;
            result.Roles = user.UserRole.ConvertAll(x => _mapper.Map<Role>(x.Role));
            return result;
        }
    }
}