using BE__Small_Shop_Management_System.Models;

namespace BE__Small_Shop_Management_System.Repositories
{
    public interface IInventoryHistoryRepository : IGenericRepository<InventoryHistory>
    {
        Task<IEnumerable<InventoryHistory>> GetByProductIdAsync(int productId);
        Task<IEnumerable<InventoryHistory>> GetByDateRangeAsync(DateTime startDate, DateTime endDate);
    }
}
