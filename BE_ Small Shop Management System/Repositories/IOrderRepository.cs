using BE__Small_Shop_Management_System.DTOs;
using BE__Small_Shop_Management_System.Models;
using System.Linq.Expressions;

namespace BE__Small_Shop_Management_System.Repositories
{
    public interface IOrderRepository : IGenericRepository<Order>
    {
        Task<IEnumerable<OrderDto>> GetOrdersByUserAsync(int userId);
        Task<OrderDto?> GetOrderWithItemsAsync(int orderId);
        Task<IEnumerable<OrderHistoryDto>> GetOrderHistoryByUserAsync(int userId);

        Task<Order?> GetAsync(Expression<Func<Order, bool>> predicate, string? includeProperties = null);
    }
}
