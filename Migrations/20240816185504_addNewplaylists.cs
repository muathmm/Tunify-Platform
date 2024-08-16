using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Tunify_Platform.Migrations
{
    /// <inheritdoc />
    public partial class addNewplaylists : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "PlayLists",
                keyColumn: "PlayListId",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 16, 21, 55, 3, 846, DateTimeKind.Local).AddTicks(3949));

            migrationBuilder.InsertData(
                table: "PlayLists",
                columns: new[] { "PlayListId", "CreatedDate", "PlayListName", "UserId" },
                values: new object[,]
                {
                    { 2, new DateTime(2024, 8, 16, 21, 55, 3, 846, DateTimeKind.Local).AddTicks(3968), "My Favorites", 2 },
                    { 3, new DateTime(2024, 8, 16, 21, 55, 3, 846, DateTimeKind.Local).AddTicks(3969), "My Favorites", 1 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "PlayLists",
                keyColumn: "PlayListId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "PlayLists",
                keyColumn: "PlayListId",
                keyValue: 3);

            migrationBuilder.UpdateData(
                table: "PlayLists",
                keyColumn: "PlayListId",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 16, 21, 33, 39, 769, DateTimeKind.Local).AddTicks(9310));
        }
    }
}
