using BE__Small_Shop_Management_System.Models;

namespace BE__Small_Shop_Management_System.Repositories
{
    public interface IProductRepository : IGenericRepository<Product>
    {
        IQueryable<Product> GetProductsWithCategory();
        Task<Product?> GetByIdWithCategoryAsync(int id);

    }
}
