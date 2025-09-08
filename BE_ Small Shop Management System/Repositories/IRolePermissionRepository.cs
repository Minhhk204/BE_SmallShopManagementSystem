using BE__Small_Shop_Management_System.Models;

namespace BE__Small_Shop_Management_System.Repositories
{
    public interface IRolePermissionRepository : IGenericRepository<RolePermission>
    {
        Task<List<Permission>> GetPermissionsByRoleIdAsync(int roleId);

        Task AssignAsync(int roleId, IEnumerable<int> permissionIds);  // gán nhiều quyền
        Task AssignAsync(int roleId, int permissionId);                // gán 1 quyền

        Task RemoveAsync(int roleId, IEnumerable<int> permissionIds);  // xóa nhiều quyền
        Task RemoveAsync(int roleId, int permissionId);                // xóa 1 quyền

        Task RemoveAllByRoleIdAsync(int roleId);

    }
}
