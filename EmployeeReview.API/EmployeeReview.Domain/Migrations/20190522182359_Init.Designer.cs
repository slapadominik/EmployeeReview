﻿// <auto-generated />
using System;
using EmployeeReview.Domain.Common.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EmployeeReview.Domain.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20190522182359_Init")]
    partial class Init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("EmployeeReview.Domain.Common.Persistence.DAO.JobTitleDAO", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("JobTitle");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Młodszy programista .NET"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Programista .NET"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Starszy programista .NET"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Młodszy programista SQL"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Programista SQL"
                        },
                        new
                        {
                            Id = 6,
                            Name = "Starszy programista SQL"
                        },
                        new
                        {
                            Id = 7,
                            Name = "Scrum Master"
                        },
                        new
                        {
                            Id = 8,
                            Name = "Senior Scrum Master"
                        },
                        new
                        {
                            Id = 9,
                            Name = "Młodszy tester oprogramowania"
                        },
                        new
                        {
                            Id = 10,
                            Name = "Tester oprogramowania"
                        },
                        new
                        {
                            Id = 11,
                            Name = "Starszy tester oprogramowania"
                        },
                        new
                        {
                            Id = 12,
                            Name = "Starszy tester oprogramowania"
                        },
                        new
                        {
                            Id = 13,
                            Name = "Architekt oprogramowania"
                        },
                        new
                        {
                            Id = 14,
                            Name = "Architekt baz danych"
                        },
                        new
                        {
                            Id = 15,
                            Name = "Kierownik testerów"
                        },
                        new
                        {
                            Id = 16,
                            Name = "Kierownik zespołów programistycznych"
                        });
                });

            modelBuilder.Entity("EmployeeReview.Domain.Common.Persistence.DAO.ReviewDAO", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<Guid?>("AuthorId");

                    b.Property<string>("Content")
                        .IsRequired();

                    b.Property<DateTime>("Created");

                    b.Property<byte>("Rate");

                    b.Property<Guid?>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("AuthorId");

                    b.HasIndex("UserId");

                    b.ToTable("Review");
                });

            modelBuilder.Entity("EmployeeReview.Domain.Common.Persistence.DAO.RoleDAO", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("Role");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Administrator"
                        },
                        new
                        {
                            Id = 2,
                            Name = "HR"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Supervisor"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Employee"
                        });
                });

            modelBuilder.Entity("EmployeeReview.Domain.Common.Persistence.DAO.TeamDAO", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(60);

                    b.HasKey("Id");

                    b.ToTable("Team");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Testerzy"
                        },
                        new
                        {
                            Id = 2,
                            Name = "IT-300"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Gwiezdna Flota"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Delta Force"
                        },
                        new
                        {
                            Id = 5,
                            Name = "RR"
                        },
                        new
                        {
                            Id = 6,
                            Name = "Angry Nerds"
                        },
                        new
                        {
                            Id = 7,
                            Name = "Nitro"
                        });
                });

            modelBuilder.Entity("EmployeeReview.Domain.Common.Persistence.DAO.UserDAO", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(30);

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(30);

                    b.Property<byte[]>("Password")
                        .IsRequired();

                    b.Property<byte[]>("PasswordSalt")
                        .IsRequired();

                    b.Property<string>("Sex")
                        .IsRequired()
                        .HasConversion(new ValueConverter<string, string>(v => default(string), v => default(string), new ConverterMappingHints(size: 1)));

                    b.Property<Guid?>("SupervisorId");

                    b.Property<int?>("TeamId");

                    b.Property<int>("TitleId");

                    b.HasKey("Id");

                    b.HasIndex("SupervisorId");

                    b.HasIndex("TeamId");

                    b.HasIndex("TitleId");

                    b.ToTable("User");

                    b.HasData(
                        new
                        {
                            Id = new Guid("758eb180-5cb6-4dff-b83d-c38e342f3b98"),
                            Email = "admin@gmail.com",
                            FirstName = "Dominik",
                            LastName = "Słapa",
                            Password = new byte[] { 130, 11, 115, 193, 37, 113, 0, 104, 145, 73, 97, 6, 81, 206, 47, 129, 156, 230, 3, 117, 160, 95, 123, 30, 229, 142, 18, 125, 161, 224, 129, 153, 132, 18, 149, 167, 239, 201, 146, 151, 211, 235, 221, 81, 37, 130, 142, 52, 61, 81, 158, 221, 104, 240, 250, 171, 232, 43, 199, 186, 83, 136, 151, 187 },
                            PasswordSalt = new byte[] { 129, 97, 172, 25, 187, 40, 4, 153, 169, 167, 98, 27, 235, 142, 216, 87, 157, 189, 174, 54, 61, 174, 238, 104, 27, 169, 214, 52, 218, 57, 223, 217, 171, 32, 206, 9, 129, 56, 73, 232, 58, 182, 47, 211, 44, 143, 65, 40, 155, 139, 36, 157, 38, 154, 66, 10, 239, 104, 178, 158, 233, 190, 130, 113, 152, 34, 108, 14, 102, 168, 129, 88, 96, 32, 57, 25, 206, 114, 105, 177, 13, 61, 92, 162, 0, 211, 40, 109, 135, 83, 135, 225, 99, 145, 87, 116, 251, 72, 11, 11, 126, 16, 57, 32, 217, 94, 165, 192, 73, 100, 20, 245, 59, 82, 237, 229, 146, 217, 44, 79, 201, 106, 207, 248, 114, 211, 4, 47 },
                            Sex = "M",
                            TitleId = 16
                        });
                });

            modelBuilder.Entity("EmployeeReview.Domain.Common.Persistence.DAO.UserRoleDAO", b =>
                {
                    b.Property<Guid>("UserId");

                    b.Property<int>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("UserRole");

                    b.HasData(
                        new
                        {
                            UserId = new Guid("758eb180-5cb6-4dff-b83d-c38e342f3b98"),
                            RoleId = 1
                        });
                });

            modelBuilder.Entity("EmployeeReview.Domain.Common.Persistence.DAO.ReviewDAO", b =>
                {
                    b.HasOne("EmployeeReview.Domain.Common.Persistence.DAO.UserDAO", "Author")
                        .WithMany("ReviewsGiven")
                        .HasForeignKey("AuthorId");

                    b.HasOne("EmployeeReview.Domain.Common.Persistence.DAO.UserDAO", "User")
                        .WithMany("ReviewsReceived")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("EmployeeReview.Domain.Common.Persistence.DAO.UserDAO", b =>
                {
                    b.HasOne("EmployeeReview.Domain.Common.Persistence.DAO.UserDAO", "Supervisor")
                        .WithMany()
                        .HasForeignKey("SupervisorId");

                    b.HasOne("EmployeeReview.Domain.Common.Persistence.DAO.TeamDAO", "Team")
                        .WithMany("Users")
                        .HasForeignKey("TeamId");

                    b.HasOne("EmployeeReview.Domain.Common.Persistence.DAO.JobTitleDAO", "Title")
                        .WithMany("Users")
                        .HasForeignKey("TitleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("EmployeeReview.Domain.Common.Persistence.DAO.UserRoleDAO", b =>
                {
                    b.HasOne("EmployeeReview.Domain.Common.Persistence.DAO.RoleDAO", "Role")
                        .WithMany("UserRole")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("EmployeeReview.Domain.Common.Persistence.DAO.UserDAO", "User")
                        .WithMany("UserRole")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
