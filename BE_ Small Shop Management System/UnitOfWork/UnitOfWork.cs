using BE__Small_Shop_Management_System.DataContext;
using BE__Small_Shop_Management_System.Models;
using BE__Small_Shop_Management_System.Repositories;

namespace BE__Small_Shop_Management_System.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;

        public IUserRepository UserRepository { get; }
        public IRoleRepository RoleRepository { get; }
        public IPermissionRepository PermissionRepository { get; }
        public IUserPermissionRepository UserPermissionRepository { get; }
        public IRolePermissionRepository RolePermissionRepository { get; }
        public ISystemLogRepository SystemLogRepository { get; }
        public IProductRepository ProductRepository { get; }
        public IUserRoleRepository UserRoleRepository { get; }
        public IRefreshTokenRepository RefreshTokenRepository { get; }

        public IFavoriteRepository FavoriteRepository { get; }

        public UnitOfWork(
            AppDbContext context,
            IUserRepository userRepository,
            IRoleRepository roleRepository,
            IPermissionRepository permissionRepository,
            IUserPermissionRepository userPermissionRepository,
            IRolePermissionRepository rolePermissionRepository,
            ISystemLogRepository systemLogRepository,
            IProductRepository productRepository,
            IUserRoleRepository userRoleRepository,
            IRefreshTokenRepository refreshTokenRepository,
            IFavoriteRepository favoriteRepository)

        {
            _context = context;
            UserRepository = userRepository;
            RoleRepository = roleRepository;
            PermissionRepository = permissionRepository;
            UserPermissionRepository = userPermissionRepository;
            RolePermissionRepository = rolePermissionRepository;
            SystemLogRepository = systemLogRepository;
            ProductRepository = productRepository;
            UserRoleRepository = userRoleRepository;
            RefreshTokenRepository = refreshTokenRepository;
            FavoriteRepository = favoriteRepository;
        }

        public async Task<int> CompleteAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }


}
