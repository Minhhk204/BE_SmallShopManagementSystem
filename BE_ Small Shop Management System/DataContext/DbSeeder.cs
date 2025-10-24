using BE__Small_Shop_Management_System.Constants;
using BE__Small_Shop_Management_System.Models;
using Microsoft.EntityFrameworkCore;

namespace BE__Small_Shop_Management_System.DataContext
{
    public static class DbSeeder
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            // ==== Module dịch tiếng Việt ====
            var moduleTranslations = new Dictionary<string, string>
            {
                { "Users", "Người dùng" },
                { "Roles", "Vai trò" },
                { "Permissions", "Quyền" },
                { "Products", "Sản phẩm" },
                { "Orders", "Đơn hàng" },
                { "Inventory", "Kho" },
                { "Reports", "Báo cáo" },
                { "Cart", "Giỏ hàng" },
                { "Favorites", "Yêu thích" },
                { "Categories", "Danh mục" },
                { "InventoryHistory", "Lịch sử kho" },
                { "OrderItems", "Chi tiết đơn hàng" },
                { "PasswordPolicy", "Chính sách mật khẩu" },
                { "SystemLogs", "Nhật ký hệ thống" },
                { "Dashboard", "Tổng quan" },
            };

            // ==== Mô tả quyền ====
            var permissionDescriptions = new Dictionary<string, string>
            {
                // Users
                { "Users.View", "Xem danh sách người dùng" },
                { "Users.Create", "Tạo mới người dùng" },
                { "Users.Update", "Cập nhật thông tin người dùng" },
                { "Users.Delete", "Xóa người dùng" },
                { "Users.Lock", "Khóa tài khoản người dùng" },
                { "Users.Unlock", "Mở khóa tài khoản người dùng" },

                // Roles
                { "Roles.View", "Xem danh sách vai trò" },
                { "Roles.Create", "Tạo mới vai trò" },
                { "Roles.Update", "Cập nhật vai trò" },
                { "Roles.Delete", "Xóa vai trò" },

                // Permissions
                { "Permissions.View", "Xem danh sách quyền" },
                { "Permissions.Delete", "Xóa quyền" },

                // Products
                { "Products.View", "Xem danh sách sản phẩm" },
                { "Products.Create", "Thêm mới sản phẩm" },
                { "Products.Update", "Cập nhật sản phẩm" },
                { "Products.Delete", "Xóa sản phẩm" },

                // Orders
                { "Orders.View", "Xem danh sách đơn hàng" },
                { "Orders.Create", "Tạo mới đơn hàng" },
                { "Orders.Update", "Cập nhật đơn hàng" },
                { "Orders.Delete", "Xóa đơn hàng" },
                { "Orders.Process", "Xử lý đơn hàng" },

                // Inventory
                { "Inventory.View", "Xem kho hàng" },
                { "Inventory.Import", "Nhập hàng vào kho" },

                // Reports
                { "Reports.ViewDashboard", "Xem báo cáo thống kê" },

                // Cart
                { "Cart.View", "Xem giỏ hàng" },
                { "Cart.Add", "Thêm sản phẩm vào giỏ hàng" },
                { "Cart.Update", "Cập nhật giỏ hàng" },
                { "Cart.Delete", "Xóa sản phẩm khỏi giỏ hàng" },

                // Favorites
                { "Favorites.View", "Xem danh sách yêu thích" },
                { "Favorites.Add", "Thêm sản phẩm yêu thích" },
                { "Favorites.Delete", "Xóa sản phẩm yêu thích" },

                // Categories
                { "Categories.View", "Xem danh mục sản phẩm" },
                { "Categories.Create", "Tạo mới danh mục" },
                { "Categories.Update", "Cập nhật danh mục" },
                { "Categories.Delete", "Xóa danh mục" },

                // InventoryHistory
                { "InventoryHistory.View", "Xem lịch sử nhập xuất kho" },
                { "InventoryHistory.Import", "Nhập hàng vào kho" },

                // OrderItems
                { "OrderItems.View", "Xem chi tiết sản phẩm trong đơn hàng" },

                // PasswordPolicy
                { "PasswordPolicy.View", "Xem chính sách mật khẩu" },
                { "PasswordPolicy.Update", "Cập nhật chính sách mật khẩu" },

                // SystemLogs
                { "SystemLogs.View", "Xem nhật ký hệ thống" },
                { "SystemLogs.Delete", "Xóa nhật ký hệ thống" },

                // Dashboard
                { "Dashboard.View", "Xem trang tổng quan" },
            };

            // ==== 1. Tạo danh sách toàn bộ quyền ====
            var permissions = PermissionConstants.All()
                .Select((key, idx) => new Permission
                {
                    Id = idx + 1,
                    Name = key,
                    Module = moduleTranslations.ContainsKey(key.Split('.')[0])
                        ? moduleTranslations[key.Split('.')[0]]
                        : key.Split('.')[0],
                    Description = permissionDescriptions.ContainsKey(key)
                        ? permissionDescriptions[key]
                        : key.Replace('.', ' ')
                }).ToList();

            modelBuilder.Entity<Permission>().HasData(permissions);

            // ==== 2. Tạo 3 vai trò ====
            modelBuilder.Entity<Role>().HasData(
                new Role { Id = 1, Name = "Admin" },
                new Role { Id = 2, Name = "Seller" },
                new Role { Id = 3, Name = "Customer" }
            );

            // ==== 3. Tạo tài khoản admin mặc định ====
            modelBuilder.Entity<User>().HasData(new User
            {
                Id = 1,
                Username = "admin",
                Email = "admin@system.com",
                PasswordHash = BCrypt.Net.BCrypt.HashPassword("Admin@123"),
                IsActive = true,
                IsEmailConfirmed = true,
                IsDeleted = false,
                FullName = "Trần Văn Khởi",
                PhoneNumber = "0356995423"
            });

            modelBuilder.Entity<UserRole>().HasData(new UserRole { UserId = 1, RoleId = 1 });

            // ==== 4. Phân quyền cho từng vai trò ====
            // Admin có toàn quyền
            var adminRolePermissions = permissions
                .Select(p => new RolePermission { RoleId = 1, PermissionId = p.Id })
                .ToList();

            // Seller chỉ có quyền liên quan tới sản phẩm, đơn hàng, kho, danh mục
            var sellerModules = new[] { "Products", "Orders", "Inventory", "InventoryHistory", "Categories" };
            var sellerRolePermissions = permissions
                .Where(p => sellerModules.Any(m => p.Name.StartsWith(m)))
                .Select(p => new RolePermission { RoleId = 2, PermissionId = p.Id })
                .ToList();

            // Customer chỉ có quyền xem sản phẩm, giỏ hàng, đơn hàng, yêu thích
            var customerModules = new[] { "Products", "Cart", "Favorites", "Orders" };
            var customerRolePermissions = permissions
                .Where(p => customerModules.Any(m => p.Name.StartsWith(m)))
                .Select(p => new RolePermission { RoleId = 3, PermissionId = p.Id })
                .ToList();

            // Gộp tất cả vào seed
            modelBuilder.Entity<RolePermission>().HasData(
                adminRolePermissions.Concat(sellerRolePermissions).Concat(customerRolePermissions)
            );
        }
    }
}
