using System;
using System.Collections.Generic;
using EmployeeReview.Domain.UserManagement.DTO;

namespace EmployeeReview.Domain.UserManagement.Services.Interfaces
{
    public interface IUserManagementService
    {
        IEnumerable<UserDetails> GetAll();
        UserDetails GetDetailsAboutMe(Guid userId);
    }
}