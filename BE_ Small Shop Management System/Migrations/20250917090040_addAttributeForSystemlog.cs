using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BE__Small_Shop_Management_System.Migrations
{
    /// <inheritdoc />
    public partial class addAttributeForSystemlog : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ApplicationName",
                table: "SystemLogs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<double>(
                name: "Duration",
                table: "SystemLogs",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 17, 9, 0, 39, 91, DateTimeKind.Utc).AddTicks(9415));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 17, 9, 0, 39, 91, DateTimeKind.Utc).AddTicks(9449));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 17, 9, 0, 39, 91, DateTimeKind.Utc).AddTicks(9458));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 17, 9, 0, 39, 91, DateTimeKind.Utc).AddTicks(9462));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 17, 9, 0, 39, 91, DateTimeKind.Utc).AddTicks(9467));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 17, 9, 0, 39, 91, DateTimeKind.Utc).AddTicks(9475));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 17, 9, 0, 39, 91, DateTimeKind.Utc).AddTicks(9490));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 17, 9, 0, 39, 91, DateTimeKind.Utc).AddTicks(9494));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 17, 9, 0, 39, 91, DateTimeKind.Utc).AddTicks(9498));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 17, 9, 0, 39, 91, DateTimeKind.Utc).AddTicks(9503));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 17, 9, 0, 39, 91, DateTimeKind.Utc).AddTicks(9510));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 17, 9, 0, 39, 91, DateTimeKind.Utc).AddTicks(9515));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 17, 9, 0, 39, 91, DateTimeKind.Utc).AddTicks(9520));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 17, 9, 0, 39, 91, DateTimeKind.Utc).AddTicks(9526));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 17, 9, 0, 39, 91, DateTimeKind.Utc).AddTicks(9569));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 17, 9, 0, 39, 91, DateTimeKind.Utc).AddTicks(9573));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 17, 9, 0, 39, 91, DateTimeKind.Utc).AddTicks(9581));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 17, 9, 0, 39, 91, DateTimeKind.Utc).AddTicks(9585));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 17, 9, 0, 39, 91, DateTimeKind.Utc).AddTicks(9588));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 17, 9, 0, 39, 91, DateTimeKind.Utc).AddTicks(9591));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 17, 9, 0, 39, 91, DateTimeKind.Utc).AddTicks(9594));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 17, 9, 0, 39, 91, DateTimeKind.Utc).AddTicks(9598));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 17, 9, 0, 39, 91, DateTimeKind.Utc).AddTicks(9603));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 17, 9, 0, 39, 91, DateTimeKind.Utc).AddTicks(9609));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "PasswordHash" },
                values: new object[] { new DateTime(2025, 9, 17, 16, 0, 39, 91, DateTimeKind.Local).AddTicks(9897), "$2a$11$6qXy20Dg0akj4IBXg8K5suSkcFH43oilvnDYzyLT/Dm8NyzQYsnQe" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ApplicationName",
                table: "SystemLogs");

            migrationBuilder.DropColumn(
                name: "Duration",
                table: "SystemLogs");

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 17, 8, 46, 38, 128, DateTimeKind.Utc).AddTicks(5375));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 17, 8, 46, 38, 128, DateTimeKind.Utc).AddTicks(5426));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 17, 8, 46, 38, 128, DateTimeKind.Utc).AddTicks(5436));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 17, 8, 46, 38, 128, DateTimeKind.Utc).AddTicks(5441));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 17, 8, 46, 38, 128, DateTimeKind.Utc).AddTicks(5446));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 17, 8, 46, 38, 128, DateTimeKind.Utc).AddTicks(5455));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 17, 8, 46, 38, 128, DateTimeKind.Utc).AddTicks(5475));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 17, 8, 46, 38, 128, DateTimeKind.Utc).AddTicks(5480));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 17, 8, 46, 38, 128, DateTimeKind.Utc).AddTicks(5484));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 17, 8, 46, 38, 128, DateTimeKind.Utc).AddTicks(5489));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 17, 8, 46, 38, 128, DateTimeKind.Utc).AddTicks(5497));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 17, 8, 46, 38, 128, DateTimeKind.Utc).AddTicks(5505));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 17, 8, 46, 38, 128, DateTimeKind.Utc).AddTicks(5514));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 17, 8, 46, 38, 128, DateTimeKind.Utc).AddTicks(5520));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 17, 8, 46, 38, 128, DateTimeKind.Utc).AddTicks(5529));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 17, 8, 46, 38, 128, DateTimeKind.Utc).AddTicks(5578));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 17, 8, 46, 38, 128, DateTimeKind.Utc).AddTicks(5593));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 17, 8, 46, 38, 128, DateTimeKind.Utc).AddTicks(5598));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 17, 8, 46, 38, 128, DateTimeKind.Utc).AddTicks(5603));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 17, 8, 46, 38, 128, DateTimeKind.Utc).AddTicks(5609));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 17, 8, 46, 38, 128, DateTimeKind.Utc).AddTicks(5613));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 17, 8, 46, 38, 128, DateTimeKind.Utc).AddTicks(5620));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 17, 8, 46, 38, 128, DateTimeKind.Utc).AddTicks(5624));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 17, 8, 46, 38, 128, DateTimeKind.Utc).AddTicks(5631));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "PasswordHash" },
                values: new object[] { new DateTime(2025, 9, 17, 15, 46, 38, 128, DateTimeKind.Local).AddTicks(6018), "$2a$11$revU/7vTSdMI.T57s.hDd.zv2rDva2.6RfU8vWq4zqRt0I9t9DxG." });
        }
    }
}
