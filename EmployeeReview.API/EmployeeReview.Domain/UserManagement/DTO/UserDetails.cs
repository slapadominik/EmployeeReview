using System;
using System.Collections.Generic;
using EmployeeReview.Domain.Security.DTO;

namespace EmployeeReview.Domain.UserManagement.DTO
{
    public class UserDetails
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public ICollection<Role> Roles { get; set; }

        public UserDetails()
        {
            Roles = new List<Role>();
        }
    }
}