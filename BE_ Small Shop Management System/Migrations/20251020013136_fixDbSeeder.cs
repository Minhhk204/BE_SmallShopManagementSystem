using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BE__Small_Shop_Management_System.Migrations
{
    /// <inheritdoc />
    public partial class fixDbSeeder : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { 32, 1 });

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 20, 1, 31, 34, 311, DateTimeKind.Utc).AddTicks(9340));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 20, 1, 31, 34, 311, DateTimeKind.Utc).AddTicks(9488));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 20, 1, 31, 34, 311, DateTimeKind.Utc).AddTicks(9510));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 20, 1, 31, 34, 311, DateTimeKind.Utc).AddTicks(9526));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 20, 1, 31, 34, 311, DateTimeKind.Utc).AddTicks(9541));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 20, 1, 31, 34, 311, DateTimeKind.Utc).AddTicks(9651));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 20, 1, 31, 34, 311, DateTimeKind.Utc).AddTicks(9679));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 20, 1, 31, 34, 311, DateTimeKind.Utc).AddTicks(9695));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 20, 1, 31, 34, 311, DateTimeKind.Utc).AddTicks(9717));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 20, 1, 31, 34, 311, DateTimeKind.Utc).AddTicks(9734));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 20, 1, 31, 34, 311, DateTimeKind.Utc).AddTicks(9754));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 20, 1, 31, 34, 311, DateTimeKind.Utc).AddTicks(9770));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 20, 1, 31, 34, 311, DateTimeKind.Utc).AddTicks(9789));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 20, 1, 31, 34, 311, DateTimeKind.Utc).AddTicks(9806));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 20, 1, 31, 34, 311, DateTimeKind.Utc).AddTicks(9830));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 20, 1, 31, 34, 311, DateTimeKind.Utc).AddTicks(9868));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 20, 1, 31, 34, 311, DateTimeKind.Utc).AddTicks(9891));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 20, 1, 31, 34, 311, DateTimeKind.Utc).AddTicks(9907));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 20, 1, 31, 34, 311, DateTimeKind.Utc).AddTicks(9922));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 20, 1, 31, 34, 311, DateTimeKind.Utc).AddTicks(9938));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 20, 1, 31, 34, 311, DateTimeKind.Utc).AddTicks(9959));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 20, 1, 31, 34, 311, DateTimeKind.Utc).AddTicks(9971));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 20, 1, 31, 34, 311, DateTimeKind.Utc).AddTicks(9984));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 20, 1, 31, 34, 311, DateTimeKind.Utc).AddTicks(9998));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 25,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 20, 1, 31, 34, 312, DateTimeKind.Utc).AddTicks(17));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 26,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 20, 1, 31, 34, 312, DateTimeKind.Utc).AddTicks(78));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 27,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 20, 1, 31, 34, 312, DateTimeKind.Utc).AddTicks(99));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 28,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 20, 1, 31, 34, 312, DateTimeKind.Utc).AddTicks(112));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 29,
                columns: new[] { "CreatedAt", "Description", "Module", "Name" },
                values: new object[] { new DateTime(2025, 10, 20, 1, 31, 34, 312, DateTimeKind.Utc).AddTicks(127), "Xem sản phẩm yêu thích", "Sản phẩm yêu thích", "Favorites.View" });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 30,
                columns: new[] { "CreatedAt", "Description", "Name" },
                values: new object[] { new DateTime(2025, 10, 20, 1, 31, 34, 312, DateTimeKind.Utc).AddTicks(168), "Thêm sản phẩm yêu thích", "Favorites.Create" });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 31,
                columns: new[] { "CreatedAt", "Description", "Name" },
                values: new object[] { new DateTime(2025, 10, 20, 1, 31, 34, 312, DateTimeKind.Utc).AddTicks(184), "Xóa sản phẩm yêu thích", "Favorites.Delete" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "PasswordHash" },
                values: new object[] { new DateTime(2025, 10, 20, 8, 31, 34, 312, DateTimeKind.Local).AddTicks(737), "$2a$11$9dJENUagOul7GoABcQY2bOLI/n2Nnz6BFQtgUN.z76pb/jqXFPWEq" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 18, 18, 48, 12, 540, DateTimeKind.Utc).AddTicks(3848));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 18, 18, 48, 12, 540, DateTimeKind.Utc).AddTicks(3879));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 18, 18, 48, 12, 540, DateTimeKind.Utc).AddTicks(3885));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 18, 18, 48, 12, 540, DateTimeKind.Utc).AddTicks(3890));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 18, 18, 48, 12, 540, DateTimeKind.Utc).AddTicks(3895));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 18, 18, 48, 12, 540, DateTimeKind.Utc).AddTicks(3901));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 18, 18, 48, 12, 540, DateTimeKind.Utc).AddTicks(3909));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 18, 18, 48, 12, 540, DateTimeKind.Utc).AddTicks(3914));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 18, 18, 48, 12, 540, DateTimeKind.Utc).AddTicks(3952));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 18, 18, 48, 12, 540, DateTimeKind.Utc).AddTicks(3958));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 18, 18, 48, 12, 540, DateTimeKind.Utc).AddTicks(3966));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 18, 18, 48, 12, 540, DateTimeKind.Utc).AddTicks(3972));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 18, 18, 48, 12, 540, DateTimeKind.Utc).AddTicks(3978));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 18, 18, 48, 12, 540, DateTimeKind.Utc).AddTicks(3983));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 18, 18, 48, 12, 540, DateTimeKind.Utc).AddTicks(3988));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 18, 18, 48, 12, 540, DateTimeKind.Utc).AddTicks(3992));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 18, 18, 48, 12, 540, DateTimeKind.Utc).AddTicks(3999));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 18, 18, 48, 12, 540, DateTimeKind.Utc).AddTicks(4004));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 18, 18, 48, 12, 540, DateTimeKind.Utc).AddTicks(4008));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 18, 18, 48, 12, 540, DateTimeKind.Utc).AddTicks(4012));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 18, 18, 48, 12, 540, DateTimeKind.Utc).AddTicks(4020));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 18, 18, 48, 12, 540, DateTimeKind.Utc).AddTicks(4024));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 18, 18, 48, 12, 540, DateTimeKind.Utc).AddTicks(4027));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 18, 18, 48, 12, 540, DateTimeKind.Utc).AddTicks(4030));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 25,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 18, 18, 48, 12, 540, DateTimeKind.Utc).AddTicks(4035));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 26,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 18, 18, 48, 12, 540, DateTimeKind.Utc).AddTicks(4040));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 27,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 18, 18, 48, 12, 540, DateTimeKind.Utc).AddTicks(4044));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 28,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 18, 18, 48, 12, 540, DateTimeKind.Utc).AddTicks(4049));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 29,
                columns: new[] { "CreatedAt", "Description", "Module", "Name" },
                values: new object[] { new DateTime(2025, 10, 18, 18, 48, 12, 540, DateTimeKind.Utc).AddTicks(4082), "Xem lịch sử hệ thống", "Lịch sử hệ thống", "SystemLogs.View" });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 30,
                columns: new[] { "CreatedAt", "Description", "Name" },
                values: new object[] { new DateTime(2025, 10, 18, 18, 48, 12, 540, DateTimeKind.Utc).AddTicks(4088), "Xem sản phẩm yêu thích", "Favorites.View" });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 31,
                columns: new[] { "CreatedAt", "Description", "Name" },
                values: new object[] { new DateTime(2025, 10, 18, 18, 48, 12, 540, DateTimeKind.Utc).AddTicks(4092), "Thêm sản phẩm yêu thích", "Favorites.Create" });

            migrationBuilder.InsertData(
                table: "Permissions",
                columns: new[] { "Id", "CreatedAt", "Description", "Module", "Name", "UpdatedAt" },
                values: new object[] { 32, new DateTime(2025, 10, 18, 18, 48, 12, 540, DateTimeKind.Utc).AddTicks(4096), "Xóa sản phẩm yêu thích", "Sản phẩm yêu thích", "Favorites.Delete", null });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "PasswordHash" },
                values: new object[] { new DateTime(2025, 10, 19, 1, 48, 12, 540, DateTimeKind.Local).AddTicks(4414), "$2a$11$7J6ahoVOFlVcLUAM4BixOeg/9vYrJLQJ17Xg.Ju1FFBqpEcz4kdq6" });

            migrationBuilder.InsertData(
                table: "RolePermissions",
                columns: new[] { "PermissionId", "RoleId" },
                values: new object[] { 32, 1 });
        }
    }
}
