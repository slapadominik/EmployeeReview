using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeReview.Infrastructure.DAO
{
    [Table("UserRole")]
    public class UserRoleDAO
    {
        public UserDAO User { get; set; }
        public Guid UserId { get; set; }
        public RoleDAO Role { get; set; }
        public int RoleId { get; set; }
    }
}