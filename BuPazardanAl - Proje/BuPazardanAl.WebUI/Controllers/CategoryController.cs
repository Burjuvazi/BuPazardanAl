using BuPazardanAl.Business.Abstract;
using BuPazardanAl.Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace BuPazardanAl.WebUI.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public async Task<IActionResult> Categories()
        {
            List<Category> categories = await _categoryService.GetCategoriesAllAsync();
            return View(categories);
        }

        //public async Task<IActionResult> Details(int id)
        //{
        //    Category category = await _categoryService.GetCategoryAsync(id);
        //    return View(category);
        //}


    }
}
