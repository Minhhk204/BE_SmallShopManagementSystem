using BE__Small_Shop_Management_System.DTOs;
using BE__Small_Shop_Management_System.Models;

namespace BE__Small_Shop_Management_System.Repositories
{
    public interface ICategoryRepository : IGenericRepository<Category>
    {
        Task<IEnumerable<CategoryDto>> GetAllWithProductsAsync();
        Task<CategoryDto?> GetByIdWithProductsAsync(int id);
    }
}
