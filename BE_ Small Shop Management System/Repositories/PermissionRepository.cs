using BE__Small_Shop_Management_System.DataContext;
using BE__Small_Shop_Management_System.Models;
using Microsoft.EntityFrameworkCore;

namespace BE__Small_Shop_Management_System.Repositories
{

    public class PermissionRepository : GenericRepository<Permission>, IPermissionRepository
    {
        private readonly AppDbContext _context;
        public PermissionRepository(AppDbContext context) : base(context) => _context = context;

        public async Task<IEnumerable<Permission>> GetByIdsAsync(IEnumerable<int> ids)
            => await _context.Permissions.Where(p => ids.Contains(p.Id)).ToListAsync();

        public async Task<IEnumerable<Permission>> GetAllPermissionsAsync()
            => await _context.Permissions.AsNoTracking().ToListAsync();

        public async Task<Permission?> GetPermissionByNameAsync(string name)
            => await _context.Permissions.AsNoTracking().FirstOrDefaultAsync(p => p.Name == name);
    }


}

