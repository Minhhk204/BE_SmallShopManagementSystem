using BE__Small_Shop_Management_System.Models;

namespace BE__Small_Shop_Management_System.Repositories
{
    public interface IRoleRepository : IGenericRepository<Role>
    {
        Task<Role?> GetWithPermissionsAsync(int roleId);
        Task AssignPermissionsAsync(int roleId, IEnumerable<int> permissionIds);
        Task RemovePermissionAsync(int roleId, int permissionId);
    }
}
