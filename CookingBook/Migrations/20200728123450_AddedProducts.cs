using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CookingBook.Migrations
{
    public partial class AddedProducts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "id",
                keyValue: new Guid("ea3e6298-8a0d-4a65-a424-1adc4fb07c0d"));

            migrationBuilder.CreateTable(
                name: "ProductCategory",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    name = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductCategory", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    name = table.Column<string>(maxLength: 30, nullable: false),
                    CategoryId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Product_ProductCategory_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "ProductCategory",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "id", "birth_date", "email", "firstname", "lastname", "middlename", "password", "RefreshToken", "role_id" },
                values: new object[] { new Guid("9c4f5bbd-3e54-4ed3-8868-3be4f7a22d2e"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "bogdan.kand97@gmail.com", "Bogdan", "Kandela", "Igorevich", "bk_password", null, 1 });

            migrationBuilder.CreateIndex(
                name: "IX_Product_CategoryId",
                table: "Product",
                column: "CategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "ProductCategory");

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "id",
                keyValue: new Guid("9c4f5bbd-3e54-4ed3-8868-3be4f7a22d2e"));

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "id", "birth_date", "email", "firstname", "lastname", "middlename", "password", "RefreshToken", "role_id" },
                values: new object[] { new Guid("ea3e6298-8a0d-4a65-a424-1adc4fb07c0d"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "bogdan.kand97@gmail.com", "Bogdan", "Kandela", "Igorevich", "bk_password", null, 1 });
        }
    }
}
