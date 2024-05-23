using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace fiorellopb101.Migrations
{
    public partial class CreatedProductCategoryImageTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SoftDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    SoftDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.id);
                    table.ForeignKey(
                        name: "FK_Product_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductImages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsMain = table.Column<bool>(type: "bit", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductImages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductImages_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Blogs",
                keyColumn: "id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 5, 16, 0, 15, 45, 195, DateTimeKind.Local).AddTicks(1104));

            migrationBuilder.UpdateData(
                table: "Blogs",
                keyColumn: "id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 5, 16, 0, 15, 45, 195, DateTimeKind.Local).AddTicks(1106));

            migrationBuilder.UpdateData(
                table: "Blogs",
                keyColumn: "id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 5, 16, 0, 15, 45, 195, DateTimeKind.Local).AddTicks(1106));

            migrationBuilder.CreateIndex(
                name: "IX_Product_CategoryId",
                table: "Product",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductImages_ProductId",
                table: "ProductImages",
                column: "ProductId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductImages");

            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.UpdateData(
                table: "Blogs",
                keyColumn: "id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 5, 15, 19, 14, 5, 425, DateTimeKind.Local).AddTicks(9880));

            migrationBuilder.UpdateData(
                table: "Blogs",
                keyColumn: "id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 5, 15, 19, 14, 5, 425, DateTimeKind.Local).AddTicks(9881));

            migrationBuilder.UpdateData(
                table: "Blogs",
                keyColumn: "id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 5, 15, 19, 14, 5, 425, DateTimeKind.Local).AddTicks(9882));
        }
    }
}
