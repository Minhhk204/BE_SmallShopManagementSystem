using BE__Small_Shop_Management_System.Models;

namespace BE__Small_Shop_Management_System.Repositories
{
    public interface IProductRepository : IGenericRepository<Product>
    {
        // Thêm các phương thức đặc thù nếu cần, ví dụ:
        Task<IEnumerable<Product>> GetBySellerIdAsync(int sellerId);
    }
}
