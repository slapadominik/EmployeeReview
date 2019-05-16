using System.Collections.Generic;
using EmployeeReview.Domain.Common.Persistence.DAO;

namespace EmployeeReview.Domain.UserManagement.Repositories.Interfaces
{
    public interface IRoleRepository
    {
        IEnumerable<RoleDAO> GetByNames(IEnumerable<string> name);
        IEnumerable<RoleDAO> Get();
        RoleDAO GetByName(string role);
    }
}