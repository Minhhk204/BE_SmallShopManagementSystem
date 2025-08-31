using BE__Small_Shop_Management_System.Models;

namespace BE__Small_Shop_Management_System.Repositories
{
    public interface IUserPermissionRepository : IGenericRepository<UserPermission>
    {
        Task<List<Permission>> GetPermissionsByUserIdAsync(int userId);

        
        Task AssignAsync(int userId, IEnumerable<int> permissionIds);

        
        Task RemoveAsync(int userId, IEnumerable<int> permissionIds);
    }
}
