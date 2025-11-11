using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BE__Small_Shop_Management_System.Migrations
{
    /// <inheritdoc />
    public partial class updatePermissionContant : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Payments_Orders_OrderId",
                table: "Payments");

            migrationBuilder.DropIndex(
                name: "IX_Payments_OrderId",
                table: "Payments");

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
                columns: new[] { "CreatedAt", "Description", "Module", "Name" },
                values: new object[] { new DateTime(2025, 10, 18, 18, 48, 12, 540, DateTimeKind.Utc).AddTicks(4020), "Xem giỏ hàng", "Giỏ hàng", "Cart.View" });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 22,
                columns: new[] { "CreatedAt", "Description", "Module", "Name" },
                values: new object[] { new DateTime(2025, 10, 18, 18, 48, 12, 540, DateTimeKind.Utc).AddTicks(4024), "Thêm sản phẩm vào giỏ hàng", "Giỏ hàng", "Cart.Create" });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 23,
                columns: new[] { "CreatedAt", "Description", "Module", "Name" },
                values: new object[] { new DateTime(2025, 10, 18, 18, 48, 12, 540, DateTimeKind.Utc).AddTicks(4027), "Cập nhật giỏ hàng", "Giỏ hàng", "Cart.Update" });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 24,
                columns: new[] { "CreatedAt", "Description", "Module", "Name" },
                values: new object[] { new DateTime(2025, 10, 18, 18, 48, 12, 540, DateTimeKind.Utc).AddTicks(4030), "Xóa sản phẩm khỏi giỏ hàng", "Giỏ hàng", "Cart.Delete" });

            migrationBuilder.InsertData(
                table: "Permissions",
                columns: new[] { "Id", "CreatedAt", "Description", "Module", "Name", "UpdatedAt" },
                values: new object[,]
                {
                    { 25, new DateTime(2025, 10, 18, 18, 48, 12, 540, DateTimeKind.Utc).AddTicks(4035), "Xem danh mục", "Danh mục", "Categories.View", null },
                    { 26, new DateTime(2025, 10, 18, 18, 48, 12, 540, DateTimeKind.Utc).AddTicks(4040), "Tạo danh mục", "Danh mục", "Categories.Create", null },
                    { 27, new DateTime(2025, 10, 18, 18, 48, 12, 540, DateTimeKind.Utc).AddTicks(4044), "Cập nhật danh mục", "Danh mục", "Categories.Update", null },
                    { 28, new DateTime(2025, 10, 18, 18, 48, 12, 540, DateTimeKind.Utc).AddTicks(4049), "Xóa danh mục", "Danh mục", "Categories.Delete", null },
                    { 29, new DateTime(2025, 10, 18, 18, 48, 12, 540, DateTimeKind.Utc).AddTicks(4082), "Xem lịch sử hệ thống", "Lịch sử hệ thống", "SystemLogs.View", null },
                    { 30, new DateTime(2025, 10, 18, 18, 48, 12, 540, DateTimeKind.Utc).AddTicks(4088), "Xem sản phẩm yêu thích", "Sản phẩm yêu thích", "Favorites.View", null },
                    { 31, new DateTime(2025, 10, 18, 18, 48, 12, 540, DateTimeKind.Utc).AddTicks(4092), "Thêm sản phẩm yêu thích", "Sản phẩm yêu thích", "Favorites.Create", null },
                    { 32, new DateTime(2025, 10, 18, 18, 48, 12, 540, DateTimeKind.Utc).AddTicks(4096), "Xóa sản phẩm yêu thích", "Sản phẩm yêu thích", "Favorites.Delete", null }
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "PasswordHash" },
                values: new object[] { new DateTime(2025, 10, 19, 1, 48, 12, 540, DateTimeKind.Local).AddTicks(4414), "$2a$11$7J6ahoVOFlVcLUAM4BixOeg/9vYrJLQJ17Xg.Ju1FFBqpEcz4kdq6" });

            migrationBuilder.InsertData(
                table: "RolePermissions",
                columns: new[] { "PermissionId", "RoleId" },
                values: new object[,]
                {
                    { 25, 1 },
                    { 26, 1 },
                    { 27, 1 },
                    { 28, 1 },
                    { 29, 1 },
                    { 30, 1 },
                    { 31, 1 },
                    { 32, 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Payments_OrderId",
                table: "Payments",
                column: "OrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_Payments_Orders_OrderId",
                table: "Payments",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Payments_Orders_OrderId",
                table: "Payments");

            migrationBuilder.DropIndex(
                name: "IX_Payments_OrderId",
                table: "Payments");

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { 25, 1 });

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { 26, 1 });

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { 27, 1 });

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { 28, 1 });

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { 29, 1 });

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { 30, 1 });

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { 31, 1 });

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { 32, 1 });

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 14, 4, 36, 11, 716, DateTimeKind.Utc).AddTicks(8585));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 14, 4, 36, 11, 716, DateTimeKind.Utc).AddTicks(8737));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 14, 4, 36, 11, 716, DateTimeKind.Utc).AddTicks(8745));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 14, 4, 36, 11, 716, DateTimeKind.Utc).AddTicks(8753));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 14, 4, 36, 11, 716, DateTimeKind.Utc).AddTicks(8761));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 14, 4, 36, 11, 716, DateTimeKind.Utc).AddTicks(8777));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 14, 4, 36, 11, 716, DateTimeKind.Utc).AddTicks(8791));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 14, 4, 36, 11, 716, DateTimeKind.Utc).AddTicks(8797));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 14, 4, 36, 11, 716, DateTimeKind.Utc).AddTicks(8858));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 14, 4, 36, 11, 716, DateTimeKind.Utc).AddTicks(8866));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 14, 4, 36, 11, 716, DateTimeKind.Utc).AddTicks(8876));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 14, 4, 36, 11, 716, DateTimeKind.Utc).AddTicks(8884));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 14, 4, 36, 11, 716, DateTimeKind.Utc).AddTicks(8893));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 14, 4, 36, 11, 716, DateTimeKind.Utc).AddTicks(8900));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 14, 4, 36, 11, 716, DateTimeKind.Utc).AddTicks(8912));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 14, 4, 36, 11, 716, DateTimeKind.Utc).AddTicks(8923));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 14, 4, 36, 11, 716, DateTimeKind.Utc).AddTicks(8934));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 14, 4, 36, 11, 716, DateTimeKind.Utc).AddTicks(8941));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 14, 4, 36, 11, 716, DateTimeKind.Utc).AddTicks(8949));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 14, 4, 36, 11, 716, DateTimeKind.Utc).AddTicks(8955));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 21,
                columns: new[] { "CreatedAt", "Description", "Module", "Name" },
                values: new object[] { new DateTime(2025, 10, 14, 4, 36, 11, 716, DateTimeKind.Utc).AddTicks(8962), "Xử lý đơn hàng", "Đơn hàng", "Orders.Process" });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 22,
                columns: new[] { "CreatedAt", "Description", "Module", "Name" },
                values: new object[] { new DateTime(2025, 10, 14, 4, 36, 11, 716, DateTimeKind.Utc).AddTicks(8971), "Xem tồn kho", "Kho", "Inventory.View" });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 23,
                columns: new[] { "CreatedAt", "Description", "Module", "Name" },
                values: new object[] { new DateTime(2025, 10, 14, 4, 36, 11, 716, DateTimeKind.Utc).AddTicks(8979), "Nhập kho", "Kho", "Inventory.Import" });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 24,
                columns: new[] { "CreatedAt", "Description", "Module", "Name" },
                values: new object[] { new DateTime(2025, 10, 14, 4, 36, 11, 716, DateTimeKind.Utc).AddTicks(8985), "Xem báo cáo tổng quan", "Báo cáo", "Reports.ViewDashboard" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "PasswordHash" },
                values: new object[] { new DateTime(2025, 10, 14, 11, 36, 11, 716, DateTimeKind.Local).AddTicks(9343), "$2a$11$ro5Y5rrDJ84MC.1RI3iY/euoX4sZi7R1Uokk2sPGB4yNakbeJQIaS" });

            migrationBuilder.CreateIndex(
                name: "IX_Payments_OrderId",
                table: "Payments",
                column: "OrderId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Payments_Orders_OrderId",
                table: "Payments",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id");
        }
    }
}
