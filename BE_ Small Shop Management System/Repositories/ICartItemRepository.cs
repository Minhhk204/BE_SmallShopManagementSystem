using BE__Small_Shop_Management_System.Models;

namespace BE__Small_Shop_Management_System.Repositories
{
    public interface ICartItemRepository : IGenericRepository<CartItem>
    {
        Task<CartItem?> GetByUserAndProductAsync(int userId, int productId);
        Task<IEnumerable<CartItem>> GetCartByUserAsync(int userId);
        Task AddOrUpdateCartItemAsync(int userId, int productId, int quantity);
        Task<CartItem?> GetCartItemByUserAndProductAsync(int userId, int productId);
        Task UpdateSelectionAsync(int userId, int productId, bool isSelected);
        Task<bool> UpdateQuantityAsync(int userId, int productId, int quantity);

    }
}
