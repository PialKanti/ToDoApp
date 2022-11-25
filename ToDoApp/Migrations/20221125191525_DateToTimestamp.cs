using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ToDoApp.Migrations
{
    /// <inheritdoc />
    public partial class DateToTimestamp : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedDateTime",
                table: "ToDoItems");

            migrationBuilder.DropColumn(
                name: "ExpiryDateTime",
                table: "ToDoItems");

            migrationBuilder.AddColumn<int>(
                name: "CreatedTimestamp",
                table: "ToDoItems",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ExpiryTimestamp",
                table: "ToDoItems",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "ToDoItems",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedTimestamp", "ExpiryTimestamp" },
                values: new object[] { 1669403725, 1669104000 });

            migrationBuilder.UpdateData(
                table: "ToDoItems",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedTimestamp", "ExpiryTimestamp" },
                values: new object[] { 1669403725, 1669125600 });

            migrationBuilder.UpdateData(
                table: "ToDoItems",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedTimestamp", "ExpiryTimestamp" },
                values: new object[] { 1669403725, 1669071600 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedTimestamp",
                table: "ToDoItems");

            migrationBuilder.DropColumn(
                name: "ExpiryTimestamp",
                table: "ToDoItems");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDateTime",
                table: "ToDoItems",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "ExpiryDateTime",
                table: "ToDoItems",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "ToDoItems",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDateTime", "ExpiryDateTime" },
                values: new object[] { new DateTime(2022, 11, 21, 14, 26, 36, 366, DateTimeKind.Local).AddTicks(7311), new DateTime(2022, 11, 22, 14, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "ToDoItems",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDateTime", "ExpiryDateTime" },
                values: new object[] { new DateTime(2022, 11, 21, 14, 26, 36, 366, DateTimeKind.Local).AddTicks(7322), new DateTime(2022, 11, 22, 20, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "ToDoItems",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDateTime", "ExpiryDateTime" },
                values: new object[] { new DateTime(2022, 11, 21, 14, 26, 36, 366, DateTimeKind.Local).AddTicks(7323), new DateTime(2022, 11, 22, 5, 0, 0, 0, DateTimeKind.Unspecified) });
        }
    }
}
