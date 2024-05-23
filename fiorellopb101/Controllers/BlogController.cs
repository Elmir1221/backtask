using fiorellopb101.Models;
using fiorellopb101.Servioces.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace fiorellopb101.Controllers
{
    public class BlogController : Controller
    {
        private readonly IBlogService _blogService;
        public BlogController(IBlogService blogService)
        {
            _blogService = blogService;
        }
       public async Task<IActionResult>  Index()
        {
            return View(await _blogService.GetAllAsync());
        }
    }
}
