using BE__Small_Shop_Management_System.Models;
using BE__Small_Shop_Management_System.Repositories;

namespace BE__Small_Shop_Management_System.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IUserRepository UserRepository { get; }
        IRoleRepository RoleRepository { get; }
        IPermissionRepository PermissionRepository { get; }
        IUserPermissionRepository UserPermissionRepository { get; }
        IRolePermissionRepository RolePermissionRepository { get; }
        ISystemLogRepository SystemLogRepository { get; }
        IProductRepository ProductRepository { get; }
        IUserRoleRepository UserRoleRepository { get; }
        IRefreshTokenRepository RefreshTokenRepository { get; }
        IFavoriteRepository FavoriteRepository { get; }

        ICartItemRepository CartItemRepository { get; }
        IOrderRepository OrderRepository { get; }
        IOrderItemRepository OrderItemRepository { get; }
        ICategoryRepository CategoryRepository { get; }
        Task<int> CompleteAsync();
    }
}
