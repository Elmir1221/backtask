using fiorellopb101.Models;
using fiorellopb101.Servioces.Interfaces;
using fiorellopb101.ViewModels.Blog;

namespace fiorellopb101.ViewModels
{
    public class HomeVM
    {
        public IEnumerable<Slider> Sliders { get; set; }
        public SliderInfo SliderInfo { get; set; }
        public IEnumerable<BlogVM> Blogs { get; set; }
        public IEnumerable<Category> Categories { get; set; }
        public IEnumerable<Product> Products { get; set; }



    }
}
