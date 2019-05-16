
using EmployeeReview.Domain.Common.Persistence.DataInit;
using EmployeeReview.Domain.Common.Persistence.DAO;
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
        public DbSet<ReviewDAO> Reviews { get; set; }
        public DbSet<JobTitleDAO> JobTitles { get; set; }
        public DbSet<UserRoleDAO> UserRoles { get; set; }

        public ApplicationDbContext(){}

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

            modelBuilder.Entity<ReviewDAO>()
                .HasOne(x => x.Author)
                .WithMany(x => x.ReviewsGiven)
                .HasForeignKey(x => x.AuthorId);

            modelBuilder.Entity<ReviewDAO>()
                .HasOne(x => x.User)
                .WithMany(x => x.ReviewsReceived)
                .HasForeignKey(x => x.UserId);

            modelBuilder.Entity<UserTeamDAO>()
                .HasKey(t => new { t.UserId, t.TeamId });

            modelBuilder.Entity<UserTeamDAO>()
                .HasOne(pt => pt.User)
                .WithMany(p => p.UserTeam)
                .HasForeignKey(pt => pt.UserId);

            modelBuilder.Entity<UserTeamDAO>()
                .HasOne(pt => pt.Team)
                .WithMany(t => t.UserTeam)
                .HasForeignKey(pt => pt.TeamId);


            modelBuilder.InitRoles();
            modelBuilder.InitJobTitles();
            modelBuilder.InitAdmin();
            modelBuilder.InitTeams();
        }
    }
}