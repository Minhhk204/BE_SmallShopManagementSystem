using BE__Small_Shop_Management_System.DataContext;
using BE__Small_Shop_Management_System.Models;
using Microsoft.EntityFrameworkCore;

namespace BE__Small_Shop_Management_System.Repositories
{
    public class UserRoleRepository : GenericRepository<UserRole>, IUserRoleRepository
    {
        private readonly AppDbContext _context;

        public UserRoleRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<UserRole?> GetByUserAndRoleAsync(int userId, int roleId)
        {
            return await _context.UserRoles
                .FirstOrDefaultAsync(ur => ur.UserId == userId && ur.RoleId == roleId);
        }
        public async Task<bool> UserHasRoleAsync(int userId, int roleId)
        {
            return await _context.UserRoles
                .AnyAsync(ur => ur.UserId == userId && ur.RoleId == roleId);
        }
        // Gán role cho user
        public async Task AssignRoleAsync(int userId, int roleId)
        {
            // check nếu đã có rồi thì không thêm nữa
            var exists = await _context.UserRoles
                .AnyAsync(ur => ur.UserId == userId && ur.RoleId == roleId);

            if (!exists)
            {
                var userRole = new UserRole
                {
                    UserId = userId,
                    RoleId = roleId
                };

                await _context.UserRoles.AddAsync(userRole);
                await _context.SaveChangesAsync();
            }
        }

        // Xoá role khỏi user
        public async Task RemoveRoleAsync(int userId, int roleId)
        {
            var entity = await _context.UserRoles
                .FirstOrDefaultAsync(ur => ur.UserId == userId && ur.RoleId == roleId);

            if (entity != null)
            {
                _context.UserRoles.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }
    }
}
