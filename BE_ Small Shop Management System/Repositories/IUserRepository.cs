using BE__Small_Shop_Management_System.Models;

namespace BE__Small_Shop_Management_System.Repositories
{
    public interface IUserRepository : IGenericRepository<User>
    {
        Task<IEnumerable<User>> GetAllWithRolesAsync();
        Task<User?> GetByIdWithRolesAsync(int id);
        Task<User?> GetByUsernameAsync(string username);
        Task<List<Role>> GetRolesAsync(int userId);
        Task<User?> GetWithRolesAndPermissionsAsync(int id);
    }
}
