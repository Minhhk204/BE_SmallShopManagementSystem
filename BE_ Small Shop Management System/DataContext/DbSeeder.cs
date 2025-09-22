using BE__Small_Shop_Management_System.Constants;
using BE__Small_Shop_Management_System.Models;
using Microsoft.EntityFrameworkCore;

namespace BE__Small_Shop_Management_System.DataContext
{
    public static class DbSeeder
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            var moduleTranslations = new Dictionary<string, string>
            {
                { "Users", "Người dùng" },
                { "Roles", "Vai trò" },
                { "Permissions", "Quyền" },
                { "Products", "Sản phẩm" },
                { "Orders", "Đơn hàng" },
                { "Inventory", "Kho" },
                { "Reports", "Báo cáo" }
            };
                        var permissionDescriptions = new Dictionary<string, string>
            {
                { "Users.View", "Xem danh sách người dùng" },
                { "Users.Create", "Tạo mới người dùng" },
                { "Users.Update", "Cập nhật thông tin người dùng" },
                { "Users.Delete", "Xóa người dùng" },
                { "Users.Lock", "Khóa tài khoản người dùng" },
                { "Users.Unlock", "Mở khóa tài khoản người dùng" },

                { "Roles.View", "Xem danh sách vai trò" },
                { "Roles.Create", "Tạo mới vai trò" },
                { "Roles.Update", "Cập nhật vai trò" },
                { "Roles.Delete", "Xóa vai trò" },

                { "Permissions.View", "Xem danh sách quyền" },
                { "Permissions.Delete", "Xóa quyền" },

                { "Products.View", "Xem danh sách sản phẩm" },
                { "Products.Create", "Thêm mới sản phẩm" },
                { "Products.Update", "Cập nhật sản phẩm" },
                { "Products.Delete", "Xóa sản phẩm" },

                { "Orders.View", "Xem danh sách đơn hàng" },
                { "Orders.Create", "Tạo mới đơn hàng" },
                { "Orders.Update", "Cập nhật đơn hàng" },
                { "Orders.Delete", "Xóa đơn hàng" },
                { "Orders.Process", "Xử lý đơn hàng" },

                { "Inventory.View", "Xem tồn kho" },
                { "Inventory.Import", "Nhập kho" },

                { "Reports.ViewDashboard", "Xem báo cáo tổng quan" }
            };
            // ===== Permissions =====
            var permissions = PermissionConstants.All()
                .Select((key, idx) => new Permission
                {
                    Id = idx + 1,
                    Name = key,                          // "Users.View"
                    Module = moduleTranslations.ContainsKey(key.Split('.')[0])
                        ? moduleTranslations[key.Split('.')[0]]
                        : key.Split('.')[0],
                    Description = permissionDescriptions.ContainsKey(key)
                        ? permissionDescriptions[key]
                        : key.Replace('.', ' ')
                }).ToList();

            modelBuilder.Entity<Permission>().HasData(permissions);

            // ===== Roles =====
            modelBuilder.Entity<Role>().HasData(
                new Role { Id = 1, Name = "Admin" },
                new Role { Id = 2, Name = "Seller" },
                new Role { Id = 3, Name = "Customer" }
            );

            // ===== Admin user =====
            modelBuilder.Entity<User>().HasData(new User
            {
                Id = 1,
                Username = "admin",
                Email = "admin@system.com",
                PasswordHash = BCrypt.Net.BCrypt.HashPassword("Admin@123"),
                IsActive = true,
                IsEmailConfirmed = true,
                IsDeleted = false,
                FullName = "Nguyen Van Minh",
                PhoneNumber = "0123456789"
            });


            modelBuilder.Entity<UserRole>().HasData(new UserRole { UserId = 1, RoleId = 1 });

            // ===== Admin có tất cả quyền =====
            modelBuilder.Entity<RolePermission>().HasData(
                permissions.Select(p => new RolePermission { RoleId = 1, PermissionId = p.Id })
            );
        }
    }
}
