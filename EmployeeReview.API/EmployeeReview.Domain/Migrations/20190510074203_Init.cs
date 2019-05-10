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
                values: new object[] { new Guid("585395a8-663e-4ff2-bd09-8c756b2d9a59"), "admin@gmail.com", "Dominik", "Słapa", new byte[] { 170, 250, 107, 184, 207, 20, 137, 118, 8, 184, 66, 132, 71, 124, 221, 136, 219, 76, 193, 190, 157, 220, 179, 153, 118, 52, 119, 125, 173, 148, 93, 186, 225, 51, 236, 163, 37, 141, 40, 88, 29, 47, 160, 79, 119, 173, 155, 99, 49, 207, 228, 165, 78, 242, 21, 240, 106, 81, 132, 136, 245, 153, 215, 240 }, new byte[] { 75, 251, 30, 150, 228, 18, 1, 141, 224, 225, 234, 210, 173, 168, 43, 31, 24, 167, 22, 80, 164, 1, 212, 175, 211, 150, 102, 174, 99, 151, 41, 162, 240, 31, 128, 160, 226, 247, 140, 193, 241, 107, 242, 35, 190, 106, 47, 43, 103, 218, 208, 72, 244, 163, 133, 218, 83, 109, 209, 89, 40, 64, 32, 21, 195, 227, 212, 214, 136, 175, 25, 41, 83, 186, 119, 197, 50, 45, 32, 237, 96, 73, 121, 30, 87, 119, 206, 146, 127, 33, 10, 162, 143, 94, 50, 219, 218, 20, 54, 22, 162, 244, 96, 225, 172, 134, 63, 174, 227, 192, 29, 170, 203, 184, 18, 100, 68, 110, 65, 226, 14, 12, 67, 143, 102, 54, 226, 10 }, "M", 16 });

            migrationBuilder.InsertData(
                table: "UserRole",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { new Guid("585395a8-663e-4ff2-bd09-8c756b2d9a59"), 1 });

            migrationBuilder.CreateIndex(
                name: "IX_Review_AuthorId",
                table: "Review",
                column: "AuthorId");

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
