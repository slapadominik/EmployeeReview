using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeReview.Domain.Common.Persistence.DAO
{
    [Table("Team")]
    public class TeamDAO
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(60)]
        [Required]
        public string Name { get; set; }

        public IList<UserTeamDAO> UserTeam { get; set; } = new List<UserTeamDAO>();
    }
}