using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeReview.Domain.Common.Persistence.DAO
{
    [Table("UserTeam")]
    public class UserTeamDAO
    {
        public UserDAO User { get; set; }
        public Guid UserId { get; set; }
        public TeamDAO Team{ get; set; }
        public int TeamId { get; set; }
    }
}