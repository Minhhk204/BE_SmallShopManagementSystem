using BE__Small_Shop_Management_System.DataContext;
using BE__Small_Shop_Management_System.Models;
using Microsoft.EntityFrameworkCore;

namespace BE__Small_Shop_Management_System.Repositories
{
    public class RolePermissionRepository : GenericRepository<RolePermission>, IRolePermissionRepository
    {
        private readonly AppDbContext _context;

        public RolePermissionRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        // Lấy toàn bộ quyền theo Role
        public async Task<List<Permission>> GetPermissionsByRoleIdAsync(int roleId)
            => await _context.RolePermissions
                .Where(rp => rp.RoleId == roleId)
                .Select(rp => rp.Permission)
                .AsNoTracking()
                .ToListAsync();

        // Gán nhiều quyền (replace all)
        public async Task AssignAsync(int roleId, IEnumerable<int> permissionIds)
        {
            var ids = permissionIds.Distinct().ToList();

            // Lấy quyền hiện tại
            var current = await _context.RolePermissions
                .Where(x => x.RoleId == roleId)
                .ToListAsync();

            // Xóa quyền không còn trong danh sách
            var toRemove = current.Where(x => !ids.Contains(x.PermissionId)).ToList();
            _context.RolePermissions.RemoveRange(toRemove);

            // Thêm quyền mới
            var currentIds = current.Select(x => x.PermissionId).ToHashSet();
            var toAdd = ids.Where(id => !currentIds.Contains(id))
                           .Select(id => new RolePermission { RoleId = roleId, PermissionId = id });

            await _context.RolePermissions.AddRangeAsync(toAdd);
        }

        // Gán 1 quyền
        public async Task AssignAsync(int roleId, int permissionId)
        {
            await AssignAsync(roleId, new[] { permissionId }); // gọi lại hàm nhiều
        }

        // Xóa 1 quyền
        public async Task RemoveAsync(int roleId, int permissionId)
        {
            var entity = await _context.RolePermissions
                .FirstOrDefaultAsync(x => x.RoleId == roleId && x.PermissionId == permissionId);

            if (entity != null)
                _context.RolePermissions.Remove(entity);
        }

        // Xóa nhiều quyền
        public async Task RemoveAsync(int roleId, IEnumerable<int> permissionIds)
        {
            var entities = await _context.RolePermissions
                .Where(x => x.RoleId == roleId && permissionIds.Contains(x.PermissionId))
                .ToListAsync();

            _context.RolePermissions.RemoveRange(entities);
        }

        public async Task RemoveAllByRoleIdAsync(int roleId)
        {
            var rolePermissions = _context.RolePermissions.Where(rp => rp.RoleId == roleId);
            _context.RolePermissions.RemoveRange(rolePermissions);
            await _context.SaveChangesAsync();
        }

    }

}
