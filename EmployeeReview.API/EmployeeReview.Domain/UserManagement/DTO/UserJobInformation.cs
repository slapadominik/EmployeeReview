using System;

namespace EmployeeReview.Domain.UserManagement.DTO
{
    public class UserJobInformation
    {
        public Guid UserId { get; set; }
        public int JobTitle { get; set; }
        public Guid SupervisorId{ get; set; }
        public int TeamId { get; set; }
    }
}