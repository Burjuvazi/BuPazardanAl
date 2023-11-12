using BuPazardanAl.Business.Abstract;
using BuPazardanAl.Entities.Concrete;
using BuPazardanAl.Entities.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BuPazardanAl.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderProcessService _orderService;
            public OrderController(IOrderProcessService orderService )
        {
            _orderService = orderService;
        }

        [HttpPost] 
        public async Task<IActionResult> Add(OrderProductDto orderProductDto)
        {
            bool response = await _orderService.OrderAdd(orderProductDto);
            return Ok(response);
        }
      
    }
}
