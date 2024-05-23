using fiorellopb101.Models;
using fiorellopb101.Servioces.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace fiorellopb101.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        public async Task< IActionResult> Index(int id)
        {
            Product product = await _productService.GetByIdWithAllDatasAsync(id);
            return View(product);
        }
    }
}
