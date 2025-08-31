using BE__Small_Shop_Management_System.Models;

namespace BE__Small_Shop_Management_System.Repositories
{
    public interface IUserRepository : IGenericRepository<User>
    {
        Task<User?> GetWithRolesAndPermissionsAsync(int id);
        Task<User?> GetByUsernameAsync(string username);

        Task<List<Role>> GetRolesAsync(int userId);
    }
}
