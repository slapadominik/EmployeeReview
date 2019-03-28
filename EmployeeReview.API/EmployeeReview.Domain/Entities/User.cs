using System;
using System.Collections.Generic;
using EmployeeReview.Infrastructure.Migrations;

namespace EmployeeReview.Domain.Entities
{
    public class User
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public User Superior { get; set; }
        public ICollection<Role> Roles { get; set; }

        public User()
        {
            Roles = new List<Role>();
        }
    }
}