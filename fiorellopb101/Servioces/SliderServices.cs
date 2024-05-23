using fiorellopb101.Data;
using fiorellopb101.Models;
using fiorellopb101.Servioces.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace fiorellopb101.Servioces
{
    public class SliderServices : ISliderServices
    {
        private readonly AppDbContext _context;
        public SliderServices(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Slider>> GetAllasync()
        {
            return await _context.Sliders.IgnoreQueryFilters().ToListAsync();
        }

        public async Task<SliderInfo> GetSliderInfoAsync()
        {
            return await _context.SliderInfo.Where(m => !m.SoftDeleted).FirstOrDefaultAsync();
        }
    }
}
