using fiorellopb101.Models;
using fiorellopb101.ViewModels.Blog;

namespace fiorellopb101.Servioces.Interfaces
{
    public interface IBlogService
    {
        Task<IEnumerable<BlogVM>> GetAllAsync( int? take=null);
        //Task<SliderInfo> GetSliderInfoAsync();
        Task<Blog> GetByIdAsync(int? id);


        Task<bool> ExistAsync(string title, string desc);

        Task CreateAsync(Blog blog);

        Task DeleteAsync(Blog blog);

    }
}
