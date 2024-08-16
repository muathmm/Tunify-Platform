using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tunify_Platform.Migrations
{
    /// <inheritdoc />
    public partial class updateRelationsjship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "PlayLists",
                keyColumn: "PlayListId",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 16, 21, 33, 39, 769, DateTimeKind.Local).AddTicks(9310));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "PlayLists",
                keyColumn: "PlayListId",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 6, 22, 0, 17, 239, DateTimeKind.Local).AddTicks(9542));
        }
    }
}
