using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CookingBook.Migrations
{
    public partial class AddProducts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "id",
                keyValue: new Guid("e9079f11-be1d-4f6b-93f3-d06d20515c9b"));

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "id", "birth_date", "email", "firstname", "lastname", "middlename", "password", "RefreshToken", "role_id" },
                values: new object[] { new Guid("ea3e6298-8a0d-4a65-a424-1adc4fb07c0d"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "bogdan.kand97@gmail.com", "Bogdan", "Kandela", "Igorevich", "bk_password", null, 1 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "id",
                keyValue: new Guid("ea3e6298-8a0d-4a65-a424-1adc4fb07c0d"));

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "id", "birth_date", "email", "firstname", "lastname", "middlename", "password", "RefreshToken", "role_id" },
                values: new object[] { new Guid("e9079f11-be1d-4f6b-93f3-d06d20515c9b"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "bogdan.kand97@gmail.com", "Bogdan", "Kandela", "Igorevich", "bk_password", null, 1 });
        }
    }
}
