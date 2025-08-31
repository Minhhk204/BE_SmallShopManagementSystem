using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BE__Small_Shop_Management_System.Migrations
{
    /// <inheritdoc />
    public partial class initial3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Roles_RoleId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_RoleId",
                table: "Users");

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { 24, 1 });

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
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 24);

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

            migrationBuilder.DropColumn(
                name: "RoleId",
                table: "Users");

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 31, 19, 49, 58, 214, DateTimeKind.Utc).AddTicks(8361));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 31, 19, 49, 58, 214, DateTimeKind.Utc).AddTicks(8488));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 31, 19, 49, 58, 214, DateTimeKind.Utc).AddTicks(8494));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "Description", "Name" },
                values: new object[] { new DateTime(2025, 8, 31, 19, 49, 58, 214, DateTimeKind.Utc).AddTicks(8500), "Users Lock", "Users.Lock" });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "Description", "Name" },
                values: new object[] { new DateTime(2025, 8, 31, 19, 49, 58, 214, DateTimeKind.Utc).AddTicks(8506), "Users Unlock", "Users.Unlock" });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "Description", "Module", "Name" },
                values: new object[] { new DateTime(2025, 8, 31, 19, 49, 58, 214, DateTimeKind.Utc).AddTicks(8518), "Roles View", "Roles", "Roles.View" });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "Description", "Name" },
                values: new object[] { new DateTime(2025, 8, 31, 19, 49, 58, 214, DateTimeKind.Utc).AddTicks(8524), "Roles Create", "Roles.Create" });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "Description", "Name" },
                values: new object[] { new DateTime(2025, 8, 31, 19, 49, 58, 214, DateTimeKind.Utc).AddTicks(8529), "Roles Update", "Roles.Update" });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedAt", "Description", "Name" },
                values: new object[] { new DateTime(2025, 8, 31, 19, 49, 58, 214, DateTimeKind.Utc).AddTicks(8535), "Roles Delete", "Roles.Delete" });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedAt", "Description", "Module", "Name" },
                values: new object[] { new DateTime(2025, 8, 31, 19, 49, 58, 214, DateTimeKind.Utc).AddTicks(8543), "Permissions View", "Permissions", "Permissions.View" });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "CreatedAt", "Description", "Module", "Name" },
                values: new object[] { new DateTime(2025, 8, 31, 19, 49, 58, 214, DateTimeKind.Utc).AddTicks(8550), "Permissions Delete", "Permissions", "Permissions.Delete" });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "CreatedAt", "Description", "Module", "Name" },
                values: new object[] { new DateTime(2025, 8, 31, 19, 49, 58, 214, DateTimeKind.Utc).AddTicks(8560), "Products View", "Products", "Products.View" });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "CreatedAt", "Description", "Module", "Name" },
                values: new object[] { new DateTime(2025, 8, 31, 19, 49, 58, 214, DateTimeKind.Utc).AddTicks(8567), "Products Create", "Products", "Products.Create" });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "CreatedAt", "Description", "Module", "Name" },
                values: new object[] { new DateTime(2025, 8, 31, 19, 49, 58, 214, DateTimeKind.Utc).AddTicks(8572), "Products Update", "Products", "Products.Update" });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "CreatedAt", "Description", "Module", "Name" },
                values: new object[] { new DateTime(2025, 8, 31, 19, 49, 58, 214, DateTimeKind.Utc).AddTicks(8585), "Products Delete", "Products", "Products.Delete" });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "CreatedAt", "Description", "Module", "Name" },
                values: new object[] { new DateTime(2025, 8, 31, 19, 49, 58, 214, DateTimeKind.Utc).AddTicks(8596), "Orders View", "Orders", "Orders.View" });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "CreatedAt", "Description", "Module", "Name" },
                values: new object[] { new DateTime(2025, 8, 31, 19, 49, 58, 214, DateTimeKind.Utc).AddTicks(8613), "Orders Create", "Orders", "Orders.Create" });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "CreatedAt", "Description", "Module", "Name" },
                values: new object[] { new DateTime(2025, 8, 31, 19, 49, 58, 214, DateTimeKind.Utc).AddTicks(8620), "Orders Update", "Orders", "Orders.Update" });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "CreatedAt", "Description", "Module", "Name" },
                values: new object[] { new DateTime(2025, 8, 31, 19, 49, 58, 214, DateTimeKind.Utc).AddTicks(8625), "Orders Delete", "Orders", "Orders.Delete" });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "CreatedAt", "Description", "Name" },
                values: new object[] { new DateTime(2025, 8, 31, 19, 49, 58, 214, DateTimeKind.Utc).AddTicks(8631), "Orders Process", "Orders.Process" });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 21,
                columns: new[] { "CreatedAt", "Description", "Module", "Name" },
                values: new object[] { new DateTime(2025, 8, 31, 19, 49, 58, 214, DateTimeKind.Utc).AddTicks(8640), "Inventory View", "Inventory", "Inventory.View" });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 22,
                columns: new[] { "CreatedAt", "Description", "Module", "Name" },
                values: new object[] { new DateTime(2025, 8, 31, 19, 49, 58, 214, DateTimeKind.Utc).AddTicks(8645), "Inventory Import", "Inventory", "Inventory.Import" });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 23,
                columns: new[] { "CreatedAt", "Description", "Module", "Name" },
                values: new object[] { new DateTime(2025, 8, 31, 19, 49, 58, 214, DateTimeKind.Utc).AddTicks(8678), "Reports ViewDashboard", "Reports", "Reports.ViewDashboard" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "PasswordHash",
                value: "$2a$11$Ql3xZU.a1M6UewPwpx/eQ.iBaBI0po6D1oWaJE7UVhipy/8I7obda");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RoleId",
                table: "Users",
                type: "int",
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
                columns: new[] { "CreatedAt", "Description", "Name" },
                values: new object[] { new DateTime(2025, 8, 30, 15, 56, 32, 537, DateTimeKind.Utc).AddTicks(7978), "Users Delete", "Users.Delete" });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "Description", "Name" },
                values: new object[] { new DateTime(2025, 8, 30, 15, 56, 32, 537, DateTimeKind.Utc).AddTicks(7983), "Users Lock", "Users.Lock" });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "Description", "Module", "Name" },
                values: new object[] { new DateTime(2025, 8, 30, 15, 56, 32, 537, DateTimeKind.Utc).AddTicks(7989), "Users Unlock", "Users", "Users.Unlock" });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "Description", "Name" },
                values: new object[] { new DateTime(2025, 8, 30, 15, 56, 32, 537, DateTimeKind.Utc).AddTicks(8000), "Roles View", "Roles.View" });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "Description", "Name" },
                values: new object[] { new DateTime(2025, 8, 30, 15, 56, 32, 537, DateTimeKind.Utc).AddTicks(8005), "Roles Create", "Roles.Create" });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedAt", "Description", "Name" },
                values: new object[] { new DateTime(2025, 8, 30, 15, 56, 32, 537, DateTimeKind.Utc).AddTicks(8010), "Roles Update", "Roles.Update" });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedAt", "Description", "Module", "Name" },
                values: new object[] { new DateTime(2025, 8, 30, 15, 56, 32, 537, DateTimeKind.Utc).AddTicks(8016), "Roles Delete", "Roles", "Roles.Delete" });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "CreatedAt", "Description", "Module", "Name" },
                values: new object[] { new DateTime(2025, 8, 30, 15, 56, 32, 537, DateTimeKind.Utc).AddTicks(8023), "Roles AssignPermissions", "Roles", "Roles.AssignPermissions" });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "CreatedAt", "Description", "Module", "Name" },
                values: new object[] { new DateTime(2025, 8, 30, 15, 56, 32, 537, DateTimeKind.Utc).AddTicks(8035), "Permissions View", "Permissions", "Permissions.View" });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "CreatedAt", "Description", "Module", "Name" },
                values: new object[] { new DateTime(2025, 8, 30, 15, 56, 32, 537, DateTimeKind.Utc).AddTicks(8040), "Permissions Create", "Permissions", "Permissions.Create" });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "CreatedAt", "Description", "Module", "Name" },
                values: new object[] { new DateTime(2025, 8, 30, 15, 56, 32, 537, DateTimeKind.Utc).AddTicks(8045), "Permissions Update", "Permissions", "Permissions.Update" });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "CreatedAt", "Description", "Module", "Name" },
                values: new object[] { new DateTime(2025, 8, 30, 15, 56, 32, 537, DateTimeKind.Utc).AddTicks(8055), "Permissions Delete", "Permissions", "Permissions.Delete" });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "CreatedAt", "Description", "Module", "Name" },
                values: new object[] { new DateTime(2025, 8, 30, 15, 56, 32, 537, DateTimeKind.Utc).AddTicks(8064), "Products View", "Products", "Products.View" });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "CreatedAt", "Description", "Module", "Name" },
                values: new object[] { new DateTime(2025, 8, 30, 15, 56, 32, 537, DateTimeKind.Utc).AddTicks(8070), "Products Create", "Products", "Products.Create" });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "CreatedAt", "Description", "Module", "Name" },
                values: new object[] { new DateTime(2025, 8, 30, 15, 56, 32, 537, DateTimeKind.Utc).AddTicks(8076), "Products Update", "Products", "Products.Update" });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "CreatedAt", "Description", "Module", "Name" },
                values: new object[] { new DateTime(2025, 8, 30, 15, 56, 32, 537, DateTimeKind.Utc).AddTicks(8082), "Products Delete", "Products", "Products.Delete" });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "CreatedAt", "Description", "Name" },
                values: new object[] { new DateTime(2025, 8, 30, 15, 56, 32, 537, DateTimeKind.Utc).AddTicks(8093), "Orders View", "Orders.View" });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 21,
                columns: new[] { "CreatedAt", "Description", "Module", "Name" },
                values: new object[] { new DateTime(2025, 8, 30, 15, 56, 32, 537, DateTimeKind.Utc).AddTicks(8098), "Orders Create", "Orders", "Orders.Create" });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 22,
                columns: new[] { "CreatedAt", "Description", "Module", "Name" },
                values: new object[] { new DateTime(2025, 8, 30, 15, 56, 32, 537, DateTimeKind.Utc).AddTicks(8102), "Orders Update", "Orders", "Orders.Update" });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 23,
                columns: new[] { "CreatedAt", "Description", "Module", "Name" },
                values: new object[] { new DateTime(2025, 8, 30, 15, 56, 32, 537, DateTimeKind.Utc).AddTicks(8106), "Orders Delete", "Orders", "Orders.Delete" });

            migrationBuilder.InsertData(
                table: "Permissions",
                columns: new[] { "Id", "CreatedAt", "Description", "Module", "Name", "PermissionId", "UpdatedAt" },
                values: new object[,]
                {
                    { 24, new DateTime(2025, 8, 30, 15, 56, 32, 537, DateTimeKind.Utc).AddTicks(8110), "Orders Process", "Orders", "Orders.Process", 0, null },
                    { 25, new DateTime(2025, 8, 30, 15, 56, 32, 537, DateTimeKind.Utc).AddTicks(8145), "Inventory View", "Inventory", "Inventory.View", 0, null },
                    { 26, new DateTime(2025, 8, 30, 15, 56, 32, 537, DateTimeKind.Utc).AddTicks(8151), "Inventory Import", "Inventory", "Inventory.Import", 0, null },
                    { 27, new DateTime(2025, 8, 30, 15, 56, 32, 537, DateTimeKind.Utc).AddTicks(8163), "Reports ViewDashboard", "Reports", "Reports.ViewDashboard", 0, null }
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "RoleId" },
                values: new object[] { "$2a$11$d9O0Hx4KwvyYh0mLVK4h5.5WOcafrI6yv3HlnBN0FQBWSEPryFddi", null });

            migrationBuilder.InsertData(
                table: "RolePermissions",
                columns: new[] { "PermissionId", "RoleId" },
                values: new object[,]
                {
                    { 24, 1 },
                    { 25, 1 },
                    { 26, 1 },
                    { 27, 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Users_RoleId",
                table: "Users",
                column: "RoleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Roles_RoleId",
                table: "Users",
                column: "RoleId",
                principalTable: "Roles",
                principalColumn: "Id");
        }
    }
}
