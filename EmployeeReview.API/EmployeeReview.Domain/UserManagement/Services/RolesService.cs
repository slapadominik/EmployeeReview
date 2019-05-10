using System.Collections.Generic;
using System.Linq;
using EmployeeReview.Domain.UserManagement.Converters.Interfaces;
using EmployeeReview.Domain.UserManagement.DTO;
using EmployeeReview.Domain.UserManagement.Repositories.Interfaces;
using EmployeeReview.Domain.UserManagement.Services.Interfaces;

namespace EmployeeReview.Domain.UserManagement.Services
{
    public class RolesService : IRolesService
    {
        private readonly IRoleRepository _roleRepository;
        private readonly IRoleConverter _roleConverter;

        public RolesService(IRoleRepository roleRepository, IRoleConverter roleConverter)
        {
            _roleRepository = roleRepository;
            _roleConverter = roleConverter;
        }

        public IEnumerable<Role> GetAll()
        {
            return _roleRepository.Get().ToList().ConvertAll(x => _roleConverter.Convert(x)).ToList();
        }
    }
}