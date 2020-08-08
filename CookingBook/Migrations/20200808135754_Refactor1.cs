using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CookingBook.Migrations
{
    public partial class Refactor1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductDetails_NutritionDeclaration_NutritionDeclarationId",
                table: "ProductDetails");

            migrationBuilder.DropIndex(
                name: "IX_ProductDetails_NutritionDeclarationId",
                table: "ProductDetails");

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "id",
                keyValue: new Guid("f89d9aaf-2f2f-4922-8e85-19ebe8a5e0a0"));

            migrationBuilder.DropColumn(
                name: "nutrition_id",
                table: "ProductDetails");

            migrationBuilder.RenameColumn(
                name: "NutritionDeclarationId",
                table: "ProductDetails",
                newName: "nutrition_declaration_id");

            migrationBuilder.AlterColumn<Guid>(
                name: "nutrition_declaration_id",
                table: "ProductDetails",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "id", "birth_date", "email", "firstname", "lastname", "middlename", "password", "RefreshToken", "role_id" },
                values: new object[] { new Guid("3167e6e5-e129-49a0-81c5-660a7e8b130e"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "bogdan.kand97@gmail.com", "Bogdan", "Kandela", "Igorevich", "bk_password", null, 1 });

            migrationBuilder.CreateIndex(
                name: "IX_ProductDetails_nutrition_declaration_id",
                table: "ProductDetails",
                column: "nutrition_declaration_id",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductDetails_NutritionDeclaration_nutrition_declaration_id",
                table: "ProductDetails",
                column: "nutrition_declaration_id",
                principalTable: "NutritionDeclaration",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductDetails_NutritionDeclaration_nutrition_declaration_id",
                table: "ProductDetails");

            migrationBuilder.DropIndex(
                name: "IX_ProductDetails_nutrition_declaration_id",
                table: "ProductDetails");

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "id",
                keyValue: new Guid("3167e6e5-e129-49a0-81c5-660a7e8b130e"));

            migrationBuilder.RenameColumn(
                name: "nutrition_declaration_id",
                table: "ProductDetails",
                newName: "NutritionDeclarationId");

            migrationBuilder.AlterColumn<Guid>(
                name: "NutritionDeclarationId",
                table: "ProductDetails",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid));

            migrationBuilder.AddColumn<Guid>(
                name: "nutrition_id",
                table: "ProductDetails",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "id", "birth_date", "email", "firstname", "lastname", "middlename", "password", "RefreshToken", "role_id" },
                values: new object[] { new Guid("f89d9aaf-2f2f-4922-8e85-19ebe8a5e0a0"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "bogdan.kand97@gmail.com", "Bogdan", "Kandela", "Igorevich", "bk_password", null, 1 });

            migrationBuilder.CreateIndex(
                name: "IX_ProductDetails_NutritionDeclarationId",
                table: "ProductDetails",
                column: "NutritionDeclarationId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductDetails_NutritionDeclaration_NutritionDeclarationId",
                table: "ProductDetails",
                column: "NutritionDeclarationId",
                principalTable: "NutritionDeclaration",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
