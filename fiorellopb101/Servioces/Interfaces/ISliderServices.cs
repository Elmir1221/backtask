using fiorellopb101.Models;

namespace fiorellopb101.Servioces.Interfaces
{
    public interface ISliderServices
    {
        Task<Dictionary<string, string>> GetAllAsync();
        Task<SliderInfo> GetSliderInfoAsync();
    }
}
