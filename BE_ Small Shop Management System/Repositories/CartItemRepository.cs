using BE__Small_Shop_Management_System.DataContext;
using BE__Small_Shop_Management_System.Models;
using Microsoft.EntityFrameworkCore;

namespace BE__Small_Shop_Management_System.Repositories
{
    public class CartItemRepository : GenericRepository<CartItem>, ICartItemRepository
    {
        public CartItemRepository(AppDbContext context) : base(context) { }

        // Lấy CartItem theo user và product, kèm product + ảnh
        public async Task<CartItem?> GetByUserAndProductAsync(int userId, int productId)
        {
            return await _dbSet
                .Include(c => c.Product)
                .ThenInclude(p => p.Images) // <-- include danh sách ảnh product
                .FirstOrDefaultAsync(c => c.UserId == userId && c.ProductId == productId);
        }

        // Lấy tất cả CartItem của user, kèm product + ảnh
        public async Task<IEnumerable<CartItem>> GetCartByUserAsync(int userId)
        {
            return await _dbSet
                .Where(c => c.UserId == userId)
                .Include(c => c.Product)
                .ThenInclude(p => p.Images) // <-- include danh sách ảnh product
                .ToListAsync();
        }

        // Thêm hoặc cập nhật CartItem
        public async Task AddOrUpdateCartItemAsync(int userId, int productId, int quantity)
        {
            var cartItem = await GetByUserAndProductAsync(userId, productId);

            if (cartItem != null)
            {
                // Cập nhật số lượng
                cartItem.Quantity += quantity;
                _dbSet.Update(cartItem);
            }
            else
            {
                // Thêm mới
                cartItem = new CartItem
                {
                    UserId = userId,
                    ProductId = productId,
                    Quantity = quantity
                };
                await _dbSet.AddAsync(cartItem);
            }
        }
        // Lấy CartItem theo user và product 
        public async Task<CartItem?> GetCartItemByUserAndProductAsync(int userId, int productId)
        {
            return await _dbSet
                .FirstOrDefaultAsync(c => c.UserId == userId && c.ProductId == productId);
        }


        // Xóa CartItem
        public void RemoveCartItem(CartItem cartItem)
        {
            _dbSet.Remove(cartItem);
        }
    }
}
