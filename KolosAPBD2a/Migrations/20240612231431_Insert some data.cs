using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KolosAPBD2a.Migrations
{
    /// <inheritdoc />
    public partial class Insertsomedata : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "characters",
                columns: new[] { "Id", "CurrentWeight", "FirstName", "LastName", "MaxWeight" },
                values: new object[] { 1, 100, "Patryk", "Rozgwiazda", 200 });

            migrationBuilder.InsertData(
                table: "items",
                columns: new[] { "Id", "Name", "Weight" },
                values: new object[] { 1, "Kredka", 2 });

            migrationBuilder.InsertData(
                table: "titles",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "Gwiazda" });

            migrationBuilder.InsertData(
                table: "backpacks",
                columns: new[] { "CharacterId", "ItemId", "Amount" },
                values: new object[] { 1, 1, 5 });

            migrationBuilder.InsertData(
                table: "character_titles",
                columns: new[] { "CharacterId", "Title", "AcquiredAt" },
                values: new object[] { 1, 1, new DateTime(2024, 6, 13, 1, 14, 30, 743, DateTimeKind.Local).AddTicks(8114) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "backpacks",
                keyColumns: new[] { "CharacterId", "ItemId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "character_titles",
                keyColumns: new[] { "CharacterId", "Title" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "characters",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "items",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "titles",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
