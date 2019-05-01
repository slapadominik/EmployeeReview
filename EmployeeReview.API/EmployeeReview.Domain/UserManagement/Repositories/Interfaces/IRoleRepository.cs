using System.Collections.Generic;
using EmployeeReview.Domain.Common.Persistence.DAO;

namespace EmployeeReview.Domain.UserManagement.Repositories.Interfaces
{
    public interface IRoleRepository
    {
        IEnumerable<RoleDAO> GetManyByNames(IEnumerable<string> name);
        IEnumerable<RoleDAO> Get();
    }
}