using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EmployeeReview.Domain.Migrations
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
                    SupervisorId = table.Column<Guid>(nullable: true),
                    TeamId = table.Column<int>(nullable: true)
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
                        name: "FK_User_Team_TeamId",
                        column: x => x.TeamId,
                        principalTable: "Team",
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
                columns: new[] { "Id", "Email", "FirstName", "LastName", "Password", "PasswordSalt", "Sex", "SupervisorId", "TeamId", "TitleId" },
                values: new object[] { new Guid("758eb180-5cb6-4dff-b83d-c38e342f3b98"), "admin@gmail.com", "Dominik", "Słapa", new byte[] { 130, 11, 115, 193, 37, 113, 0, 104, 145, 73, 97, 6, 81, 206, 47, 129, 156, 230, 3, 117, 160, 95, 123, 30, 229, 142, 18, 125, 161, 224, 129, 153, 132, 18, 149, 167, 239, 201, 146, 151, 211, 235, 221, 81, 37, 130, 142, 52, 61, 81, 158, 221, 104, 240, 250, 171, 232, 43, 199, 186, 83, 136, 151, 187 }, new byte[] { 129, 97, 172, 25, 187, 40, 4, 153, 169, 167, 98, 27, 235, 142, 216, 87, 157, 189, 174, 54, 61, 174, 238, 104, 27, 169, 214, 52, 218, 57, 223, 217, 171, 32, 206, 9, 129, 56, 73, 232, 58, 182, 47, 211, 44, 143, 65, 40, 155, 139, 36, 157, 38, 154, 66, 10, 239, 104, 178, 158, 233, 190, 130, 113, 152, 34, 108, 14, 102, 168, 129, 88, 96, 32, 57, 25, 206, 114, 105, 177, 13, 61, 92, 162, 0, 211, 40, 109, 135, 83, 135, 225, 99, 145, 87, 116, 251, 72, 11, 11, 126, 16, 57, 32, 217, 94, 165, 192, 73, 100, 20, 245, 59, 82, 237, 229, 146, 217, 44, 79, 201, 106, 207, 248, 114, 211, 4, 47 }, "M", null, null, 16 });

            migrationBuilder.InsertData(
                table: "UserRole",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { new Guid("758eb180-5cb6-4dff-b83d-c38e342f3b98"), 1 });

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
                name: "IX_User_TeamId",
                table: "User",
                column: "TeamId");

            migrationBuilder.CreateIndex(
                name: "IX_User_TitleId",
                table: "User",
                column: "TitleId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRole_RoleId",
                table: "UserRole",
                column: "RoleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Review");

            migrationBuilder.DropTable(
                name: "UserRole");

            migrationBuilder.DropTable(
                name: "Role");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Team");

            migrationBuilder.DropTable(
                name: "JobTitle");
        }
    }
}
