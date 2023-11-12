using BuPazardanAl.Business.Abstract;
using BuPazardanAl.Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BuPazardanAl.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet("{id}")]

        public async Task<IActionResult> Get(int id)
        {
           Product product = await _productService.GetProductAsync(id);
            return Ok(product);
        }

        [HttpGet]

        public async Task<IActionResult> Gets()
        {
            List<Product> products = await _productService.GetProductAllAsync();
            return Ok(products);
        }
        [HttpPost]

        public async Task<IActionResult> Add(Product product)
        {
           bool response = await _productService.AddProductAsync(product);
            return Ok(response);
        }

        [HttpPut]

        public async Task<IActionResult> Update(Product product)
        {
           bool response = await _productService.UpdateProductAsync(product);
            return Ok(response);
        }


    }
}
