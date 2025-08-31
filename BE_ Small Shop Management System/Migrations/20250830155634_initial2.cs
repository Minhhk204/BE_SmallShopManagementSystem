using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BE__Small_Shop_Management_System.Migrations
{
    /// <inheritdoc />
    public partial class initial2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserName",
                table: "SystemLogs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 30, 15, 56, 32, 537, DateTimeKind.Utc).AddTicks(7919));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 30, 15, 56, 32, 537, DateTimeKind.Utc).AddTicks(7965));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 30, 15, 56, 32, 537, DateTimeKind.Utc).AddTicks(7971));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 30, 15, 56, 32, 537, DateTimeKind.Utc).AddTicks(7978));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 30, 15, 56, 32, 537, DateTimeKind.Utc).AddTicks(7983));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 30, 15, 56, 32, 537, DateTimeKind.Utc).AddTicks(7989));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 30, 15, 56, 32, 537, DateTimeKind.Utc).AddTicks(8000));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 30, 15, 56, 32, 537, DateTimeKind.Utc).AddTicks(8005));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 30, 15, 56, 32, 537, DateTimeKind.Utc).AddTicks(8010));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 30, 15, 56, 32, 537, DateTimeKind.Utc).AddTicks(8016));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 30, 15, 56, 32, 537, DateTimeKind.Utc).AddTicks(8023));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 30, 15, 56, 32, 537, DateTimeKind.Utc).AddTicks(8035));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 30, 15, 56, 32, 537, DateTimeKind.Utc).AddTicks(8040));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 30, 15, 56, 32, 537, DateTimeKind.Utc).AddTicks(8045));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 30, 15, 56, 32, 537, DateTimeKind.Utc).AddTicks(8055));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 30, 15, 56, 32, 537, DateTimeKind.Utc).AddTicks(8064));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 30, 15, 56, 32, 537, DateTimeKind.Utc).AddTicks(8070));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 30, 15, 56, 32, 537, DateTimeKind.Utc).AddTicks(8076));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 30, 15, 56, 32, 537, DateTimeKind.Utc).AddTicks(8082));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 30, 15, 56, 32, 537, DateTimeKind.Utc).AddTicks(8093));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 30, 15, 56, 32, 537, DateTimeKind.Utc).AddTicks(8098));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 30, 15, 56, 32, 537, DateTimeKind.Utc).AddTicks(8102));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 30, 15, 56, 32, 537, DateTimeKind.Utc).AddTicks(8106));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 30, 15, 56, 32, 537, DateTimeKind.Utc).AddTicks(8110));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 25,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 30, 15, 56, 32, 537, DateTimeKind.Utc).AddTicks(8145));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 26,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 30, 15, 56, 32, 537, DateTimeKind.Utc).AddTicks(8151));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 27,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 30, 15, 56, 32, 537, DateTimeKind.Utc).AddTicks(8163));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "PasswordHash",
                value: "$2a$11$d9O0Hx4KwvyYh0mLVK4h5.5WOcafrI6yv3HlnBN0FQBWSEPryFddi");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserName",
                table: "SystemLogs");

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 29, 15, 29, 50, 409, DateTimeKind.Utc).AddTicks(5881));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 29, 15, 29, 50, 409, DateTimeKind.Utc).AddTicks(5923));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 29, 15, 29, 50, 409, DateTimeKind.Utc).AddTicks(5939));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 29, 15, 29, 50, 409, DateTimeKind.Utc).AddTicks(6005));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 29, 15, 29, 50, 409, DateTimeKind.Utc).AddTicks(6013));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 29, 15, 29, 50, 409, DateTimeKind.Utc).AddTicks(6021));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 29, 15, 29, 50, 409, DateTimeKind.Utc).AddTicks(6035));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 29, 15, 29, 50, 409, DateTimeKind.Utc).AddTicks(6042));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 29, 15, 29, 50, 409, DateTimeKind.Utc).AddTicks(6050));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 29, 15, 29, 50, 409, DateTimeKind.Utc).AddTicks(6058));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 29, 15, 29, 50, 409, DateTimeKind.Utc).AddTicks(6066));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 29, 15, 29, 50, 409, DateTimeKind.Utc).AddTicks(6085));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 29, 15, 29, 50, 409, DateTimeKind.Utc).AddTicks(6092));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 29, 15, 29, 50, 409, DateTimeKind.Utc).AddTicks(6099));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 29, 15, 29, 50, 409, DateTimeKind.Utc).AddTicks(6112));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 29, 15, 29, 50, 409, DateTimeKind.Utc).AddTicks(6122));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 29, 15, 29, 50, 409, DateTimeKind.Utc).AddTicks(6130));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 29, 15, 29, 50, 409, DateTimeKind.Utc).AddTicks(6139));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 29, 15, 29, 50, 409, DateTimeKind.Utc).AddTicks(6146));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 29, 15, 29, 50, 409, DateTimeKind.Utc).AddTicks(6162));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 29, 15, 29, 50, 409, DateTimeKind.Utc).AddTicks(6167));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 29, 15, 29, 50, 409, DateTimeKind.Utc).AddTicks(6173));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 29, 15, 29, 50, 409, DateTimeKind.Utc).AddTicks(6179));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 29, 15, 29, 50, 409, DateTimeKind.Utc).AddTicks(6185));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 25,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 29, 15, 29, 50, 409, DateTimeKind.Utc).AddTicks(6194));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 26,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 29, 15, 29, 50, 409, DateTimeKind.Utc).AddTicks(6202));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 27,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 29, 15, 29, 50, 409, DateTimeKind.Utc).AddTicks(6254));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "PasswordHash",
                value: "$2a$11$8FIbWQVzUHeNix2HYTUQn.cQAPvRSMkViHMZrEfK1XZPUzx1ELe6W");
        }
    }
}
