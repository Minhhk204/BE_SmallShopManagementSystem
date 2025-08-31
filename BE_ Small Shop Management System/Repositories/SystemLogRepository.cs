using BE__Small_Shop_Management_System.DataContext;
using BE__Small_Shop_Management_System.Models;

namespace BE__Small_Shop_Management_System.Repositories
{
    public class SystemLogRepository : GenericRepository<SystemLog>, ISystemLogRepository
    {
        private readonly AppDbContext _context;

        public SystemLogRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

       
    }
    
    
}
