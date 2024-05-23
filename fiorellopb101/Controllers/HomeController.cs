using fiorellopb101.Servioces.Interfaces;
using fiorellopb101.ViewModels;
using fiorellopb101.ViewModels.Baskets;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace fiorellopb101.Controllers
{
    public class HomeController : Controller
    {
        private readonly ISliderServices _sliderServices;
        private readonly IBlogService _blogService;
        private readonly ICategoryService _categoryService;
        private readonly IProductService _productService;
        private readonly IHttpContextAccessor _accessor;

        public HomeController(ISliderServices sliderServices, 
                                    IBlogService blogService,
                                    ICategoryService categoryService,
                                    IProductService productService,
                                    IHttpContextAccessor accessor)

        {
            _sliderServices = sliderServices;
            _blogService = blogService;
            _categoryService = categoryService;
            _productService = productService;
            _accessor = accessor;
        }

        public async Task< IActionResult> Index()
        {
            HomeVM model = new()
            {
                Sliders = await _sliderServices.GetAllAsync(),
                SliderInfo = await _sliderServices.GetSliderInfoAsync(),
                Blogs = await _blogService.GetAllAsync(3),
                Categories =await _categoryService.GetAllAsync(),
                Products = await _productService.GetAllAsync(),


            };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddProductToBasket(int? id)
        {
            if (id is null) return BadRequest();
            var product = await _productService.GetByIdAsync((int)id);
            if (product is null) return NotFound();
            List<BasketVM> basketDatas;
            if (_accessor.HttpContext.Request.Cookies["Basket"] is not null)
            {
                basketDatas = JsonConvert.DeserializeObject<List<BasketVM>>(_accessor.HttpContext.Request.Cookies["Basket"]);
            }
            else
            {
                basketDatas = new List<BasketVM>();
            }
            var existBasketDatas = basketDatas.FirstOrDefault(m => m.Id == id);
            if (existBasketDatas is not null)
            {
                existBasketDatas.Count++;
            }
            else
            {
                basketDatas.Add(new BasketVM
                {
                    Id = (int)id,
                    Price = product.Price,
                    Count = 1
                });
            }
           
            _accessor.HttpContext.Response.Cookies.Append("Basket",JsonConvert.SerializeObject(basketDatas));

            return RedirectToAction(nameof(Index));
        }
      
    }
}
