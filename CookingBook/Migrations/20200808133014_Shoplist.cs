using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CookingBook.Migrations
{
    public partial class Shoplist : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "id",
                keyValue: new Guid("cc54df8c-38ee-4c35-8cce-39b1d2714cb8"));

            migrationBuilder.AlterColumn<string>(
                name: "name",
                table: "Role",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.CreateTable(
                name: "Shoplist",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    name = table.Column<string>(nullable: false),
                    description = table.Column<string>(nullable: true),
                    owner_id = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shoplist", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "ShoplistRole",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShoplistRole", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "ShoplistCategory",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    name = table.Column<string>(nullable: false),
                    description = table.Column<string>(nullable: true),
                    ShoplistId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShoplistCategory", x => x.id);
                    table.ForeignKey(
                        name: "FK_ShoplistCategory_Shoplist_ShoplistId",
                        column: x => x.ShoplistId,
                        principalTable: "Shoplist",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ShoplistUser",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    role_id = table.Column<int>(nullable: false, defaultValue: 3),
                    user_id = table.Column<Guid>(nullable: false),
                    shoplist_id = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShoplistUser", x => x.id);
                    table.ForeignKey(
                        name: "FK_ShoplistUser_ShoplistRole_role_id",
                        column: x => x.role_id,
                        principalTable: "ShoplistRole",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ShoplistUser_Shoplist_shoplist_id",
                        column: x => x.shoplist_id,
                        principalTable: "Shoplist",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ShoplistUser_User_user_id",
                        column: x => x.user_id,
                        principalTable: "User",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ShoplistProduct",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    name = table.Column<string>(nullable: true),
                    description = table.Column<string>(nullable: true),
                    price = table.Column<double>(nullable: false),
                    ShoplistCategoryId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShoplistProduct", x => x.id);
                    table.ForeignKey(
                        name: "FK_ShoplistProduct_ShoplistCategory_ShoplistCategoryId",
                        column: x => x.ShoplistCategoryId,
                        principalTable: "ShoplistCategory",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "ShoplistRole",
                columns: new[] { "id", "name" },
                values: new object[,]
                {
                    { 1, "Owner" },
                    { 2, "Read/Write" },
                    { 3, "Read" }
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "id", "birth_date", "email", "firstname", "lastname", "middlename", "password", "RefreshToken", "role_id" },
                values: new object[] { new Guid("982d6958-0ff5-4152-9786-1552fef1b85b"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "bogdan.kand97@gmail.com", "Bogdan", "Kandela", "Igorevich", "bk_password", null, 1 });

            migrationBuilder.CreateIndex(
                name: "IX_ShoplistCategory_ShoplistId",
                table: "ShoplistCategory",
                column: "ShoplistId");

            migrationBuilder.CreateIndex(
                name: "IX_ShoplistProduct_ShoplistCategoryId",
                table: "ShoplistProduct",
                column: "ShoplistCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ShoplistUser_role_id",
                table: "ShoplistUser",
                column: "role_id");

            migrationBuilder.CreateIndex(
                name: "IX_ShoplistUser_shoplist_id",
                table: "ShoplistUser",
                column: "shoplist_id");

            migrationBuilder.CreateIndex(
                name: "IX_ShoplistUser_user_id",
                table: "ShoplistUser",
                column: "user_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ShoplistProduct");

            migrationBuilder.DropTable(
                name: "ShoplistUser");

            migrationBuilder.DropTable(
                name: "ShoplistCategory");

            migrationBuilder.DropTable(
                name: "ShoplistRole");

            migrationBuilder.DropTable(
                name: "Shoplist");

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "id",
                keyValue: new Guid("982d6958-0ff5-4152-9786-1552fef1b85b"));

            migrationBuilder.AlterColumn<string>(
                name: "name",
                table: "Role",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 20);

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "id", "birth_date", "email", "firstname", "lastname", "middlename", "password", "RefreshToken", "role_id" },
                values: new object[] { new Guid("cc54df8c-38ee-4c35-8cce-39b1d2714cb8"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "bogdan.kand97@gmail.com", "Bogdan", "Kandela", "Igorevich", "bk_password", null, 1 });
        }
    }
}
