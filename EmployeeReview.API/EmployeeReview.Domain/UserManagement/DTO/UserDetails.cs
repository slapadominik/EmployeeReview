using System;
using System.Collections.Generic;

namespace EmployeeReview.Domain.UserManagement.DTO
{
    public class UserDetails
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public char Sex { get; set; }
        public JobTitle JobTitle { get; set; }
        public ICollection<Role> Roles { get; set; }
        public UserBrief Supervisor { get; set; }
        public Team Team { get; set; }

        public UserDetails()
        {
            Roles = new List<Role>();
        }
    }
}