using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tunify_Platform.Migrations
{
    /// <inheritdoc />
    public partial class updateAplicationUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "createdAt",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "token",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "PlayLists",
                keyColumn: "PlayListId",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 28, 15, 0, 43, 804, DateTimeKind.Local).AddTicks(4754));

            migrationBuilder.UpdateData(
                table: "PlayLists",
                keyColumn: "PlayListId",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 28, 15, 0, 43, 804, DateTimeKind.Local).AddTicks(4770));

            migrationBuilder.UpdateData(
                table: "PlayLists",
                keyColumn: "PlayListId",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 28, 15, 0, 43, 804, DateTimeKind.Local).AddTicks(4772));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "createdAt",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "token",
                table: "AspNetUsers");

            migrationBuilder.UpdateData(
                table: "PlayLists",
                keyColumn: "PlayListId",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 23, 22, 55, 46, 152, DateTimeKind.Local).AddTicks(2875));

            migrationBuilder.UpdateData(
                table: "PlayLists",
                keyColumn: "PlayListId",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 23, 22, 55, 46, 152, DateTimeKind.Local).AddTicks(2890));

            migrationBuilder.UpdateData(
                table: "PlayLists",
                keyColumn: "PlayListId",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 23, 22, 55, 46, 152, DateTimeKind.Local).AddTicks(2891));
        }
    }
}
