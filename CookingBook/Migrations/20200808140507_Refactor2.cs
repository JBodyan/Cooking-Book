using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CookingBook.Migrations
{
    public partial class Refactor2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShoplistUser_ShoplistRole_role_id",
                table: "ShoplistUser");

            migrationBuilder.DropIndex(
                name: "IX_ShoplistUser_role_id",
                table: "ShoplistUser");

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "id",
                keyValue: new Guid("3167e6e5-e129-49a0-81c5-660a7e8b130e"));

            migrationBuilder.DropColumn(
                name: "role_id",
                table: "ShoplistUser");

            migrationBuilder.AddColumn<int>(
                name: "shoplist_role_id",
                table: "ShoplistUser",
                nullable: false,
                defaultValue: 3);

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "id", "birth_date", "email", "firstname", "lastname", "middlename", "password", "RefreshToken", "role_id" },
                values: new object[] { new Guid("b16e6e4c-a700-45e1-a23e-0887e04c384c"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "bogdan.kand97@gmail.com", "Bogdan", "Kandela", "Igorevich", "bk_password", null, 1 });

            migrationBuilder.CreateIndex(
                name: "IX_ShoplistUser_shoplist_role_id",
                table: "ShoplistUser",
                column: "shoplist_role_id");

            migrationBuilder.AddForeignKey(
                name: "FK_ShoplistUser_ShoplistRole_shoplist_role_id",
                table: "ShoplistUser",
                column: "shoplist_role_id",
                principalTable: "ShoplistRole",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShoplistUser_ShoplistRole_shoplist_role_id",
                table: "ShoplistUser");

            migrationBuilder.DropIndex(
                name: "IX_ShoplistUser_shoplist_role_id",
                table: "ShoplistUser");

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "id",
                keyValue: new Guid("b16e6e4c-a700-45e1-a23e-0887e04c384c"));

            migrationBuilder.DropColumn(
                name: "shoplist_role_id",
                table: "ShoplistUser");

            migrationBuilder.AddColumn<int>(
                name: "role_id",
                table: "ShoplistUser",
                type: "int",
                nullable: false,
                defaultValue: 3);

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "id", "birth_date", "email", "firstname", "lastname", "middlename", "password", "RefreshToken", "role_id" },
                values: new object[] { new Guid("3167e6e5-e129-49a0-81c5-660a7e8b130e"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "bogdan.kand97@gmail.com", "Bogdan", "Kandela", "Igorevich", "bk_password", null, 1 });

            migrationBuilder.CreateIndex(
                name: "IX_ShoplistUser_role_id",
                table: "ShoplistUser",
                column: "role_id");

            migrationBuilder.AddForeignKey(
                name: "FK_ShoplistUser_ShoplistRole_role_id",
                table: "ShoplistUser",
                column: "role_id",
                principalTable: "ShoplistRole",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
