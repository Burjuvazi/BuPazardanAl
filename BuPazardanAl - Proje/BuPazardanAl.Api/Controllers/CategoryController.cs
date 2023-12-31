﻿using BuPazardanAl.Business.Abstract;
using BuPazardanAl.Entities.Concrete;
using Microsoft.AspNetCore.Http;
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

        public async Task<IActionResult> Gets()
        {
            List<Category> categories = await _categoryService.GetCategoriesAllAsync();
            return Ok(categories);
        }

        [HttpPost]

        public async Task<IActionResult> Add(Category category)
        {
           bool response = await _categoryService.AddCategoryAsync(category);
            return Ok(response);
        }

        [HttpPut]

        public async Task<IActionResult> Update(Category category)
        {
           bool response = await _categoryService.UpdateCategoryAsync(category);
            return Ok(response);
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
           bool response = await _categoryService.DeleteCategoryAsync(id);
            return Ok(response);
        }
    }
}
