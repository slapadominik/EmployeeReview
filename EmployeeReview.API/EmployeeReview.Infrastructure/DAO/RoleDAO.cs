using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeReview.Infrastructure.DAO
{
    [Table("Role")]
    public class RoleDAO
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(50)]
        [Required]
        public string Name { get; set; }

        public List<UserRoleDAO> UserRole { get; } = new List<UserRoleDAO>();
    }
}