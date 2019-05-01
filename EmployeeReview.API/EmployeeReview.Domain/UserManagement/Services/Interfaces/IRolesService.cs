using System.Collections.Generic;
using EmployeeReview.Domain.UserManagement.DTO;

namespace EmployeeReview.Domain.UserManagement.Services.Interfaces
{
    public interface IRolesService
    {
        IEnumerable<Role> GetAll();
    }
}