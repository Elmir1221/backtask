using fiorellopb101.Data;
using fiorellopb101.Models;

namespace fiorellopb101.Servioces.Interfaces
{
    public interface ISettingService
    {
        Task<Dictionary<string, string>> GetAllAsync();

    }
}
