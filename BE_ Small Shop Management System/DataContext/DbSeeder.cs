using BE__Small_Shop_Management_System.Constants;
using BE__Small_Shop_Management_System.Models;
using Microsoft.EntityFrameworkCore;

namespace BE__Small_Shop_Management_System.DataContext
{
    public static class DbSeeder
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            // ===== Permissions =====
            var permissions = PermissionConstants.All()
                .Select((key, idx) => new Permission
                {
                    Id = idx + 1,
                    Name = key,                          // "Users.View"
                    Module = key.Split('.')[0],          // "Users"
                    Description = key.Replace('.', ' ')  // tùy bạn mô tả đẹp hơn
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
