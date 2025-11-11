using Azure.Core;
using BE__Small_Shop_Management_System.DataContext;
using BE__Small_Shop_Management_System.DTOs;
using BE__Small_Shop_Management_System.Models;
using Microsoft.EntityFrameworkCore;

namespace BE__Small_Shop_Management_System.Repositories
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        private readonly AppDbContext _context;

        public ProductRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }
        

        // Lấy product kèm category
        public IQueryable<Product> GetProductsWithCategory()
        {
            return _context.Products
                           .Include(p => p.Category)  // join với Category
                           .AsQueryable();
        }

        // Lấy 1 product theo Id kèm Category
        public async Task<Product?> GetByIdWithCategoryAsync(int id)
        {
            return await _context.Products
                                 .Include(p => p.Category)
                                 .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<IEnumerable<ProductBestSellerDto>> GetBestSellingProductsAsync(int top = 5)
        {
            var bestSellers = await _context.OrderItems
                .GroupBy(oi => oi.ProductId)
                .Select(g => new
                {
                    ProductId = g.Key,
                    TotalSold = g.Sum(oi => oi.Quantity)
                })
                .OrderByDescending(x => x.TotalSold)
                .Take(top)
                .Join(_context.Products,
                      o => o.ProductId,
                      p => p.Id,
                      (o, p) => new ProductBestSellerDto
                      {
                          Id = p.Id,
                          Name = p.Name,
                          TotalSold = o.TotalSold,
                          Price = p.Price,
                      
                      })
                .ToListAsync();
            return bestSellers;
        }

    }
}
