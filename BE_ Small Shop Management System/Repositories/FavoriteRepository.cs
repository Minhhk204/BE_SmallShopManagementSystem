using BE__Small_Shop_Management_System.DataContext;
using BE__Small_Shop_Management_System.Models;
using Microsoft.EntityFrameworkCore;

namespace BE__Small_Shop_Management_System.Repositories
{
    public class FavoriteRepository : GenericRepository<Favorite>, IFavoriteRepository
    {
        public FavoriteRepository(AppDbContext context) : base(context) { }

        // Lấy 1 favorite theo user + product
        public async Task<Favorite?> GetByUserAndProductAsync(int userId, int productId)
        {
            return await _dbSet
                .Include(f => f.Product)
                    .ThenInclude(p => p.Images) // <-- Include ảnh của product
                .FirstOrDefaultAsync(f => f.UserId == userId && f.ProductId == productId);
        }

        // Lấy tất cả favorite của user
        public async Task<IEnumerable<Favorite>> GetFavoritesByUserAsync(int userId)
        {
            return await _dbSet
                .Where(f => f.UserId == userId)
                .Include(f => f.Product)
                    .ThenInclude(p => p.Images) // <-- Include ảnh của product
                .ToListAsync();
        }
    }
}
