using BuPazardanAl.Business.Abstract;
using BuPazardanAl.Entities.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace BuPazardanAl.WebUI.Controllers
{
    public class TestController : Controller
    {
        private readonly IOrderProcessService _orderProcessService;

        public TestController(IOrderProcessService orderProcessService)
        {
            _orderProcessService = orderProcessService;
        }
        public IActionResult Index()
        {
            OrderProductDto orderProductDto = new OrderProductDto();
            orderProductDto.ProductId = 1;
            orderProductDto.Quantity = 2;
            orderProductDto.Price = 152;
            orderProductDto.CustomerId = 6;

            _orderProcessService.OrderAdd(orderProductDto);
            return View();
        }
    }
}
