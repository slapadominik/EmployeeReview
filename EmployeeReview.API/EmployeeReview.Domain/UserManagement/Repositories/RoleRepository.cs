using System.Collections.Generic;
using System.Linq;
using EmployeeReview.Domain.Common.Persistence;
using EmployeeReview.Domain.Common.Persistence.DAO;
using EmployeeReview.Domain.UserManagement.Repositories.Interfaces;

namespace EmployeeReview.Domain.UserManagement.Repositories
{
    public class RoleRepository : IRoleRepository
    {
        private ApplicationDbContext _applicationDbContext;

        public RoleRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public IEnumerable<RoleDAO> GetManyByNames(IEnumerable<string> name)
        {
            return _applicationDbContext.Roles.Where(x => name.Contains(x.Name));
        }
    }
}