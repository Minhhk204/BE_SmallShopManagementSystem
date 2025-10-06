using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BE__Small_Shop_Management_System.Migrations
{
    /// <inheritdoc />
    public partial class fixtableProduct : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Products",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 6, 9, 25, 59, 956, DateTimeKind.Utc).AddTicks(6732));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 6, 9, 25, 59, 956, DateTimeKind.Utc).AddTicks(6869));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 6, 9, 25, 59, 956, DateTimeKind.Utc).AddTicks(6880));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 6, 9, 25, 59, 956, DateTimeKind.Utc).AddTicks(6890));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 6, 9, 25, 59, 956, DateTimeKind.Utc).AddTicks(6900));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 6, 9, 25, 59, 956, DateTimeKind.Utc).AddTicks(6910));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 6, 9, 25, 59, 956, DateTimeKind.Utc).AddTicks(6924));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 6, 9, 25, 59, 956, DateTimeKind.Utc).AddTicks(6936));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 6, 9, 25, 59, 956, DateTimeKind.Utc).AddTicks(6952));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 6, 9, 25, 59, 956, DateTimeKind.Utc).AddTicks(6963));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 6, 9, 25, 59, 956, DateTimeKind.Utc).AddTicks(6975));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 6, 9, 25, 59, 956, DateTimeKind.Utc).AddTicks(6986));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 6, 9, 25, 59, 956, DateTimeKind.Utc).AddTicks(7001));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 6, 9, 25, 59, 956, DateTimeKind.Utc).AddTicks(7012));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 6, 9, 25, 59, 956, DateTimeKind.Utc).AddTicks(7026));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 6, 9, 25, 59, 956, DateTimeKind.Utc).AddTicks(7086));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 6, 9, 25, 59, 956, DateTimeKind.Utc).AddTicks(7172));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 6, 9, 25, 59, 956, DateTimeKind.Utc).AddTicks(7183));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 6, 9, 25, 59, 956, DateTimeKind.Utc).AddTicks(7195));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 6, 9, 25, 59, 956, DateTimeKind.Utc).AddTicks(7206));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 6, 9, 25, 59, 956, DateTimeKind.Utc).AddTicks(7216));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 6, 9, 25, 59, 956, DateTimeKind.Utc).AddTicks(7229));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 6, 9, 25, 59, 956, DateTimeKind.Utc).AddTicks(7239));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 6, 9, 25, 59, 956, DateTimeKind.Utc).AddTicks(7248));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "PasswordHash" },
                values: new object[] { new DateTime(2025, 10, 6, 16, 25, 59, 956, DateTimeKind.Local).AddTicks(7690), "$2a$11$Kpo3S1Qxn.GarLWOtulzEOQtAGlrGpDMb3pvHEZLPTYZIqh6uayAu" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Products");

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 6, 2, 51, 29, 172, DateTimeKind.Utc).AddTicks(3640));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 6, 2, 51, 29, 172, DateTimeKind.Utc).AddTicks(3672));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 6, 2, 51, 29, 172, DateTimeKind.Utc).AddTicks(3681));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 6, 2, 51, 29, 172, DateTimeKind.Utc).AddTicks(3728));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 6, 2, 51, 29, 172, DateTimeKind.Utc).AddTicks(3735));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 6, 2, 51, 29, 172, DateTimeKind.Utc).AddTicks(3749));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 6, 2, 51, 29, 172, DateTimeKind.Utc).AddTicks(3761));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 6, 2, 51, 29, 172, DateTimeKind.Utc).AddTicks(3768));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 6, 2, 51, 29, 172, DateTimeKind.Utc).AddTicks(3776));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 6, 2, 51, 29, 172, DateTimeKind.Utc).AddTicks(3784));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 6, 2, 51, 29, 172, DateTimeKind.Utc).AddTicks(3793));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 6, 2, 51, 29, 172, DateTimeKind.Utc).AddTicks(3803));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 6, 2, 51, 29, 172, DateTimeKind.Utc).AddTicks(3812));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 6, 2, 51, 29, 172, DateTimeKind.Utc).AddTicks(3819));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 6, 2, 51, 29, 172, DateTimeKind.Utc).AddTicks(3830));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 6, 2, 51, 29, 172, DateTimeKind.Utc).AddTicks(3837));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 6, 2, 51, 29, 172, DateTimeKind.Utc).AddTicks(3851));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 6, 2, 51, 29, 172, DateTimeKind.Utc).AddTicks(3859));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 6, 2, 51, 29, 172, DateTimeKind.Utc).AddTicks(3866));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 6, 2, 51, 29, 172, DateTimeKind.Utc).AddTicks(3873));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 6, 2, 51, 29, 172, DateTimeKind.Utc).AddTicks(3880));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 6, 2, 51, 29, 172, DateTimeKind.Utc).AddTicks(3890));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 6, 2, 51, 29, 172, DateTimeKind.Utc).AddTicks(3897));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 6, 2, 51, 29, 172, DateTimeKind.Utc).AddTicks(3935));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "PasswordHash" },
                values: new object[] { new DateTime(2025, 10, 6, 9, 51, 29, 172, DateTimeKind.Local).AddTicks(4241), "$2a$11$QuWJW7C4pxx50CXFk3eG4OCyLnpOi/8v88xXUauXg3xBpuAS09HKC" });
        }
    }
}
