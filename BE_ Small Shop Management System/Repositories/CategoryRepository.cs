using BE__Small_Shop_Management_System.DataContext;
using BE__Small_Shop_Management_System.DTOs;
using BE__Small_Shop_Management_System.Models;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using AutoMapper.QueryableExtensions;

namespace BE__Small_Shop_Management_System.Repositories
{
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        private readonly IMapper _mapper;

        public CategoryRepository(AppDbContext context, IMapper mapper) : base(context)
        {
            _mapper = mapper;
        }

        public async Task<IEnumerable<CategoryDto>> GetAllWithProductsAsync()
        {
            return await _dbSet
                .Include(c => c.Products)
                .ProjectTo<CategoryDto>(_mapper.ConfigurationProvider) 
                .ToListAsync();
        }

        public async Task<CategoryDto?> GetByIdWithProductsAsync(int id)
        {
            return await _dbSet
                .Where(c => c.Id == id)
                .Include(c => c.Products)
                .ProjectTo<CategoryDto>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync();
        }
    }
}
