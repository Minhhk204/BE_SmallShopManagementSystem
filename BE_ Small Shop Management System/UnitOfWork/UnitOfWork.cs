using BE__Small_Shop_Management_System.DataContext;
using BE__Small_Shop_Management_System.Models;
using BE__Small_Shop_Management_System.Repositories;

namespace BE__Small_Shop_Management_System.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;

        public IUserRepository Users { get; private set; }
        public IGenericRepository<Role> Roles { get; private set; }

        public IProductRepository Products { get; }
        public IUserRoleRepository UserRoles { get; private set; }

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
            Users = new UserRepository(_context);
            Roles = new GenericRepository<Role>(_context);
            Products = new ProductRepository(_context);
            UserRoles = new UserRoleRepository(_context);

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
