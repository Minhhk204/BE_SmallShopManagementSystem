using BE__Small_Shop_Management_System.Models;

namespace BE__Small_Shop_Management_System.Repositories
{
    public interface ISystemLogRepository : IGenericRepository<SystemLog>
    {
        // nếu muốn thêm filter custom thì thêm ở đây, ví dụ:
        // Task<IEnumerable<SystemLog>> GetByUserIdAsync(int userId);
    }
}
