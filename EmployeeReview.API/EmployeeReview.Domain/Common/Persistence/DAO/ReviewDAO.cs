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

        [Required]
        public string Content { get; set; }

        [Required]
        public DateTime Created { get; set; }

        public UserDAO Author { get; set; }
        public Guid? AuthorId { get; set; }

        public UserDAO User { get; set; }
        public Guid? UserId { get; set; }
    }
}