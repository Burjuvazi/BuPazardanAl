using BuPazardanAl.Business.Abstract;
using BuPazardanAl.Entities.Concrete;
using BuPazardanAl.Entities.Dtos;
using BuPazardanAl.WebUI.BasketTransaction;
using BuPazardanAl.WebUI.BasketTransaction.BasketModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BuPazardanAl.WebUI.Controllers
{
    public class OrderProcessController : Controller
    {
        private readonly IOrderProcessService _orderProcessService;
        private readonly IBasketTransaction _basketTransaction;
        private readonly IAuthService _authService;
        public OrderProcessController(IOrderProcessService orderProcessService, IBasketTransaction basketTransaction, IAuthService authService)
        {
            _orderProcessService = orderProcessService;
            _basketTransaction = basketTransaction;
            _authService = authService;
        }
        [Authorize]
        public IActionResult OrderProcess()
        {
            BasketDto basketDto = _basketTransaction.GetOrCreateBasket();
            AppUser appUser = _authService.GetUserByUserName(User.Identity.Name).Result;
            foreach (var item in basketDto.BasketItems)
            {
                _orderProcessService.OrderAdd(
                               new OrderProductDto()
                               {
                                    ProductId = item.ProductId,
                                     Price = item.Price,
                                      Quantity = item.Quantity,
                                       CustomerId = appUser.Id
                               });
            }
            basketDto.BasketItems.Clear();
            return View();
        }
    }
}
