using BE__Small_Shop_Management_System.DataContext;
using BE__Small_Shop_Management_System.Models;
using Microsoft.EntityFrameworkCore;

namespace BE__Small_Shop_Management_System.Repositories
{
    public class CartItemRepository : GenericRepository<CartItem>, ICartItemRepository
    {
        public CartItemRepository(AppDbContext context) : base(context) { }

        // Lấy CartItem theo user và product
        public async Task<CartItem?> GetByUserAndProductAsync(int userId, int productId)
        {
            return await _dbSet
                .Include(c => c.Product)
                .ThenInclude(p => p.Images) 
                .FirstOrDefaultAsync(c => c.UserId == userId && c.ProductId == productId);
        }

        // Lấy tất cả CartItem của user
        public async Task<IEnumerable<CartItem>> GetCartByUserAsync(int userId)
        {
            return await _dbSet
                .Where(c => c.UserId == userId)
                .Include(c => c.Product)
                .ThenInclude(p => p.Images)
                .ToListAsync();
        }

        // Thêm hoặc cập nhật CartItem
        public async Task AddOrUpdateCartItemAsync(int userId, int productId, int quantity)
        {
            var cartItem = await GetByUserAndProductAsync(userId, productId);

            if (cartItem != null)
            {
                cartItem.Quantity += quantity;
                _dbSet.Update(cartItem);
            }
            else
            {
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

        // Cập nhật trạng thái isSelected của CartItem
        public async Task UpdateSelectionAsync(int userId, int productId, bool isSelected)
        {
            var item = await _dbSet
                .FirstOrDefaultAsync(c => c.UserId == userId && c.ProductId == productId);

            if (item != null)
            {
                item.IsSelected = isSelected;
                _dbSet.Update(item); 
            }
        }

        // Cập nhật số lượng sản phẩm trong giỏ hàng, có kiểm tra tồn kho
        public async Task<bool> UpdateQuantityAsync(int userId, int productId, int quantity)
        {
            // Lấy sản phẩm để kiểm tra tồn kho
            var product = await _context.Products
                .FirstOrDefaultAsync(p => p.Id == productId);

            if (product == null)
                throw new Exception("Sản phẩm không tồn tại.");

            if (quantity > product.Stock)
                throw new Exception($"Không đủ hàng trong kho. Tồn kho hiện tại: {product.Stock}");

            // Lấy cart item hiện tại của user
            var cartItem = await GetCartItemByUserAndProductAsync(userId, productId);

            if (cartItem == null)
            {
                if (quantity == 0)
                    return true; 

                var newItem = new CartItem
                {
                    UserId = userId,
                    ProductId = productId,
                    Quantity = quantity,
                    IsSelected = true
                };

                await _dbSet.AddAsync(newItem);
            }
            else
            {
                if (quantity == 0)
                {
                    _dbSet.Remove(cartItem); 
                }
                else
                {
                    // Cập nhật số lượng tuyệt đối
                    cartItem.Quantity = quantity;
                    _dbSet.Update(cartItem);
                }
            }

            return true;
        }


        // Xóa CartItem
        public void RemoveCartItem(CartItem cartItem)
        {
            _dbSet.Remove(cartItem);
        }
    }
}
