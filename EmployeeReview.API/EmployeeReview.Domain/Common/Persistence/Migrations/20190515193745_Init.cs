using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EmployeeReview.Domain.Common.Persistence.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "JobTitle",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobTitle", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Role",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Team",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 60, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Team", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Email = table.Column<string>(maxLength: 50, nullable: false),
                    Password = table.Column<byte[]>(nullable: false),
                    PasswordSalt = table.Column<byte[]>(nullable: false),
                    FirstName = table.Column<string>(maxLength: 30, nullable: false),
                    LastName = table.Column<string>(maxLength: 30, nullable: false),
                    Sex = table.Column<string>(nullable: false),
                    TitleId = table.Column<int>(nullable: false),
                    SupervisorId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                    table.ForeignKey(
                        name: "FK_User_User_SupervisorId",
                        column: x => x.SupervisorId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_User_JobTitle_TitleId",
                        column: x => x.TitleId,
                        principalTable: "JobTitle",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Review",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Rate = table.Column<byte>(nullable: false),
                    Content = table.Column<string>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    AuthorId = table.Column<Guid>(nullable: true),
                    UserId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Review", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Review_User_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Review_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserRole",
                columns: table => new
                {
                    UserId = table.Column<Guid>(nullable: false),
                    RoleId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRole", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_UserRole_Role_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Role",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserRole_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserTeam",
                columns: table => new
                {
                    UserId = table.Column<Guid>(nullable: false),
                    TeamId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTeam", x => new { x.UserId, x.TeamId });
                    table.ForeignKey(
                        name: "FK_UserTeam_Team_TeamId",
                        column: x => x.TeamId,
                        principalTable: "Team",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserTeam_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "JobTitle",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Młodszy programista .NET" },
                    { 16, "Kierownik zespołów programistycznych" },
                    { 15, "Kierownik testerów" },
                    { 13, "Architekt oprogramowania" },
                    { 12, "Starszy tester oprogramowania" },
                    { 11, "Starszy tester oprogramowania" },
                    { 10, "Tester oprogramowania" },
                    { 9, "Młodszy tester oprogramowania" },
                    { 14, "Architekt baz danych" },
                    { 7, "Scrum Master" },
                    { 6, "Starszy programista SQL" },
                    { 5, "Programista SQL" },
                    { 4, "Młodszy programista SQL" },
                    { 3, "Starszy programista .NET" },
                    { 2, "Programista .NET" },
                    { 8, "Senior Scrum Master" }
                });

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 4, "Employee" },
                    { 3, "Supervisor" },
                    { 2, "HR" },
                    { 1, "Administrator" }
                });

            migrationBuilder.InsertData(
                table: "Team",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 6, "Angry Nerds" },
                    { 1, "Testerzy" },
                    { 2, "IT-300" },
                    { 3, "Gwiezdna Flota" },
                    { 4, "Delta Force" },
                    { 5, "RR" },
                    { 7, "Nitro" }
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "Email", "FirstName", "LastName", "Password", "PasswordSalt", "Sex", "SupervisorId", "TitleId" },
                values: new object[] { new Guid("5044dad1-e57b-4431-9367-59c7ce98d014"), "admin@gmail.com", "Dominik", "Słapa", new byte[] { 156, 56, 196, 64, 234, 151, 240, 23, 217, 233, 43, 29, 114, 129, 45, 96, 200, 187, 122, 182, 14, 19, 58, 65, 212, 228, 242, 239, 115, 167, 121, 111, 180, 254, 20, 69, 164, 18, 94, 113, 57, 146, 182, 58, 97, 242, 89, 68, 215, 221, 40, 62, 169, 64, 188, 162, 152, 58, 128, 151, 211, 28, 125, 114 }, new byte[] { 4, 159, 41, 147, 23, 251, 112, 94, 22, 234, 239, 161, 173, 234, 215, 236, 142, 61, 198, 17, 198, 80, 64, 72, 207, 64, 6, 107, 13, 251, 100, 36, 215, 189, 98, 195, 250, 133, 56, 30, 102, 102, 96, 49, 243, 79, 121, 23, 165, 136, 82, 143, 107, 208, 134, 177, 204, 116, 196, 196, 38, 204, 184, 220, 124, 12, 8, 56, 199, 36, 12, 217, 146, 211, 65, 154, 187, 125, 202, 14, 212, 196, 230, 2, 129, 102, 80, 71, 189, 208, 76, 249, 166, 227, 72, 206, 252, 176, 99, 55, 28, 152, 0, 42, 240, 115, 79, 122, 87, 245, 195, 250, 118, 33, 38, 124, 43, 9, 244, 207, 121, 237, 30, 107, 141, 184, 127, 46 }, "M", null, 16 });

            migrationBuilder.InsertData(
                table: "UserRole",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { new Guid("5044dad1-e57b-4431-9367-59c7ce98d014"), 1 });

            migrationBuilder.CreateIndex(
                name: "IX_Review_AuthorId",
                table: "Review",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_Review_UserId",
                table: "Review",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_User_SupervisorId",
                table: "User",
                column: "SupervisorId");

            migrationBuilder.CreateIndex(
                name: "IX_User_TitleId",
                table: "User",
                column: "TitleId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRole_RoleId",
                table: "UserRole",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_UserTeam_TeamId",
                table: "UserTeam",
                column: "TeamId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Review");

            migrationBuilder.DropTable(
                name: "UserRole");

            migrationBuilder.DropTable(
                name: "UserTeam");

            migrationBuilder.DropTable(
                name: "Role");

            migrationBuilder.DropTable(
                name: "Team");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "JobTitle");
        }
    }
}
