using BE__Small_Shop_Management_System.DataContext;
using BE__Small_Shop_Management_System.DTOs;
using BE__Small_Shop_Management_System.Models;
using Microsoft.EntityFrameworkCore;

namespace BE__Small_Shop_Management_System.Repositories
{
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(AppDbContext context) : base(context) { }

        public async Task<IEnumerable<CategoryDto>> GetAllWithProductsAsync()
        {
            return await _dbSet
                .Include(c => c.Products)
                .Select(c => new CategoryDto
                {
                    Id = c.Id,
                    Name = c.Name,
                    Products = c.Products.Select(p => new ProductDto
                    {
                        Id = p.Id,
                        Name = p.Name,
                        Description = p.Description,
                        Price = p.Price,
                        Stock = p.Stock,
                        ImageUrl = p.ImageUrl
                    }).ToList()
                })
                .ToListAsync();
        }

        public async Task<CategoryDto?> GetByIdWithProductsAsync(int id)
        {
            return await _dbSet
                .Where(c => c.Id == id)
                .Include(c => c.Products)
                .Select(c => new CategoryDto
                {
                    Id = c.Id,
                    Name = c.Name,
                    Products = c.Products.Select(p => new ProductDto
                    {
                        Id = p.Id,
                        Name = p.Name,
                        Description = p.Description,
                        Price = p.Price,
                        Stock = p.Stock,
                        ImageUrl = p.ImageUrl
                    }).ToList()
                })
                .FirstOrDefaultAsync();
        }
    }

}
