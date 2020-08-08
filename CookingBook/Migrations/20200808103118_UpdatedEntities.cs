using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CookingBook.Migrations
{
    public partial class UpdatedEntities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Product_ProductCategory_CategoryId",
                table: "Product");

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "id",
                keyValue: new Guid("9c4f5bbd-3e54-4ed3-8868-3be4f7a22d2e"));

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Product",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "CategoryId",
                table: "Product",
                newName: "category_id");

            migrationBuilder.RenameIndex(
                name: "IX_Product_CategoryId",
                table: "Product",
                newName: "IX_Product_category_id");

            migrationBuilder.CreateTable(
                name: "NutritionDeclaration",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    details_id = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NutritionDeclaration", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "ProductDetails",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    name = table.Column<string>(maxLength: 30, nullable: false),
                    description = table.Column<string>(maxLength: 60, nullable: true),
                    price = table.Column<double>(nullable: false),
                    user_id = table.Column<Guid>(nullable: false),
                    NutritionDeclarationId = table.Column<Guid>(nullable: true),
                    product_id = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductDetails", x => x.id);
                    table.ForeignKey(
                        name: "FK_ProductDetails_NutritionDeclaration_NutritionDeclarationId",
                        column: x => x.NutritionDeclarationId,
                        principalTable: "NutritionDeclaration",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProductDetails_Product_product_id",
                        column: x => x.product_id,
                        principalTable: "Product",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductDetails_User_user_id",
                        column: x => x.user_id,
                        principalTable: "User",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "id", "birth_date", "email", "firstname", "lastname", "middlename", "password", "RefreshToken", "role_id" },
                values: new object[] { new Guid("cc54df8c-38ee-4c35-8cce-39b1d2714cb8"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "bogdan.kand97@gmail.com", "Bogdan", "Kandela", "Igorevich", "bk_password", null, 1 });

            migrationBuilder.CreateIndex(
                name: "IX_ProductDetails_NutritionDeclarationId",
                table: "ProductDetails",
                column: "NutritionDeclarationId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductDetails_product_id",
                table: "ProductDetails",
                column: "product_id");

            migrationBuilder.CreateIndex(
                name: "IX_ProductDetails_user_id",
                table: "ProductDetails",
                column: "user_id");

            migrationBuilder.AddForeignKey(
                name: "FK_Product_ProductCategory_category_id",
                table: "Product",
                column: "category_id",
                principalTable: "ProductCategory",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Product_ProductCategory_category_id",
                table: "Product");

            migrationBuilder.DropTable(
                name: "ProductDetails");

            migrationBuilder.DropTable(
                name: "NutritionDeclaration");

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "id",
                keyValue: new Guid("cc54df8c-38ee-4c35-8cce-39b1d2714cb8"));

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Product",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "category_id",
                table: "Product",
                newName: "CategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_Product_category_id",
                table: "Product",
                newName: "IX_Product_CategoryId");

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "id", "birth_date", "email", "firstname", "lastname", "middlename", "password", "RefreshToken", "role_id" },
                values: new object[] { new Guid("9c4f5bbd-3e54-4ed3-8868-3be4f7a22d2e"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "bogdan.kand97@gmail.com", "Bogdan", "Kandela", "Igorevich", "bk_password", null, 1 });

            migrationBuilder.AddForeignKey(
                name: "FK_Product_ProductCategory_CategoryId",
                table: "Product",
                column: "CategoryId",
                principalTable: "ProductCategory",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
