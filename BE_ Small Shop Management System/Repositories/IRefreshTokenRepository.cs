using BE__Small_Shop_Management_System.Models;

namespace BE__Small_Shop_Management_System.Repositories
{
    public interface IRefreshTokenRepository : IGenericRepository<RefreshToken>
    {
        Task<RefreshToken?> GetByTokenAsync(string token);
    }
}
