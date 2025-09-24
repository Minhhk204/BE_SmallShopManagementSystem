using BE__Small_Shop_Management_System.DataContext;
using BE__Small_Shop_Management_System.Models;
using Microsoft.EntityFrameworkCore;

namespace BE__Small_Shop_Management_System.Repositories
{
    public class FavoriteRepository : GenericRepository<Favorite>, IFavoriteRepository
    {
        public FavoriteRepository(AppDbContext context) : base(context) { }

        public async Task<Favorite?> GetByUserAndProductAsync(int userId, int productId)
        {
            return await _dbSet
                .Include(f => f.Product)
                .FirstOrDefaultAsync(f => f.UserId == userId && f.ProductId == productId);
        }

        public async Task<IEnumerable<Favorite>> GetFavoritesByUserAsync(int userId)
        {
            return await _dbSet
                .Include(f => f.Product)
                .Where(f => f.UserId == userId)
                .ToListAsync();
        }
    }
}
