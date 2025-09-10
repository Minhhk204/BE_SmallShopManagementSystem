using BE__Small_Shop_Management_System.Models;
using System.Linq.Expressions;

namespace BE__Small_Shop_Management_System.Repositories
{
    public interface IRoleRepository : IGenericRepository<Role>
    {
        Task<Role?> GetWithPermissionsAsync(int roleId);
        Task AssignPermissionsAsync(int roleId, IEnumerable<int> permissionIds);
        Task RemovePermissionAsync(int roleId, int permissionId);
        Task<IEnumerable<Role>> GetAllWithUsersAsync();
        Task<Role?> GetByIdWithUsersAsync(int id);
        Task<IEnumerable<Role>> FindWithUsersAsync(Expression<Func<Role, bool>> predicate);
    }
}
