using Microsoft.EntityFrameworkCore;
using Test0912.Data;
using Test0912.Models;
using Test0912.Services.IService;

namespace Test0912.Services
{
    public class CandyRepository: ICandyRepository
    {
        private readonly AppDbContext _context;
        public CandyRepository(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Candy> GetAllCandy
        {
            get
            {
                return _context.Candies.Include(c => c.Category);
            }
        }
            

        public IEnumerable<Candy> GetCandyOnSale
        {
            get
            {
                return _context.Candies.Include(c => c.Category)
                    .Where(p => p.IsOnSale);
            }
        }
           

        public Candy GetCandyById(int candyId)
        {
            return _context.Candies.FirstOrDefault(c => c.CandyId == candyId);
        }
    }
}
