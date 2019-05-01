using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeReview.Domain.Common.Persistence.DAO
{
    [Table("JobTitle")]
    public class JobTitleDAO
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name{ get; set; }

        public ICollection<UserDAO> Users { get; set; }
    }
}