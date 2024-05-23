using fiorellopb101.Data;
using fiorellopb101.Servioces.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace fiorellopb101.Servioces
{
    public class SettingService: ISettingService
    {
        private readonly AppDbContext _context;

        public SettingService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Dictionary<string, string>> GetAllAsync()
        {
            return await _context.Settings
                .ToDictionaryAsync(m => m.Key, m => m.Value);
        }
    }
}
