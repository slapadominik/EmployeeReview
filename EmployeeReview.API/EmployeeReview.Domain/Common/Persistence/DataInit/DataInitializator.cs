using System;
using System.Security.Cryptography;
using System.Text;
using EmployeeReview.Domain.Common.Persistence.DAO;
using Microsoft.EntityFrameworkCore;

namespace EmployeeReview.Domain.Common.Persistence.DataInit
{
    public static class DataInitializator
    {
        public static void InitRoles(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RoleDAO>().HasData(new RoleDAO[]
            {
                new RoleDAO{Id = 1, Name = "Administrator"},
                new RoleDAO{Id = 2, Name = "HR"},
                new RoleDAO{Id = 3, Name = "Supervisor"},
                new RoleDAO{Id = 4, Name = "Employee"}
            });
        }

        public static void InitJobTitles(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<JobTitleDAO>().HasData(new JobTitleDAO[]
            {
                new JobTitleDAO{Id = 1, Name = "Młodszy programista .NET"},
                new JobTitleDAO{Id = 2, Name = "Programista .NET"},
                new JobTitleDAO{Id = 3, Name = "Starszy programista .NET"},
                new JobTitleDAO{Id = 4, Name = "Młodszy programista SQL"},
                new JobTitleDAO{Id = 5, Name = "Programista SQL"},
                new JobTitleDAO{Id = 6, Name = "Starszy programista SQL"},
                new JobTitleDAO{Id = 7, Name = "Scrum Master"},
                new JobTitleDAO{Id = 8, Name = "Senior Scrum Master"},
                new JobTitleDAO{Id = 9, Name = "Młodszy tester oprogramowania"},
                new JobTitleDAO{Id = 10, Name = "Tester oprogramowania"},
                new JobTitleDAO{Id = 11, Name = "Starszy tester oprogramowania"},
                new JobTitleDAO{Id = 12, Name = "Starszy tester oprogramowania"},
                new JobTitleDAO{Id = 13, Name = "Architekt oprogramowania"},
                new JobTitleDAO{Id = 14, Name = "Architekt baz danych"},
                new JobTitleDAO{Id = 15, Name = "Kierownik testerów"},
                new JobTitleDAO{Id = 16, Name = "Kierownik zespołów programistycznych"}
            });
        }

        public static void InitAdmin(this ModelBuilder modelBuilder)
        {
            var hashedPassword = HashPassword("admin");
            var userId = Guid.NewGuid();
            modelBuilder.Entity<UserDAO>().HasData(new UserDAO[]
            {   
                new UserDAO
                {
                    Id = userId,
                    Email = "admin@gmail.com",
                    FirstName = "Dominik",
                    LastName = "Słapa",
                    Password = hashedPassword.password,
                    PasswordSalt = hashedPassword.salt,
                    Sex = 'M',
                    TitleId = 16                    
                }
            });
            modelBuilder.Entity<UserRoleDAO>().HasData(new UserRoleDAO[]
            {
                new UserRoleDAO {RoleId = 1, UserId = userId}
            });
        }

        private static (byte[] password, byte[] salt) HashPassword(string password)
        {
            byte[] salt;
            byte[] passwordHash;
            using (var hmac = new HMACSHA512())
            {
                salt = hmac.Key;
                passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            }

            return (passwordHash, salt);
        }

    }
}