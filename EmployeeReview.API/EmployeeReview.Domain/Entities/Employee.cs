using System.Collections.Generic;

namespace EmployeeReview.Domain.Entities
{
    public class Employee
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public ICollection<Role> Roles { get; set; }

        public Employee()
        {
            Roles = new List<Role>();
        }
    }
}