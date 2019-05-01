using System;
using System.Collections.Generic;

namespace EmployeeReview.Domain.Security.DTO
{
    public class Account
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public char Sex { get; set; }
        public int TitleId { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public ICollection<Role> Roles { get; set; }

        public Account()
        {
            Roles = new List<Role>();
        }
    }
}