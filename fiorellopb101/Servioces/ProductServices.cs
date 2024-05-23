using fiorellopb101.Data;
using fiorellopb101.Models;
using fiorellopb101.Servioces.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace fiorellopb101.Servioces
{
    public class ProductServices : IProductService
    {
        private readonly AppDbContext _context;

        public ProductServices(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            return await _context.Product.Include(m => m.ProductImages).ToListAsync();
        }

        public Task<Product> GetByIdAsync(int id)
        {
            return await _context.Product.FindAsync(id)
        }

        public async Task<Product> GetByIdWithAllDatasAsync(int id)
        {
            return await _context.Product.Where(m => m.Id == id).Include(m => m.Category).Include(m => m.ProductImages).FirstOrDefaultAsync();
        }
    }
}
