using Fiorello_PB101.ViewModels.Categories;
using fiorellopb101.Models;

namespace fiorellopb101.Servioces.Interfaces
{
    public interface ICategoryService 
    {
        Task<IEnumerable<Category>> GetAllAsync();
        Task<IEnumerable<CategoryProductVM>> GetAllWithProductCountAsync();
        Task<Category> GetByIdAsync(int? id);

        Task<bool> ExistAsync(string name);

        Task CreateAsync(Category category);

        Task DeleteAsync(Category category);
    }
}
