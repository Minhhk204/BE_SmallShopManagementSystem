using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BE__Small_Shop_Management_System.Migrations
{
    /// <inheritdoc />
    public partial class addAttributeForUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Users",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

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
                columns: new[] { "Address", "CreatedAt", "IsEmailConfirmed", "PasswordHash" },
                values: new object[] { null, new DateTime(2025, 9, 17, 15, 46, 38, 128, DateTimeKind.Local).AddTicks(6018), true, "$2a$11$revU/7vTSdMI.T57s.hDd.zv2rDva2.6RfU8vWq4zqRt0I9t9DxG." });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Users");

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 16, 4, 11, 9, 425, DateTimeKind.Utc).AddTicks(4558));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 16, 4, 11, 9, 425, DateTimeKind.Utc).AddTicks(4594));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 16, 4, 11, 9, 425, DateTimeKind.Utc).AddTicks(4599));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 16, 4, 11, 9, 425, DateTimeKind.Utc).AddTicks(4606));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 16, 4, 11, 9, 425, DateTimeKind.Utc).AddTicks(4610));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 16, 4, 11, 9, 425, DateTimeKind.Utc).AddTicks(4617));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 16, 4, 11, 9, 425, DateTimeKind.Utc).AddTicks(4630));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 16, 4, 11, 9, 425, DateTimeKind.Utc).AddTicks(4634));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 16, 4, 11, 9, 425, DateTimeKind.Utc).AddTicks(4639));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 16, 4, 11, 9, 425, DateTimeKind.Utc).AddTicks(4644));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 16, 4, 11, 9, 425, DateTimeKind.Utc).AddTicks(4652));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 16, 4, 11, 9, 425, DateTimeKind.Utc).AddTicks(4658));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 16, 4, 11, 9, 425, DateTimeKind.Utc).AddTicks(4668));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 16, 4, 11, 9, 425, DateTimeKind.Utc).AddTicks(4674));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 16, 4, 11, 9, 425, DateTimeKind.Utc).AddTicks(4682));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 16, 4, 11, 9, 425, DateTimeKind.Utc).AddTicks(4687));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 16, 4, 11, 9, 425, DateTimeKind.Utc).AddTicks(4705));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 16, 4, 11, 9, 425, DateTimeKind.Utc).AddTicks(4711));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 16, 4, 11, 9, 425, DateTimeKind.Utc).AddTicks(4717));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 16, 4, 11, 9, 425, DateTimeKind.Utc).AddTicks(4722));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 16, 4, 11, 9, 425, DateTimeKind.Utc).AddTicks(4726));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 16, 4, 11, 9, 425, DateTimeKind.Utc).AddTicks(4734));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 16, 4, 11, 9, 425, DateTimeKind.Utc).AddTicks(4739));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 16, 4, 11, 9, 425, DateTimeKind.Utc).AddTicks(4774));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "IsEmailConfirmed", "PasswordHash" },
                values: new object[] { false, "$2a$11$Eo5FpcYiuPmnezmTQ8ipheVCX9oc32RfWqOn4qM4GBEj8po9Y7cMy" });
        }
    }
}
