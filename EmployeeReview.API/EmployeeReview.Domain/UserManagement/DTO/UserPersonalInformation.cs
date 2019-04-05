using System;

namespace EmployeeReview.Domain.UserManagement.DTO
{
    public class UserPersonalInformation
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}