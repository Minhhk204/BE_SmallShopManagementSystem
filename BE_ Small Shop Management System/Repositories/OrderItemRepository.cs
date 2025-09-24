using BE__Small_Shop_Management_System.DataContext;
using BE__Small_Shop_Management_System.Models;
using Microsoft.EntityFrameworkCore;

namespace BE__Small_Shop_Management_System.Repositories
{
    public class OrderItemRepository : GenericRepository<OrderItem>, IOrderItemRepository
    {
        public OrderItemRepository(AppDbContext context) : base(context) { }

        public async Task<IEnumerable<OrderItem>> GetItemsByOrderAsync(int orderId)
        {
            return await _dbSet
                .Include(oi => oi.Product)
                .Where(oi => oi.OrderId == orderId)
                .ToListAsync();
        }
    }
}
