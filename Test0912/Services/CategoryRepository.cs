using Test0912.Data;
using Test0912.Models;
using Test0912.Services.IService;

namespace Test0912.Services
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly AppDbContext _context;
        public CategoryRepository(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Category> GetCategories 
            => _context.Categories;
    }
}
