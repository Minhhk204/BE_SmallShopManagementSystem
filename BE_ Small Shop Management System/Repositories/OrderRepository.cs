using BE__Small_Shop_Management_System.DataContext;
using BE__Small_Shop_Management_System.DTOs;
using BE__Small_Shop_Management_System.Models;
using Microsoft.EntityFrameworkCore;

namespace BE__Small_Shop_Management_System.Repositories
{
    public class OrderRepository : GenericRepository<Order>, IOrderRepository
    {
        public OrderRepository(AppDbContext context) : base(context) { }

        public async Task<IEnumerable<OrderDto>> GetOrdersByUserAsync(int userId)
        {
            return await _dbSet
                .Where(o => o.UserId == userId)
                .OrderByDescending(o => o.OrderDate)
                .Select(o => new OrderDto
                {
                    Id = o.Id,
                    TotalAmount = o.TotalAmount,
                    Status = o.Status,
                    OrderDate = o.OrderDate,
                    UserName = o.User.Username, // 👈 lấy từ navigation User
                    Items = o.OrderItems.Select(oi => new OrderItemDto
                    {
                        ProductId = oi.ProductId,
                        ProductName = oi.Product.Name,
                        Quantity = oi.Quantity,
                        Price = oi.Price,
                        ImageUrl = oi.Product.ImageUrl
                    }).ToList()
                })
                .ToListAsync();
        }

        public async Task<OrderDto?> GetOrderWithItemsAsync(int orderId)
        {
            return await _dbSet
                .Where(o => o.Id == orderId)
                .Select(o => new OrderDto
                {
                    Id = o.Id,
                    TotalAmount = o.TotalAmount,
                    Status = o.Status,
                    OrderDate = o.OrderDate,
                    UserName = o.User.Username, // 👈 thêm UserName
                    Items = o.OrderItems.Select(oi => new OrderItemDto
                    {
                        ProductId = oi.ProductId,
                        ProductName = oi.Product.Name,
                        Quantity = oi.Quantity,
                        Price = oi.Price,
                        ImageUrl = oi.Product.ImageUrl
                    }).ToList()
                })
                .FirstOrDefaultAsync();
        }

    }
}
