using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BE__Small_Shop_Management_System.Migrations
{
    /// <inheritdoc />
    public partial class initial7 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 6, 8, 11, 3, 943, DateTimeKind.Utc).AddTicks(1850));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 6, 8, 11, 3, 943, DateTimeKind.Utc).AddTicks(1914));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 6, 8, 11, 3, 943, DateTimeKind.Utc).AddTicks(1920));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "Description", "Name" },
                values: new object[] { new DateTime(2025, 9, 6, 8, 11, 3, 943, DateTimeKind.Utc).AddTicks(1925), "Users Delete", "Users.Delete" });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "Description", "Name" },
                values: new object[] { new DateTime(2025, 9, 6, 8, 11, 3, 943, DateTimeKind.Utc).AddTicks(1931), "Users Lock", "Users.Lock" });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "Description", "Module", "Name" },
                values: new object[] { new DateTime(2025, 9, 6, 8, 11, 3, 943, DateTimeKind.Utc).AddTicks(1937), "Users Unlock", "Users", "Users.Unlock" });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "Description", "Name" },
                values: new object[] { new DateTime(2025, 9, 6, 8, 11, 3, 943, DateTimeKind.Utc).AddTicks(1950), "Roles View", "Roles.View" });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "Description", "Name" },
                values: new object[] { new DateTime(2025, 9, 6, 8, 11, 3, 943, DateTimeKind.Utc).AddTicks(1957), "Roles Create", "Roles.Create" });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedAt", "Description", "Name" },
                values: new object[] { new DateTime(2025, 9, 6, 8, 11, 3, 943, DateTimeKind.Utc).AddTicks(1962), "Roles Update", "Roles.Update" });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedAt", "Description", "Module", "Name" },
                values: new object[] { new DateTime(2025, 9, 6, 8, 11, 3, 943, DateTimeKind.Utc).AddTicks(1969), "Roles Delete", "Roles", "Roles.Delete" });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "CreatedAt", "Description", "Name" },
                values: new object[] { new DateTime(2025, 9, 6, 8, 11, 3, 943, DateTimeKind.Utc).AddTicks(2029), "Permissions View", "Permissions.View" });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "CreatedAt", "Description", "Module", "Name" },
                values: new object[] { new DateTime(2025, 9, 6, 8, 11, 3, 943, DateTimeKind.Utc).AddTicks(2037), "Permissions Delete", "Permissions", "Permissions.Delete" });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "CreatedAt", "Description", "Name" },
                values: new object[] { new DateTime(2025, 9, 6, 8, 11, 3, 943, DateTimeKind.Utc).AddTicks(2047), "Products View", "Products.View" });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "CreatedAt", "Description", "Name" },
                values: new object[] { new DateTime(2025, 9, 6, 8, 11, 3, 943, DateTimeKind.Utc).AddTicks(2055), "Products Create", "Products.Create" });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "CreatedAt", "Description", "Name" },
                values: new object[] { new DateTime(2025, 9, 6, 8, 11, 3, 943, DateTimeKind.Utc).AddTicks(2068), "Products Update", "Products.Update" });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "CreatedAt", "Description", "Module", "Name" },
                values: new object[] { new DateTime(2025, 9, 6, 8, 11, 3, 943, DateTimeKind.Utc).AddTicks(2073), "Products Delete", "Products", "Products.Delete" });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "CreatedAt", "Description", "Name" },
                values: new object[] { new DateTime(2025, 9, 6, 8, 11, 3, 943, DateTimeKind.Utc).AddTicks(2087), "Orders View", "Orders.View" });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "CreatedAt", "Description", "Name" },
                values: new object[] { new DateTime(2025, 9, 6, 8, 11, 3, 943, DateTimeKind.Utc).AddTicks(2093), "Orders Create", "Orders.Create" });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "CreatedAt", "Description", "Name" },
                values: new object[] { new DateTime(2025, 9, 6, 8, 11, 3, 943, DateTimeKind.Utc).AddTicks(2099), "Orders Update", "Orders.Update" });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "CreatedAt", "Description", "Name" },
                values: new object[] { new DateTime(2025, 9, 6, 8, 11, 3, 943, DateTimeKind.Utc).AddTicks(2104), "Orders Delete", "Orders.Delete" });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 21,
                columns: new[] { "CreatedAt", "Description", "Module", "Name" },
                values: new object[] { new DateTime(2025, 9, 6, 8, 11, 3, 943, DateTimeKind.Utc).AddTicks(2110), "Orders Process", "Orders", "Orders.Process" });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 22,
                columns: new[] { "CreatedAt", "Description", "Name" },
                values: new object[] { new DateTime(2025, 9, 6, 8, 11, 3, 943, DateTimeKind.Utc).AddTicks(2119), "Inventory View", "Inventory.View" });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 23,
                columns: new[] { "CreatedAt", "Description", "Module", "Name" },
                values: new object[] { new DateTime(2025, 9, 6, 8, 11, 3, 943, DateTimeKind.Utc).AddTicks(2125), "Inventory Import", "Inventory", "Inventory.Import" });

            migrationBuilder.InsertData(
                table: "Permissions",
                columns: new[] { "Id", "CreatedAt", "Description", "Module", "Name", "UpdatedAt" },
                values: new object[] { 24, new DateTime(2025, 9, 6, 8, 11, 3, 943, DateTimeKind.Utc).AddTicks(2131), "Reports ViewDashboard", "Reports", "Reports.ViewDashboard", null });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "PasswordHash",
                value: "$2a$11$cTKcxtsKTIev8hYpiXMU3.0S4c4IyZIMYbqll8wmCB.H4qbtiWaa2");

            migrationBuilder.InsertData(
                table: "RolePermissions",
                columns: new[] { "PermissionId", "RoleId" },
                values: new object[] { 24, 1 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { 24, 1 });

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 6, 2, 32, 24, 639, DateTimeKind.Utc).AddTicks(4239));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 6, 2, 32, 24, 639, DateTimeKind.Utc).AddTicks(4286));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 6, 2, 32, 24, 639, DateTimeKind.Utc).AddTicks(4291));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "Description", "Name" },
                values: new object[] { new DateTime(2025, 9, 6, 2, 32, 24, 639, DateTimeKind.Utc).AddTicks(4300), "Users Lock", "Users.Lock" });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "Description", "Name" },
                values: new object[] { new DateTime(2025, 9, 6, 2, 32, 24, 639, DateTimeKind.Utc).AddTicks(4304), "Users Unlock", "Users.Unlock" });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "Description", "Module", "Name" },
                values: new object[] { new DateTime(2025, 9, 6, 2, 32, 24, 639, DateTimeKind.Utc).AddTicks(4314), "Roles View", "Roles", "Roles.View" });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "Description", "Name" },
                values: new object[] { new DateTime(2025, 9, 6, 2, 32, 24, 639, DateTimeKind.Utc).AddTicks(4323), "Roles Create", "Roles.Create" });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "Description", "Name" },
                values: new object[] { new DateTime(2025, 9, 6, 2, 32, 24, 639, DateTimeKind.Utc).AddTicks(4412), "Roles Update", "Roles.Update" });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedAt", "Description", "Name" },
                values: new object[] { new DateTime(2025, 9, 6, 2, 32, 24, 639, DateTimeKind.Utc).AddTicks(4416), "Roles Delete", "Roles.Delete" });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedAt", "Description", "Module", "Name" },
                values: new object[] { new DateTime(2025, 9, 6, 2, 32, 24, 639, DateTimeKind.Utc).AddTicks(4425), "Permissions View", "Permissions", "Permissions.View" });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "CreatedAt", "Description", "Name" },
                values: new object[] { new DateTime(2025, 9, 6, 2, 32, 24, 639, DateTimeKind.Utc).AddTicks(4432), "Permissions Delete", "Permissions.Delete" });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "CreatedAt", "Description", "Module", "Name" },
                values: new object[] { new DateTime(2025, 9, 6, 2, 32, 24, 639, DateTimeKind.Utc).AddTicks(4481), "Products View", "Products", "Products.View" });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "CreatedAt", "Description", "Name" },
                values: new object[] { new DateTime(2025, 9, 6, 2, 32, 24, 639, DateTimeKind.Utc).AddTicks(4487), "Products Create", "Products.Create" });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "CreatedAt", "Description", "Name" },
                values: new object[] { new DateTime(2025, 9, 6, 2, 32, 24, 639, DateTimeKind.Utc).AddTicks(4491), "Products Update", "Products.Update" });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "CreatedAt", "Description", "Name" },
                values: new object[] { new DateTime(2025, 9, 6, 2, 32, 24, 639, DateTimeKind.Utc).AddTicks(4503), "Products Delete", "Products.Delete" });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "CreatedAt", "Description", "Module", "Name" },
                values: new object[] { new DateTime(2025, 9, 6, 2, 32, 24, 639, DateTimeKind.Utc).AddTicks(4615), "Orders View", "Orders", "Orders.View" });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "CreatedAt", "Description", "Name" },
                values: new object[] { new DateTime(2025, 9, 6, 2, 32, 24, 639, DateTimeKind.Utc).AddTicks(4618), "Orders Create", "Orders.Create" });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "CreatedAt", "Description", "Name" },
                values: new object[] { new DateTime(2025, 9, 6, 2, 32, 24, 639, DateTimeKind.Utc).AddTicks(4625), "Orders Update", "Orders.Update" });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "CreatedAt", "Description", "Name" },
                values: new object[] { new DateTime(2025, 9, 6, 2, 32, 24, 639, DateTimeKind.Utc).AddTicks(4628), "Orders Delete", "Orders.Delete" });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "CreatedAt", "Description", "Name" },
                values: new object[] { new DateTime(2025, 9, 6, 2, 32, 24, 639, DateTimeKind.Utc).AddTicks(4633), "Orders Process", "Orders.Process" });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 21,
                columns: new[] { "CreatedAt", "Description", "Module", "Name" },
                values: new object[] { new DateTime(2025, 9, 6, 2, 32, 24, 639, DateTimeKind.Utc).AddTicks(4639), "Inventory View", "Inventory", "Inventory.View" });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 22,
                columns: new[] { "CreatedAt", "Description", "Name" },
                values: new object[] { new DateTime(2025, 9, 6, 2, 32, 24, 639, DateTimeKind.Utc).AddTicks(4642), "Inventory Import", "Inventory.Import" });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 23,
                columns: new[] { "CreatedAt", "Description", "Module", "Name" },
                values: new object[] { new DateTime(2025, 9, 6, 2, 32, 24, 639, DateTimeKind.Utc).AddTicks(4647), "Reports ViewDashboard", "Reports", "Reports.ViewDashboard" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "PasswordHash",
                value: "$2a$11$FeQyi2Nt4/ni.aimyd2LVesASys/uc8qCeUhlhANcO2NZ72Cp2w3u");
        }
    }
}
