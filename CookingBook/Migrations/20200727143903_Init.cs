using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CookingBook.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ResetPassword",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    confirmation_number = table.Column<string>(nullable: false),
                    reset_date = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResetPassword", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Role",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    firstname = table.Column<string>(maxLength: 20, nullable: false),
                    middlename = table.Column<string>(maxLength: 20, nullable: true),
                    lastname = table.Column<string>(maxLength: 20, nullable: false),
                    email = table.Column<string>(maxLength: 40, nullable: false),
                    birth_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    registered_date = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    RefreshToken = table.Column<string>(nullable: true),
                    password = table.Column<string>(maxLength: 100, nullable: false),
                    role_id = table.Column<int>(nullable: false, defaultValue: 1),
                    email_confirmed = table.Column<bool>(type: "bit", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.id);
                    table.ForeignKey(
                        name: "FK_User_Role_role_id",
                        column: x => x.role_id,
                        principalTable: "Role",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RefreshToken",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Token = table.Column<string>(nullable: true),
                    UserId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RefreshToken", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RefreshToken_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "id", "name" },
                values: new object[] { 1, "Admin" });

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "id", "name" },
                values: new object[] { 2, "User" });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "id", "birth_date", "email", "firstname", "lastname", "middlename", "password", "RefreshToken", "role_id" },
                values: new object[] { new Guid("e9079f11-be1d-4f6b-93f3-d06d20515c9b"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "bogdan.kand97@gmail.com", "Bogdan", "Kandela", "Igorevich", "bk_password", null, 1 });

            migrationBuilder.CreateIndex(
                name: "IX_RefreshToken_UserId",
                table: "RefreshToken",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_User_role_id",
                table: "User",
                column: "role_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RefreshToken");

            migrationBuilder.DropTable(
                name: "ResetPassword");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Role");
        }
    }
}
