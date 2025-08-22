using BE__Small_Shop_Management_System.Models;
using BE__Small_Shop_Management_System.Repositories;

namespace BE__Small_Shop_Management_System.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IUserRepository Users { get; }
        IProductRepository Products { get; }
        IGenericRepository<Role> Roles { get; }
        IUserRoleRepository UserRoles { get; }
        Task<int> CompleteAsync();
    }
}
