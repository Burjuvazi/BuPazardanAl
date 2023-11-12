using BuPazardanAl.Business.Abstract;
using BuPazardanAl.Entities.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace BuPazardanAl.Api.Controllers
{
    public class OrderProcessController : Controller
    {
        private readonly IOrderProcessService _orderProcessService;

        public OrderProcessController(IOrderProcessService orderProcessService)
        {
            _orderProcessService = orderProcessService;
        }
        [HttpPost]
        public async Task<IActionResult> Add(OrderProductDto orderProductDto)
        {
            bool response = await _orderProcessService.OrderAdd(orderProductDto);
            return Ok(response);
        }
    }
}
