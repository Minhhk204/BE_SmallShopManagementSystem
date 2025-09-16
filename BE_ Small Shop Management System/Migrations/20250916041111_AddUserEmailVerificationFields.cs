using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BE__Small_Shop_Management_System.Migrations
{
    /// <inheritdoc />
    public partial class AddUserEmailVerificationFields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsEmailConfirmed",
                table: "Users",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "VerificationCode",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "VerificationExpiry",
                table: "Users",
                type: "datetime2",
                nullable: true);

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
                columns: new[] { "IsEmailConfirmed", "PasswordHash", "VerificationCode", "VerificationExpiry" },
                values: new object[] { false, "$2a$11$Eo5FpcYiuPmnezmTQ8ipheVCX9oc32RfWqOn4qM4GBEj8po9Y7cMy", null, null });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsEmailConfirmed",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "VerificationCode",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "VerificationExpiry",
                table: "Users");

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 11, 9, 19, 49, 913, DateTimeKind.Utc).AddTicks(3594));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 11, 9, 19, 49, 913, DateTimeKind.Utc).AddTicks(3636));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 11, 9, 19, 49, 913, DateTimeKind.Utc).AddTicks(3642));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 11, 9, 19, 49, 913, DateTimeKind.Utc).AddTicks(3651));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 11, 9, 19, 49, 913, DateTimeKind.Utc).AddTicks(3657));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 11, 9, 19, 49, 913, DateTimeKind.Utc).AddTicks(3663));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 11, 9, 19, 49, 913, DateTimeKind.Utc).AddTicks(3672));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 11, 9, 19, 49, 913, DateTimeKind.Utc).AddTicks(3678));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 11, 9, 19, 49, 913, DateTimeKind.Utc).AddTicks(3682));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 11, 9, 19, 49, 913, DateTimeKind.Utc).AddTicks(3687));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 11, 9, 19, 49, 913, DateTimeKind.Utc).AddTicks(3696));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 11, 9, 19, 49, 913, DateTimeKind.Utc).AddTicks(3704));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 11, 9, 19, 49, 913, DateTimeKind.Utc).AddTicks(3714));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 11, 9, 19, 49, 913, DateTimeKind.Utc).AddTicks(3720));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 11, 9, 19, 49, 913, DateTimeKind.Utc).AddTicks(3731));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 11, 9, 19, 49, 913, DateTimeKind.Utc).AddTicks(3736));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 11, 9, 19, 49, 913, DateTimeKind.Utc).AddTicks(3750));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 11, 9, 19, 49, 913, DateTimeKind.Utc).AddTicks(3755));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 11, 9, 19, 49, 913, DateTimeKind.Utc).AddTicks(3760));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 11, 9, 19, 49, 913, DateTimeKind.Utc).AddTicks(3765));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 11, 9, 19, 49, 913, DateTimeKind.Utc).AddTicks(3772));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 11, 9, 19, 49, 913, DateTimeKind.Utc).AddTicks(3815));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 11, 9, 19, 49, 913, DateTimeKind.Utc).AddTicks(3820));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 11, 9, 19, 49, 913, DateTimeKind.Utc).AddTicks(3826));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "PasswordHash",
                value: "$2a$11$0ZAsYWlnI2hsKEB.x34tH.Vntn2ckfO69saE/gyAcjWBsGYBbzSS6");
        }
    }
}
