using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BE__Small_Shop_Management_System.Migrations
{
    /// <inheritdoc />
    public partial class FixNavigationProps : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CartItems_Products_ProductId1",
                table: "CartItems");

            migrationBuilder.DropForeignKey(
                name: "FK_RolePermissions_Roles_RoleId",
                table: "RolePermissions");

            migrationBuilder.DropIndex(
                name: "IX_CartItems_ProductId1",
                table: "CartItems");

            migrationBuilder.DropColumn(
                name: "ProductId1",
                table: "CartItems");

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 24, 3, 57, 43, 681, DateTimeKind.Utc).AddTicks(741));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 24, 3, 57, 43, 681, DateTimeKind.Utc).AddTicks(782));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 24, 3, 57, 43, 681, DateTimeKind.Utc).AddTicks(790));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 24, 3, 57, 43, 681, DateTimeKind.Utc).AddTicks(795));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 24, 3, 57, 43, 681, DateTimeKind.Utc).AddTicks(800));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 24, 3, 57, 43, 681, DateTimeKind.Utc).AddTicks(810));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "Description", "Module", "Name" },
                values: new object[] { new DateTime(2025, 10, 24, 3, 57, 43, 681, DateTimeKind.Utc).AddTicks(820), "Users ResetPassword", "Người dùng", "Users.ResetPassword" });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "Description", "Name" },
                values: new object[] { new DateTime(2025, 10, 24, 3, 57, 43, 681, DateTimeKind.Utc).AddTicks(840), "Xem danh sách vai trò", "Roles.View" });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedAt", "Description", "Name" },
                values: new object[] { new DateTime(2025, 10, 24, 3, 57, 43, 681, DateTimeKind.Utc).AddTicks(848), "Tạo mới vai trò", "Roles.Create" });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedAt", "Description", "Name" },
                values: new object[] { new DateTime(2025, 10, 24, 3, 57, 43, 681, DateTimeKind.Utc).AddTicks(888), "Cập nhật vai trò", "Roles.Update" });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "CreatedAt", "Description", "Module", "Name" },
                values: new object[] { new DateTime(2025, 10, 24, 3, 57, 43, 681, DateTimeKind.Utc).AddTicks(893), "Xóa vai trò", "Vai trò", "Roles.Delete" });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "CreatedAt", "Description", "Name" },
                values: new object[] { new DateTime(2025, 10, 24, 3, 57, 43, 681, DateTimeKind.Utc).AddTicks(901), "Xem danh sách quyền", "Permissions.View" });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "CreatedAt", "Description", "Module", "Name" },
                values: new object[] { new DateTime(2025, 10, 24, 3, 57, 43, 681, DateTimeKind.Utc).AddTicks(908), "Permissions Create", "Quyền", "Permissions.Create" });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "CreatedAt", "Description", "Module", "Name" },
                values: new object[] { new DateTime(2025, 10, 24, 3, 57, 43, 681, DateTimeKind.Utc).AddTicks(913), "Permissions Update", "Quyền", "Permissions.Update" });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "CreatedAt", "Description", "Module", "Name" },
                values: new object[] { new DateTime(2025, 10, 24, 3, 57, 43, 681, DateTimeKind.Utc).AddTicks(922), "Permissions Delete", "Quyền", "Permissions.Delete" });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "CreatedAt", "Description", "Name" },
                values: new object[] { new DateTime(2025, 10, 24, 3, 57, 43, 681, DateTimeKind.Utc).AddTicks(937), "Xem danh sách sản phẩm", "Products.View" });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "CreatedAt", "Description", "Module", "Name" },
                values: new object[] { new DateTime(2025, 10, 24, 3, 57, 43, 681, DateTimeKind.Utc).AddTicks(943), "Thêm mới sản phẩm", "Sản phẩm", "Products.Create" });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "CreatedAt", "Description", "Module", "Name" },
                values: new object[] { new DateTime(2025, 10, 24, 3, 57, 43, 681, DateTimeKind.Utc).AddTicks(951), "Cập nhật sản phẩm", "Sản phẩm", "Products.Update" });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "CreatedAt", "Description", "Module", "Name" },
                values: new object[] { new DateTime(2025, 10, 24, 3, 57, 43, 681, DateTimeKind.Utc).AddTicks(957), "Xóa sản phẩm", "Sản phẩm", "Products.Delete" });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "CreatedAt", "Description", "Module", "Name" },
                values: new object[] { new DateTime(2025, 10, 24, 3, 57, 43, 681, DateTimeKind.Utc).AddTicks(966), "Products Import", "Sản phẩm", "Products.Import" });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 21,
                columns: new[] { "CreatedAt", "Description", "Module", "Name" },
                values: new object[] { new DateTime(2025, 10, 24, 3, 57, 43, 681, DateTimeKind.Utc).AddTicks(975), "Products Export", "Sản phẩm", "Products.Export" });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 22,
                columns: new[] { "CreatedAt", "Description", "Module", "Name" },
                values: new object[] { new DateTime(2025, 10, 24, 3, 57, 43, 681, DateTimeKind.Utc).AddTicks(984), "Xem danh sách đơn hàng", "Đơn hàng", "Orders.View" });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 23,
                columns: new[] { "CreatedAt", "Description", "Module", "Name" },
                values: new object[] { new DateTime(2025, 10, 24, 3, 57, 43, 681, DateTimeKind.Utc).AddTicks(989), "Tạo mới đơn hàng", "Đơn hàng", "Orders.Create" });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 24,
                columns: new[] { "CreatedAt", "Description", "Module", "Name" },
                values: new object[] { new DateTime(2025, 10, 24, 3, 57, 43, 681, DateTimeKind.Utc).AddTicks(994), "Cập nhật đơn hàng", "Đơn hàng", "Orders.Update" });

            migrationBuilder.InsertData(
                table: "Permissions",
                columns: new[] { "Id", "CreatedAt", "Description", "Module", "Name", "UpdatedAt" },
                values: new object[,]
                {
                    { 25, new DateTime(2025, 10, 24, 3, 57, 43, 681, DateTimeKind.Utc).AddTicks(999), "Orders Delete", "Đơn hàng", "Orders.Delete", null },
                    { 26, new DateTime(2025, 10, 24, 3, 57, 43, 681, DateTimeKind.Utc).AddTicks(1005), "Xử lý đơn hàng", "Đơn hàng", "Orders.Process", null },
                    { 27, new DateTime(2025, 10, 24, 3, 57, 43, 681, DateTimeKind.Utc).AddTicks(1014), "Orders Cancel", "Đơn hàng", "Orders.Cancel", null },
                    { 28, new DateTime(2025, 10, 24, 3, 57, 43, 681, DateTimeKind.Utc).AddTicks(1024), "Inventory View", "Kho", "Inventory.View", null },
                    { 29, new DateTime(2025, 10, 24, 3, 57, 43, 681, DateTimeKind.Utc).AddTicks(1055), "Inventory Import", "Kho", "Inventory.Import", null },
                    { 30, new DateTime(2025, 10, 24, 3, 57, 43, 681, DateTimeKind.Utc).AddTicks(1071), "Inventory Export", "Kho", "Inventory.Export", null },
                    { 31, new DateTime(2025, 10, 24, 3, 57, 43, 681, DateTimeKind.Utc).AddTicks(1077), "Inventory Update", "Kho", "Inventory.Update", null },
                    { 32, new DateTime(2025, 10, 24, 3, 57, 43, 681, DateTimeKind.Utc).AddTicks(1085), "Reports View", "Báo cáo", "Reports.View", null },
                    { 33, new DateTime(2025, 10, 24, 3, 57, 43, 681, DateTimeKind.Utc).AddTicks(1091), "Reports Generate", "Báo cáo", "Reports.Generate", null },
                    { 34, new DateTime(2025, 10, 24, 3, 57, 43, 681, DateTimeKind.Utc).AddTicks(1099), "Reports Export", "Báo cáo", "Reports.Export", null },
                    { 35, new DateTime(2025, 10, 24, 3, 57, 43, 681, DateTimeKind.Utc).AddTicks(1108), "Xem danh mục sản phẩm", "Danh mục", "Categories.View", null },
                    { 36, new DateTime(2025, 10, 24, 3, 57, 43, 681, DateTimeKind.Utc).AddTicks(1113), "Tạo mới danh mục sản phẩm", "Danh mục", "Categories.Create", null },
                    { 37, new DateTime(2025, 10, 24, 3, 57, 43, 681, DateTimeKind.Utc).AddTicks(1123), "Cập nhật danh mục sản phẩm", "Danh mục", "Categories.Update", null },
                    { 38, new DateTime(2025, 10, 24, 3, 57, 43, 681, DateTimeKind.Utc).AddTicks(1129), "Xóa danh mục sản phẩm", "Danh mục", "Categories.Delete", null },
                    { 39, new DateTime(2025, 10, 24, 3, 57, 43, 681, DateTimeKind.Utc).AddTicks(1137), "Xem nhật ký hệ thống", "Nhật ký hệ thống", "SystemLogs.View", null },
                    { 40, new DateTime(2025, 10, 24, 3, 57, 43, 681, DateTimeKind.Utc).AddTicks(1142), "Xóa nhật ký hệ thống", "Nhật ký hệ thống", "SystemLogs.Delete", null },
                    { 41, new DateTime(2025, 10, 24, 3, 57, 43, 681, DateTimeKind.Utc).AddTicks(1148), "Xem trang tổng quan", "Tổng quan", "Dashboard.View", null },
                    { 42, new DateTime(2025, 10, 24, 3, 57, 43, 681, DateTimeKind.Utc).AddTicks(1153), "Dashboard Analyze", "Tổng quan", "Dashboard.Analyze", null },
                    { 43, new DateTime(2025, 10, 24, 3, 57, 43, 681, DateTimeKind.Utc).AddTicks(1162), "Xem chính sách mật khẩu", "Chính sách mật khẩu", "PasswordPolicy.View", null },
                    { 44, new DateTime(2025, 10, 24, 3, 57, 43, 681, DateTimeKind.Utc).AddTicks(1169), "Cập nhật chính sách mật khẩu", "Chính sách mật khẩu", "PasswordPolicy.Update", null },
                    { 45, new DateTime(2025, 10, 24, 3, 57, 43, 681, DateTimeKind.Utc).AddTicks(1176), "Xem giỏ hàng", "Giỏ hàng", "Cart.View", null },
                    { 46, new DateTime(2025, 10, 24, 3, 57, 43, 681, DateTimeKind.Utc).AddTicks(1181), "Thêm sản phẩm vào giỏ hàng", "Giỏ hàng", "Cart.Add", null },
                    { 47, new DateTime(2025, 10, 24, 3, 57, 43, 681, DateTimeKind.Utc).AddTicks(1216), "Cập nhật giỏ hàng", "Giỏ hàng", "Cart.Update", null },
                    { 48, new DateTime(2025, 10, 24, 3, 57, 43, 681, DateTimeKind.Utc).AddTicks(1222), "Xóa sản phẩm khỏi giỏ hàng", "Giỏ hàng", "Cart.Delete", null },
                    { 49, new DateTime(2025, 10, 24, 3, 57, 43, 681, DateTimeKind.Utc).AddTicks(1231), "Xem danh sách yêu thích", "Yêu thích", "Favorites.View", null },
                    { 50, new DateTime(2025, 10, 24, 3, 57, 43, 681, DateTimeKind.Utc).AddTicks(1235), "Thêm sản phẩm yêu thích", "Yêu thích", "Favorites.Add", null },
                    { 51, new DateTime(2025, 10, 24, 3, 57, 43, 681, DateTimeKind.Utc).AddTicks(1241), "Xóa sản phẩm yêu thích", "Yêu thích", "Favorites.Delete", null },
                    { 52, new DateTime(2025, 10, 24, 3, 57, 43, 681, DateTimeKind.Utc).AddTicks(1248), "Xem chi tiết sản phẩm trong đơn hàng", "Chi tiết đơn hàng", "OrderItems.View", null },
                    { 53, new DateTime(2025, 10, 24, 3, 57, 43, 681, DateTimeKind.Utc).AddTicks(1254), "Xem lịch sử nhập xuất kho", "Lịch sử kho", "InventoryHistory.View", null },
                    { 54, new DateTime(2025, 10, 24, 3, 57, 43, 681, DateTimeKind.Utc).AddTicks(1261), "Nhập hàng vào kho", "Lịch sử kho", "InventoryHistory.Import", null },
                    { 55, new DateTime(2025, 10, 24, 3, 57, 43, 681, DateTimeKind.Utc).AddTicks(1267), "InventoryHistory Export", "Lịch sử kho", "InventoryHistory.Export", null }
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "PasswordHash" },
                values: new object[] { new DateTime(2025, 10, 24, 10, 57, 43, 681, DateTimeKind.Local).AddTicks(1569), "$2a$11$jEywjT6sLVTabanLiGENR.TFwsoJhc/IlA1vJn/T1SVuiXGhPNOjy" });

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
                    { 32, 1 },
                    { 33, 1 },
                    { 34, 1 },
                    { 35, 1 },
                    { 36, 1 },
                    { 37, 1 },
                    { 38, 1 },
                    { 39, 1 },
                    { 40, 1 },
                    { 41, 1 },
                    { 42, 1 },
                    { 43, 1 },
                    { 44, 1 },
                    { 45, 1 },
                    { 46, 1 },
                    { 47, 1 },
                    { 48, 1 },
                    { 49, 1 },
                    { 50, 1 },
                    { 51, 1 },
                    { 52, 1 },
                    { 53, 1 },
                    { 54, 1 },
                    { 55, 1 }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_RolePermissions_Roles_RoleId",
                table: "RolePermissions",
                column: "RoleId",
                principalTable: "Roles",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RolePermissions_Roles_RoleId",
                table: "RolePermissions");

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
                table: "RolePermissions",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { 33, 1 });

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { 34, 1 });

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { 35, 1 });

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { 36, 1 });

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { 37, 1 });

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { 38, 1 });

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { 39, 1 });

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { 40, 1 });

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { 41, 1 });

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { 42, 1 });

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { 43, 1 });

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { 44, 1 });

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { 45, 1 });

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { 46, 1 });

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { 47, 1 });

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { 48, 1 });

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { 49, 1 });

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { 50, 1 });

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { 51, 1 });

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { 52, 1 });

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { 53, 1 });

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { 54, 1 });

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { 55, 1 });

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

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 42);

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 43);

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 44);

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 45);

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 46);

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 47);

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 48);

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 49);

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 50);

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 51);

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 52);

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 53);

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 54);

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 55);

            migrationBuilder.AddColumn<int>(
                name: "ProductId1",
                table: "CartItems",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 24, 3, 43, 30, 250, DateTimeKind.Utc).AddTicks(5426));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 24, 3, 43, 30, 250, DateTimeKind.Utc).AddTicks(5463));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 24, 3, 43, 30, 250, DateTimeKind.Utc).AddTicks(5470));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 24, 3, 43, 30, 250, DateTimeKind.Utc).AddTicks(5476));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 24, 3, 43, 30, 250, DateTimeKind.Utc).AddTicks(5484));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 24, 3, 43, 30, 250, DateTimeKind.Utc).AddTicks(5491));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "Description", "Module", "Name" },
                values: new object[] { new DateTime(2025, 10, 24, 3, 43, 30, 250, DateTimeKind.Utc).AddTicks(5502), "Xem danh sách vai trò", "Vai trò", "Roles.View" });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "Description", "Name" },
                values: new object[] { new DateTime(2025, 10, 24, 3, 43, 30, 250, DateTimeKind.Utc).AddTicks(5507), "Tạo mới vai trò", "Roles.Create" });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedAt", "Description", "Name" },
                values: new object[] { new DateTime(2025, 10, 24, 3, 43, 30, 250, DateTimeKind.Utc).AddTicks(5515), "Cập nhật vai trò", "Roles.Update" });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedAt", "Description", "Name" },
                values: new object[] { new DateTime(2025, 10, 24, 3, 43, 30, 250, DateTimeKind.Utc).AddTicks(5521), "Xóa vai trò", "Roles.Delete" });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "CreatedAt", "Description", "Module", "Name" },
                values: new object[] { new DateTime(2025, 10, 24, 3, 43, 30, 250, DateTimeKind.Utc).AddTicks(5530), "Xem danh sách quyền", "Quyền", "Permissions.View" });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "CreatedAt", "Description", "Name" },
                values: new object[] { new DateTime(2025, 10, 24, 3, 43, 30, 250, DateTimeKind.Utc).AddTicks(5538), "Permissions Delete", "Permissions.Delete" });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "CreatedAt", "Description", "Module", "Name" },
                values: new object[] { new DateTime(2025, 10, 24, 3, 43, 30, 250, DateTimeKind.Utc).AddTicks(5561), "Xem danh sách sản phẩm", "Sản phẩm", "Products.View" });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "CreatedAt", "Description", "Module", "Name" },
                values: new object[] { new DateTime(2025, 10, 24, 3, 43, 30, 250, DateTimeKind.Utc).AddTicks(5568), "Thêm mới sản phẩm", "Sản phẩm", "Products.Create" });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "CreatedAt", "Description", "Module", "Name" },
                values: new object[] { new DateTime(2025, 10, 24, 3, 43, 30, 250, DateTimeKind.Utc).AddTicks(5576), "Cập nhật sản phẩm", "Sản phẩm", "Products.Update" });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "CreatedAt", "Description", "Name" },
                values: new object[] { new DateTime(2025, 10, 24, 3, 43, 30, 250, DateTimeKind.Utc).AddTicks(5614), "Xóa sản phẩm", "Products.Delete" });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "CreatedAt", "Description", "Module", "Name" },
                values: new object[] { new DateTime(2025, 10, 24, 3, 43, 30, 250, DateTimeKind.Utc).AddTicks(5624), "Xem danh sách đơn hàng", "Đơn hàng", "Orders.View" });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "CreatedAt", "Description", "Module", "Name" },
                values: new object[] { new DateTime(2025, 10, 24, 3, 43, 30, 250, DateTimeKind.Utc).AddTicks(5635), "Tạo mới đơn hàng", "Đơn hàng", "Orders.Create" });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "CreatedAt", "Description", "Module", "Name" },
                values: new object[] { new DateTime(2025, 10, 24, 3, 43, 30, 250, DateTimeKind.Utc).AddTicks(5640), "Cập nhật đơn hàng", "Đơn hàng", "Orders.Update" });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "CreatedAt", "Description", "Module", "Name" },
                values: new object[] { new DateTime(2025, 10, 24, 3, 43, 30, 250, DateTimeKind.Utc).AddTicks(5645), "Orders Delete", "Đơn hàng", "Orders.Delete" });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 21,
                columns: new[] { "CreatedAt", "Description", "Module", "Name" },
                values: new object[] { new DateTime(2025, 10, 24, 3, 43, 30, 250, DateTimeKind.Utc).AddTicks(5652), "Xử lý đơn hàng", "Đơn hàng", "Orders.Process" });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 22,
                columns: new[] { "CreatedAt", "Description", "Module", "Name" },
                values: new object[] { new DateTime(2025, 10, 24, 3, 43, 30, 250, DateTimeKind.Utc).AddTicks(5659), "Inventory View", "Kho", "Inventory.View" });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 23,
                columns: new[] { "CreatedAt", "Description", "Module", "Name" },
                values: new object[] { new DateTime(2025, 10, 24, 3, 43, 30, 250, DateTimeKind.Utc).AddTicks(5667), "Inventory Import", "Kho", "Inventory.Import" });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 24,
                columns: new[] { "CreatedAt", "Description", "Module", "Name" },
                values: new object[] { new DateTime(2025, 10, 24, 3, 43, 30, 250, DateTimeKind.Utc).AddTicks(5675), "Reports ViewDashboard", "Báo cáo", "Reports.ViewDashboard" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "PasswordHash" },
                values: new object[] { new DateTime(2025, 10, 24, 10, 43, 30, 250, DateTimeKind.Local).AddTicks(5940), "$2a$11$G3urdjQIVEZ9ZPcozbaVTupwp1pMNp7uBM211Q5YsKl2wGDhavrlW" });

            migrationBuilder.CreateIndex(
                name: "IX_CartItems_ProductId1",
                table: "CartItems",
                column: "ProductId1");

            migrationBuilder.AddForeignKey(
                name: "FK_CartItems_Products_ProductId1",
                table: "CartItems",
                column: "ProductId1",
                principalTable: "Products",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RolePermissions_Roles_RoleId",
                table: "RolePermissions",
                column: "RoleId",
                principalTable: "Roles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
