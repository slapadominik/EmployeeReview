using System.Runtime.InteropServices.ComTypes;
using EmployeeReview.Infrastructure.DAO;
using Microsoft.EntityFrameworkCore;

namespace EmployeeReview.Infrastructure.DbContexts
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<UserDAO> Users { get; set; }
        public DbSet<RoleDAO> Roles { get; set; }

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