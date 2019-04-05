
using Microsoft.EntityFrameworkCore;
using RoleDAO = EmployeeReview.Domain.Common.Persistence.DAO.RoleDAO;
using UserDAO = EmployeeReview.Domain.Common.Persistence.DAO.UserDAO;
using UserRoleDAO = EmployeeReview.Domain.Common.Persistence.DAO.UserRoleDAO;

namespace EmployeeReview.Domain.Common.Persistence
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<UserDAO> Users { get; set; }
        public DbSet<RoleDAO> Roles { get; set; }

        public ApplicationDbContext()
        {
        }

        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserRoleDAO>()
                .HasKey(t => new { t.UserId, t.RoleId });

            modelBuilder.Entity<UserRoleDAO>()
                .HasOne(pt => pt.User)
                .WithMany(p => p.UserRole)
                .HasForeignKey(pt => pt.UserId);

            modelBuilder.Entity<UserRoleDAO>()
                .HasOne(pt => pt.Role)
                .WithMany(t => t.UserRole)
                .HasForeignKey(pt => pt.RoleId);

            modelBuilder.Entity<RoleDAO>().HasData(new RoleDAO[]
            {
                new RoleDAO{Id = 1, Name = "Administrator"},
                new RoleDAO{Id = 2, Name = "HR"},
                new RoleDAO{Id = 3, Name = "Supervisor"},
                new RoleDAO{Id = 4, Name = "Employee"}
            });
        }
    }
}