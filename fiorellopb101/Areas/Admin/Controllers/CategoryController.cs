using Fiorello_PB101.ViewModels.Categories;
using fiorellopb101.Data;
using fiorellopb101.Models;
using fiorellopb101.Servioces.Interfaces;
using Microsoft.AspNetCore.Mvc;


namespace Fiorello_PB101.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;
        private readonly AppDbContext _context;

        public CategoryController(ICategoryService categoryService,
                                  AppDbContext context)
        {
            _context = context;
            _categoryService = categoryService;
        }

        [HttpGet]
        public async  Task<IActionResult> Index()
        {
            return View(await _categoryService.GetAllWithProductCountAsync());
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CategoryCreateVM category)
        {
            if(!ModelState .IsValid)
            {
                return View();
            }


            bool existCategory = await _categoryService.ExistAsync(category.Name);

            if(existCategory)
            {
                ModelState.AddModelError("Name", "This category already exist");
                return View();
            }


            await _categoryService.CreateAsync(new Category { Name = category.Name });
            return RedirectToAction("Index");
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return BadRequest();

            var category = await _categoryService.GetByIdAsync((int)id);
            if (category == null) return NotFound();

            await _categoryService.DeleteAsync(category);

            return RedirectToAction("Index");

        }



        [HttpGet]
        public async Task<IActionResult> Detail(int? id)
        {
            Category categories = await _categoryService.GetByIdAsync(id);

            return View(categories);
        }
    }
}
/*
   private readonly ICategoryService _categoryService;
        private readonly AppDbContext _context;

        public CategoryController(ICategoryService categoryService,
                                  AppDbContext context)
        {
            _context = context;
            _categoryService = categoryService;
        }

        [HttpGet]
        public async  Task<IActionResult> Index()
        {
            return View(await _categoryService.GetAllWithProductCountAsync());
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CategoryCreateVM category)
        {
            if(!ModelState .IsValid)
            {
                return View();
            }


            bool existCategory = await _categoryService.ExistAsync(category.Name);

            if(existCategory)
            {
                ModelState.AddModelError("Name", "This category already exist");
                return View();
            }


            await _categoryService.CreateAsync(new Category { Name = category.Name });
            return RedirectToAction("Index");
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return BadRequest();

            var category = await _categoryService.GetByIdWithAllDatasAsync((int)id);
            if (category == null) return NotFound();

            await _categoryService.DeleteAsync(category);

            return RedirectToAction("Index");

        }



        [HttpGet]
        public async Task<IActionResult> Detail(int? id)
        {
            Category categories = await _categoryService.GetByIdWithAllDatasAsync(id);

            return View(categories);
        }
    }
}

 */