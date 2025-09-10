using BE__Small_Shop_Management_System.DataContext;
using BE__Small_Shop_Management_System.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace BE__Small_Shop_Management_System.Repositories
{
    public class RoleRepository : GenericRepository<Role>, IRoleRepository
    {
        private readonly AppDbContext _context;

        public RoleRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }
        public async Task<Role?> GetWithPermissionsAsync(int roleId)
        {
            return await _context.Roles
                .Include(r => r.RolePermissions)
                    .ThenInclude(rp => rp.Permission)
                .FirstOrDefaultAsync(r => r.Id == roleId);
        }

        public async Task AssignPermissionsAsync(int roleId, IEnumerable<int> permissionIds)
        {
            foreach (var pid in permissionIds)
            {
                if (!_context.RolePermissions.Any(rp => rp.RoleId == roleId && rp.PermissionId == pid))
                {
                    _context.RolePermissions.Add(new RolePermission { RoleId = roleId, PermissionId = pid });
                }
            }
            await _context.SaveChangesAsync();
        }

        public async Task RemovePermissionAsync(int roleId, int permissionId)
        {
            var rp = await _context.RolePermissions.FirstOrDefaultAsync(x => x.RoleId == roleId && x.PermissionId == permissionId);
            if (rp != null)
            {
                _context.RolePermissions.Remove(rp);
                await _context.SaveChangesAsync();
            }
        }
        public async Task<IEnumerable<Role>> GetAllWithUsersAsync()
        {
            return await _context.Roles
         .Include(r => r.UserRoles)
         .ToListAsync();
        }

        public async Task<Role?> GetByIdWithUsersAsync(int id)
        {
            return await _context.Roles
                .Include(r => r.UserRoles)
                .FirstOrDefaultAsync(r => r.Id == id);
        }
        public async Task<IEnumerable<Role>> FindWithUsersAsync(Expression<Func<Role, bool>> predicate)
        {
            return await _context.Roles
                .Include(r => r.UserRoles)
                .Where(predicate)
                .ToListAsync();
        }
    }

}
