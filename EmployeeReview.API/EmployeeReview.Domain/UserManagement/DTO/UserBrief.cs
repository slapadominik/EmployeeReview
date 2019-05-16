using System;

namespace EmployeeReview.Domain.UserManagement.DTO
{
    public class UserBrief
    {
        public Guid UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}