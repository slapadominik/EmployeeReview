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
                    TitleId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
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
                    Content = table.Column<string>(maxLength: 400, nullable: false),
                    UserId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Review", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Review_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                    { 14, "Architekt baz danych" },
                    { 13, "Architekt oprogramowania" },
                    { 12, "Starszy tester oprogramowania" },
                    { 11, "Starszy tester oprogramowania" },
                    { 9, "Młodszy tester oprogramowania" },
                    { 10, "Tester oprogramowania" },
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
                    { 3, "Supervisor" },
                    { 1, "Administrator" },
                    { 2, "HR" },
                    { 4, "Employee" }
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "Email", "FirstName", "LastName", "Password", "PasswordSalt", "Sex", "TitleId" },
                values: new object[] { new Guid("a0b337f8-ba69-4b2f-9c91-66eb27c29bd0"), "admin@gmail.com", "Dominik", "Słapa", new byte[] { 137, 51, 54, 83, 59, 91, 126, 205, 96, 202, 97, 74, 135, 98, 154, 249, 197, 162, 215, 6, 44, 32, 242, 140, 43, 70, 227, 141, 38, 60, 228, 191, 104, 179, 241, 102, 156, 28, 173, 99, 3, 134, 176, 199, 121, 194, 155, 71, 15, 126, 137, 117, 176, 120, 208, 125, 30, 143, 12, 134, 125, 94, 171, 45 }, new byte[] { 206, 146, 217, 32, 193, 206, 172, 83, 48, 157, 140, 102, 116, 97, 45, 81, 89, 67, 148, 126, 111, 140, 255, 83, 176, 130, 211, 10, 200, 64, 182, 136, 208, 161, 71, 149, 194, 62, 97, 231, 20, 16, 78, 203, 247, 127, 62, 102, 148, 107, 238, 132, 36, 134, 194, 104, 124, 126, 173, 100, 141, 226, 193, 89, 20, 31, 86, 196, 236, 98, 221, 101, 244, 194, 10, 225, 183, 177, 140, 60, 56, 0, 183, 35, 158, 91, 225, 176, 205, 168, 7, 196, 225, 172, 252, 180, 42, 225, 99, 231, 73, 213, 191, 237, 119, 226, 135, 40, 59, 210, 221, 237, 113, 108, 64, 199, 213, 211, 53, 72, 0, 254, 12, 72, 7, 20, 24, 88 }, "M", 16 });

            migrationBuilder.InsertData(
                table: "UserRole",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { new Guid("a0b337f8-ba69-4b2f-9c91-66eb27c29bd0"), 1 });

            migrationBuilder.CreateIndex(
                name: "IX_Review_UserId",
                table: "Review",
                column: "UserId");

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
                name: "JobTitle");
        }
    }
}
