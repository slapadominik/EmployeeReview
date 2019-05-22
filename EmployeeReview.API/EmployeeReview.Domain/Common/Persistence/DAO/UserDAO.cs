using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeReview.Domain.Common.Persistence.DAO
{
    [Table("User")]
    public class UserDAO
    {
        [Key]
        public Guid Id { get; set; }

        [MaxLength(50)]
        [Required]
        public string Email { get; set; }

        [Required]
        public byte[] Password { get; set; }

        [Required]
        public byte[] PasswordSalt { get; set; }

        [MaxLength(30)]
        [Required]
        public string FirstName { get; set; }

        [MaxLength(30)]
        [Required]
        public string LastName { get; set; }

        public char Sex { get; set; }         
        public JobTitleDAO Title { get; set; }
        public int TitleId { get; set; }

        public UserDAO Supervisor { get; set; }
        public Guid? SupervisorId { get; set; }

        public TeamDAO Team { get; set; }
        public int? TeamId{ get; set; }

        public List<UserRoleDAO> UserRole { get; set; } = new List<UserRoleDAO>();
        public ICollection<ReviewDAO> ReviewsReceived { get; set; }
        public ICollection<ReviewDAO> ReviewsGiven { get; set; }
    }
}