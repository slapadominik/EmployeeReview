using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeReview.Domain.Common.Persistence.DAO
{
    [Table("Review")]
    public class ReviewDAO
    {
        [Key]
        public int Id { get; set; }

        public byte Rate { get; set; }

        [MaxLength(400)]
        [Required]
        public string Content { get; set; }

        public UserDAO User { get; set; }
        public Guid UserId { get; set; }
    }
}