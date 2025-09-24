using BE__Small_Shop_Management_System.Models;

namespace BE__Small_Shop_Management_System.Repositories
{
    public interface IFavoriteRepository : IGenericRepository<Favorite>
    {
        Task<Favorite?> GetByUserAndProductAsync(int userId, int productId);
        Task<IEnumerable<Favorite>> GetFavoritesByUserAsync(int userId);
    }
}
