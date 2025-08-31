using BE__Small_Shop_Management_System.Models;

namespace BE__Small_Shop_Management_System.Repositories
{
    public interface IUserRoleRepository : IGenericRepository<UserRole>
    {
        Task<UserRole?> GetByUserAndRoleAsync(int userId, int roleId);
        Task<bool> UserHasRoleAsync(int userId, int roleId);
        Task AssignRoleAsync(int userId, int roleId);
        Task RemoveRoleAsync(int userId, int roleId);
    }
}
