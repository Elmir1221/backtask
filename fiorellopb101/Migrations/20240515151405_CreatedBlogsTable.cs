using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace fiorellopb101.Migrations
{
    public partial class CreatedBlogsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Blog",
                table: "Blog");

            migrationBuilder.RenameTable(
                name: "Blog",
                newName: "Blogs");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Blogs",
                table: "Blogs",
                column: "id");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Blogs",
                table: "Blogs");

            migrationBuilder.RenameTable(
                name: "Blogs",
                newName: "Blog");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Blog",
                table: "Blog",
                column: "id");

            migrationBuilder.UpdateData(
                table: "Blog",
                keyColumn: "id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 5, 15, 18, 18, 20, 557, DateTimeKind.Local).AddTicks(1073));

            migrationBuilder.UpdateData(
                table: "Blog",
                keyColumn: "id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 5, 15, 18, 18, 20, 557, DateTimeKind.Local).AddTicks(1074));

            migrationBuilder.UpdateData(
                table: "Blog",
                keyColumn: "id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 5, 15, 18, 18, 20, 557, DateTimeKind.Local).AddTicks(1075));
        }
    }
}
