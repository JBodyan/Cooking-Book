using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CookingBook.Migrations
{
    public partial class DbFixes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "id",
                keyValue: new Guid("982d6958-0ff5-4152-9786-1552fef1b85b"));

            migrationBuilder.AddColumn<Guid>(
                name: "nutrition_id",
                table: "ProductDetails",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "id", "birth_date", "email", "firstname", "lastname", "middlename", "password", "RefreshToken", "role_id" },
                values: new object[] { new Guid("f89d9aaf-2f2f-4922-8e85-19ebe8a5e0a0"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "bogdan.kand97@gmail.com", "Bogdan", "Kandela", "Igorevich", "bk_password", null, 1 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "id",
                keyValue: new Guid("f89d9aaf-2f2f-4922-8e85-19ebe8a5e0a0"));

            migrationBuilder.DropColumn(
                name: "nutrition_id",
                table: "ProductDetails");

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "id", "birth_date", "email", "firstname", "lastname", "middlename", "password", "RefreshToken", "role_id" },
                values: new object[] { new Guid("982d6958-0ff5-4152-9786-1552fef1b85b"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "bogdan.kand97@gmail.com", "Bogdan", "Kandela", "Igorevich", "bk_password", null, 1 });
        }
    }
}
