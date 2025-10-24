using BE__Small_Shop_Management_System.DataContext;
using BE__Small_Shop_Management_System.Models;
using Microsoft.EntityFrameworkCore;

namespace BE__Small_Shop_Management_System.Repositories
{
    public class InventoryHistoryRepository : GenericRepository<InventoryHistory>, IInventoryHistoryRepository
    {
        private readonly AppDbContext _context;

        public InventoryHistoryRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<InventoryHistory>> GetByProductIdAsync(int productId)
        {
            return await _context.InventoryHistories
                .Include(i => i.Product)
                .Where(i => i.ProductId == productId)
                .OrderByDescending(i => i.CreatedAt)
                .ToListAsync();
        }

        public async Task<IEnumerable<InventoryHistory>> GetByDateRangeAsync(DateTime startDate, DateTime endDate)
        {
            return await _context.InventoryHistories
                .Include(i => i.Product)
                .Where(i => i.CreatedAt >= startDate && i.CreatedAt <= endDate)
                .OrderByDescending(i => i.CreatedAt)
                .ToListAsync();
        }
    }
}
