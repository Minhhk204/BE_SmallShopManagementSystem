using BE__Small_Shop_Management_System.DataContext;
using BE__Small_Shop_Management_System.Models;
using Microsoft.EntityFrameworkCore;

namespace BE__Small_Shop_Management_System.Repositories
{
    public class UserPermissionRepository : GenericRepository<UserPermission>, IUserPermissionRepository
    {
        private readonly AppDbContext _context;

        public UserPermissionRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

       

        public Task<List<Permission>> GetPermissionsByUserIdAsync(int userId)
            => _context.UserPermissions
                .Where(up => up.UserId == userId)
                .Select(up => up.Permission)
                .AsNoTracking()
                .ToListAsync();

        public async Task AssignAsync(int userId, IEnumerable<int> permissionIds)
        {
            var ids = permissionIds.Distinct().ToList();

            var current = await _context.UserPermissions
                .Where(x => x.UserId == userId)
                .ToListAsync();

            var toRemove = current.Where(x => !ids.Contains(x.PermissionId)).ToList();
            _context.UserPermissions.RemoveRange(toRemove);

            var currentIds = current.Select(x => x.PermissionId).ToHashSet();
            var toAdd = ids.Where(id => !currentIds.Contains(id))
                           .Select(id => new UserPermission { UserId = userId, PermissionId = id });
            await _context.UserPermissions.AddRangeAsync(toAdd);
        }

        public async Task RemoveAsync(int userId, IEnumerable<int> permissionIds)
        {
            var ids = permissionIds.ToList();
            var toRemove = await _context.UserPermissions
                .Where(x => x.UserId == userId && ids.Contains(x.PermissionId))
                .ToListAsync();
            _context.UserPermissions.RemoveRange(toRemove);
        }
    }

}
