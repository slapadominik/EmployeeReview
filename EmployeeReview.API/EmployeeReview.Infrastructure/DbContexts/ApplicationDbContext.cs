using EmployeeReview.Infrastructure.DAO;
using Microsoft.EntityFrameworkCore;

namespace EmployeeReview.Infrastructure.DbContexts
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<UserDAO> Users { get; set; }
        
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }
    }
}