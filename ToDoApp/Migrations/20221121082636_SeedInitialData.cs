using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ToDoApp.Migrations
{
    /// <inheritdoc />
    public partial class SeedInitialData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "ToDoItems",
                columns: new[] { "Id", "CreatedDateTime", "Description", "ExpiryDateTime", "Name", "Place" },
                values: new object[,]
                {
                    { 1, new DateTime(2022, 11, 21, 14, 26, 36, 366, DateTimeKind.Local).AddTicks(7311), "This is Task 1.", new DateTime(2022, 11, 22, 14, 0, 0, 0, DateTimeKind.Unspecified), "Task 1", "Dhaka" },
                    { 2, new DateTime(2022, 11, 21, 14, 26, 36, 366, DateTimeKind.Local).AddTicks(7322), "This is Task 2.", new DateTime(2022, 11, 22, 20, 0, 0, 0, DateTimeKind.Unspecified), "Task 2", "Dhaka" },
                    { 3, new DateTime(2022, 11, 21, 14, 26, 36, 366, DateTimeKind.Local).AddTicks(7323), "This is Task 2.", new DateTime(2022, 11, 22, 5, 0, 0, 0, DateTimeKind.Unspecified), "Task 3", "Khulna" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ToDoItems",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ToDoItems",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ToDoItems",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
