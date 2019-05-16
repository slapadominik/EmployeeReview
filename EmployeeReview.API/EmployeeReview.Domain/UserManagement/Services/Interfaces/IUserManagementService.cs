using System;
using System.Collections.Generic;
using EmployeeReview.Domain.UserManagement.DTO;

namespace EmployeeReview.Domain.UserManagement.Services.Interfaces
{
    public interface IUserManagementService
    {
        IEnumerable<UserDetails> GetAll();
        IEnumerable<UserDetails> GetByRole(string role);
        IEnumerable<UserDetails> GetBySupervisorId(Guid supervisorId);
        UserDetails GetDetailsAboutMe(Guid userId);
        void UpdateUsersJobInformation(UserJobInformation user);
        void EditUserRoles(Guid userId, IEnumerable<Role> roles);
    }
}