using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ToDoApp.Migrations
{
    /// <inheritdoc />
    public partial class TimestampLongDataType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<long>(
                name: "ExpiryTimestamp",
                table: "ToDoItems",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<long>(
                name: "CreatedTimestamp",
                table: "ToDoItems",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "ToDoItems",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedTimestamp", "ExpiryTimestamp" },
                values: new object[] { 1669406826L, 1669104000L });

            migrationBuilder.UpdateData(
                table: "ToDoItems",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedTimestamp", "ExpiryTimestamp" },
                values: new object[] { 1669406826L, 1669125600L });

            migrationBuilder.UpdateData(
                table: "ToDoItems",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedTimestamp", "ExpiryTimestamp" },
                values: new object[] { 1669406826L, 1669071600L });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "ExpiryTimestamp",
                table: "ToDoItems",
                type: "int",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<int>(
                name: "CreatedTimestamp",
                table: "ToDoItems",
                type: "int",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

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
    }
}
