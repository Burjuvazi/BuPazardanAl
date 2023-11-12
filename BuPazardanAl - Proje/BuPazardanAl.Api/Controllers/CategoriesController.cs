using BuPazardanAl.Business.Abstract;
using BuPazardanAl.Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace BuPazardanAl.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;     
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id) 
        {
            Category category = await _categoryService.GetCategoryAsync(id);
            return Ok(category);
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            List<Category> categories= await _categoryService.GetCategoriesAllAsync();
            return Ok(categories);
        }
        [HttpPost]
        public async Task<IActionResult> Add(Category category) 
        {
          bool res = await _categoryService.AddCategoryAsync(category);
          return Ok(res);
        }
        [HttpPut]
        public async Task<IActionResult> Update(Category category)
        {
            bool res = await _categoryService.UpdateCategoryAsync(category);
            return Ok(res);
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            bool response =await _categoryService.DeleteCategoryAsync(id);
            return Ok(response);
        }
          

    }
}
