using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BE__Small_Shop_Management_System.Migrations
{
    /// <inheritdoc />
    public partial class UpdatePermissionModuleVi : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "Description", "Module" },
                values: new object[] { new DateTime(2025, 9, 22, 4, 8, 28, 237, DateTimeKind.Utc).AddTicks(2715), "Xem danh sách người dùng", "Người dùng" });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "Description", "Module" },
                values: new object[] { new DateTime(2025, 9, 22, 4, 8, 28, 237, DateTimeKind.Utc).AddTicks(2765), "Tạo mới người dùng", "Người dùng" });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "Description", "Module" },
                values: new object[] { new DateTime(2025, 9, 22, 4, 8, 28, 237, DateTimeKind.Utc).AddTicks(2772), "Cập nhật thông tin người dùng", "Người dùng" });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "Description", "Module" },
                values: new object[] { new DateTime(2025, 9, 22, 4, 8, 28, 237, DateTimeKind.Utc).AddTicks(2809), "Xóa người dùng", "Người dùng" });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "Description", "Module" },
                values: new object[] { new DateTime(2025, 9, 22, 4, 8, 28, 237, DateTimeKind.Utc).AddTicks(2818), "Khóa tài khoản người dùng", "Người dùng" });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "Description", "Module" },
                values: new object[] { new DateTime(2025, 9, 22, 4, 8, 28, 237, DateTimeKind.Utc).AddTicks(2826), "Mở khóa tài khoản người dùng", "Người dùng" });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "Description", "Module" },
                values: new object[] { new DateTime(2025, 9, 22, 4, 8, 28, 237, DateTimeKind.Utc).AddTicks(2837), "Xem danh sách vai trò", "Vai trò" });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "Description", "Module" },
                values: new object[] { new DateTime(2025, 9, 22, 4, 8, 28, 237, DateTimeKind.Utc).AddTicks(2844), "Tạo mới vai trò", "Vai trò" });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedAt", "Description", "Module" },
                values: new object[] { new DateTime(2025, 9, 22, 4, 8, 28, 237, DateTimeKind.Utc).AddTicks(2851), "Cập nhật vai trò", "Vai trò" });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedAt", "Description", "Module" },
                values: new object[] { new DateTime(2025, 9, 22, 4, 8, 28, 237, DateTimeKind.Utc).AddTicks(2858), "Xóa vai trò", "Vai trò" });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "CreatedAt", "Description", "Module" },
                values: new object[] { new DateTime(2025, 9, 22, 4, 8, 28, 237, DateTimeKind.Utc).AddTicks(2868), "Xem danh sách quyền", "Quyền" });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "CreatedAt", "Description", "Module" },
                values: new object[] { new DateTime(2025, 9, 22, 4, 8, 28, 237, DateTimeKind.Utc).AddTicks(2878), "Xóa quyền", "Quyền" });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "CreatedAt", "Description", "Module" },
                values: new object[] { new DateTime(2025, 9, 22, 4, 8, 28, 237, DateTimeKind.Utc).AddTicks(2890), "Xem danh sách sản phẩm", "Sản phẩm" });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "CreatedAt", "Description", "Module" },
                values: new object[] { new DateTime(2025, 9, 22, 4, 8, 28, 237, DateTimeKind.Utc).AddTicks(2898), "Thêm mới sản phẩm", "Sản phẩm" });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "CreatedAt", "Description", "Module" },
                values: new object[] { new DateTime(2025, 9, 22, 4, 8, 28, 237, DateTimeKind.Utc).AddTicks(2906), "Cập nhật sản phẩm", "Sản phẩm" });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "CreatedAt", "Description", "Module" },
                values: new object[] { new DateTime(2025, 9, 22, 4, 8, 28, 237, DateTimeKind.Utc).AddTicks(2921), "Xóa sản phẩm", "Sản phẩm" });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "CreatedAt", "Description", "Module" },
                values: new object[] { new DateTime(2025, 9, 22, 4, 8, 28, 237, DateTimeKind.Utc).AddTicks(2931), "Xem danh sách đơn hàng", "Đơn hàng" });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "CreatedAt", "Description", "Module" },
                values: new object[] { new DateTime(2025, 9, 22, 4, 8, 28, 237, DateTimeKind.Utc).AddTicks(2938), "Tạo mới đơn hàng", "Đơn hàng" });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "CreatedAt", "Description", "Module" },
                values: new object[] { new DateTime(2025, 9, 22, 4, 8, 28, 237, DateTimeKind.Utc).AddTicks(2943), "Cập nhật đơn hàng", "Đơn hàng" });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "CreatedAt", "Description", "Module" },
                values: new object[] { new DateTime(2025, 9, 22, 4, 8, 28, 237, DateTimeKind.Utc).AddTicks(2949), "Xóa đơn hàng", "Đơn hàng" });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 21,
                columns: new[] { "CreatedAt", "Description", "Module" },
                values: new object[] { new DateTime(2025, 9, 22, 4, 8, 28, 237, DateTimeKind.Utc).AddTicks(2954), "Xử lý đơn hàng", "Đơn hàng" });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 22,
                columns: new[] { "CreatedAt", "Description", "Module" },
                values: new object[] { new DateTime(2025, 9, 22, 4, 8, 28, 237, DateTimeKind.Utc).AddTicks(2967), "Xem tồn kho", "Kho" });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 23,
                columns: new[] { "CreatedAt", "Description", "Module" },
                values: new object[] { new DateTime(2025, 9, 22, 4, 8, 28, 237, DateTimeKind.Utc).AddTicks(3018), "Nhập kho", "Kho" });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 24,
                columns: new[] { "CreatedAt", "Description", "Module" },
                values: new object[] { new DateTime(2025, 9, 22, 4, 8, 28, 237, DateTimeKind.Utc).AddTicks(3031), "Xem báo cáo tổng quan", "Báo cáo" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "PasswordHash" },
                values: new object[] { new DateTime(2025, 9, 22, 11, 8, 28, 237, DateTimeKind.Local).AddTicks(3350), "$2a$11$IOpZNJ7HjA0tay3XiAJse.aybKBREw9sIyXBN9qycZsHjdiJ30ZuS" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "Description", "Module" },
                values: new object[] { new DateTime(2025, 9, 19, 3, 35, 11, 93, DateTimeKind.Utc).AddTicks(6788), "Users View", "Users" });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "Description", "Module" },
                values: new object[] { new DateTime(2025, 9, 19, 3, 35, 11, 93, DateTimeKind.Utc).AddTicks(6822), "Users Create", "Users" });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "Description", "Module" },
                values: new object[] { new DateTime(2025, 9, 19, 3, 35, 11, 93, DateTimeKind.Utc).AddTicks(6833), "Users Update", "Users" });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "Description", "Module" },
                values: new object[] { new DateTime(2025, 9, 19, 3, 35, 11, 93, DateTimeKind.Utc).AddTicks(6838), "Users Delete", "Users" });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "Description", "Module" },
                values: new object[] { new DateTime(2025, 9, 19, 3, 35, 11, 93, DateTimeKind.Utc).AddTicks(6843), "Users Lock", "Users" });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "Description", "Module" },
                values: new object[] { new DateTime(2025, 9, 19, 3, 35, 11, 93, DateTimeKind.Utc).AddTicks(6856), "Users Unlock", "Users" });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "Description", "Module" },
                values: new object[] { new DateTime(2025, 9, 19, 3, 35, 11, 93, DateTimeKind.Utc).AddTicks(6881), "Roles View", "Roles" });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "Description", "Module" },
                values: new object[] { new DateTime(2025, 9, 19, 3, 35, 11, 93, DateTimeKind.Utc).AddTicks(6887), "Roles Create", "Roles" });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedAt", "Description", "Module" },
                values: new object[] { new DateTime(2025, 9, 19, 3, 35, 11, 93, DateTimeKind.Utc).AddTicks(6892), "Roles Update", "Roles" });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedAt", "Description", "Module" },
                values: new object[] { new DateTime(2025, 9, 19, 3, 35, 11, 93, DateTimeKind.Utc).AddTicks(6898), "Roles Delete", "Roles" });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "CreatedAt", "Description", "Module" },
                values: new object[] { new DateTime(2025, 9, 19, 3, 35, 11, 93, DateTimeKind.Utc).AddTicks(6906), "Permissions View", "Permissions" });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "CreatedAt", "Description", "Module" },
                values: new object[] { new DateTime(2025, 9, 19, 3, 35, 11, 93, DateTimeKind.Utc).AddTicks(6913), "Permissions Delete", "Permissions" });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "CreatedAt", "Description", "Module" },
                values: new object[] { new DateTime(2025, 9, 19, 3, 35, 11, 93, DateTimeKind.Utc).AddTicks(6922), "Products View", "Products" });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "CreatedAt", "Description", "Module" },
                values: new object[] { new DateTime(2025, 9, 19, 3, 35, 11, 93, DateTimeKind.Utc).AddTicks(6933), "Products Create", "Products" });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "CreatedAt", "Description", "Module" },
                values: new object[] { new DateTime(2025, 9, 19, 3, 35, 11, 93, DateTimeKind.Utc).AddTicks(6938), "Products Update", "Products" });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "CreatedAt", "Description", "Module" },
                values: new object[] { new DateTime(2025, 9, 19, 3, 35, 11, 93, DateTimeKind.Utc).AddTicks(6943), "Products Delete", "Products" });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "CreatedAt", "Description", "Module" },
                values: new object[] { new DateTime(2025, 9, 19, 3, 35, 11, 93, DateTimeKind.Utc).AddTicks(6953), "Orders View", "Orders" });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "CreatedAt", "Description", "Module" },
                values: new object[] { new DateTime(2025, 9, 19, 3, 35, 11, 93, DateTimeKind.Utc).AddTicks(6958), "Orders Create", "Orders" });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "CreatedAt", "Description", "Module" },
                values: new object[] { new DateTime(2025, 9, 19, 3, 35, 11, 93, DateTimeKind.Utc).AddTicks(6962), "Orders Update", "Orders" });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "CreatedAt", "Description", "Module" },
                values: new object[] { new DateTime(2025, 9, 19, 3, 35, 11, 93, DateTimeKind.Utc).AddTicks(7099), "Orders Delete", "Orders" });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 21,
                columns: new[] { "CreatedAt", "Description", "Module" },
                values: new object[] { new DateTime(2025, 9, 19, 3, 35, 11, 93, DateTimeKind.Utc).AddTicks(7104), "Orders Process", "Orders" });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 22,
                columns: new[] { "CreatedAt", "Description", "Module" },
                values: new object[] { new DateTime(2025, 9, 19, 3, 35, 11, 93, DateTimeKind.Utc).AddTicks(7113), "Inventory View", "Inventory" });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 23,
                columns: new[] { "CreatedAt", "Description", "Module" },
                values: new object[] { new DateTime(2025, 9, 19, 3, 35, 11, 93, DateTimeKind.Utc).AddTicks(7118), "Inventory Import", "Inventory" });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 24,
                columns: new[] { "CreatedAt", "Description", "Module" },
                values: new object[] { new DateTime(2025, 9, 19, 3, 35, 11, 93, DateTimeKind.Utc).AddTicks(7123), "Reports ViewDashboard", "Reports" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "PasswordHash" },
                values: new object[] { new DateTime(2025, 9, 19, 10, 35, 11, 93, DateTimeKind.Local).AddTicks(7417), "$2a$11$rcR/8MD45bBH5SCgqfMRMenii7Wme7.Cf21TOYbV5e0V2bc81AECS" });
        }
    }
}
