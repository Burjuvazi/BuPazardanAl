using BuPazardanAl.Business.Abstract;
using BuPazardanAl.Entities.Concrete;
using BuPazardanAl.Entities.Concrete.Dtos;
using BuPazardanAl.Entities.Dtos;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Sentry;

namespace BuPazardanAl.WebUI.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAuthService _authService;


        IOrderProcessService _orderProcessService;
        



        public AccountController(IAuthService authService, IOrderProcessService orderProcessService)
        {
            _orderProcessService = orderProcessService;
            _authService = authService;
        }


        static int goruntulemeSayisi;
        static int uyeSayisi;
        [HttpGet]
        public IActionResult Login()
        {
            SentrySdk.CaptureMessage("Merhaba Dünya");
            goruntulemeSayisi++;
            return View(goruntulemeSayisi);
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginDto loginDto)
        {
            if (ModelState.IsValid)
            {
                string ass = User.Identity.Name;
                var result = await _authService.Login(loginDto);
                if (result.Succeeded)
                {
                    var user = _authService.GetUserByEmail(loginDto.Email);
                    var role = await _authService.GetRoleByUserName(user.UserName);
                    switch (role)
                    {
                        case "Customer": return RedirectToAction("Categories", "Category");
                        default: return RedirectToAction("Categories", "Category");
                    }
                }
            }
            ModelState.AddModelError("", "Lütfen girilen değerleri kontrol ediniz!");
            return View(loginDto);
        }
        [HttpGet]
        public async Task<IActionResult> CustomerRegister()
        {
            var _cityService = HttpContext.RequestServices.GetRequiredService<ICityService>();
            List<City> cities = await _cityService.GetCitiesAsync();
            ViewBag.Cities = cities;
            return View(uyeSayisi);
        }
        [HttpPost]
        public async Task<IActionResult> CustomerRegister(CustomerRegisterDto customerRegisterDto)
        {
            
            IdentityResult result = _authService.CustomerRegister(customerRegisterDto).Result;
            if (result.Succeeded)
            {
                uyeSayisi++;
                return RedirectToAction("Login");
            }
            ModelState.AddModelError("", "Lütfen girilen değerleri kontrol ediniz!");
            return View(customerRegisterDto);
        }
        [HttpGet]
        public IActionResult SellerRegister()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> SellerRegister(SellerRegisterDto sellerRegisterDto)
        {
            IdentityResult result = await _authService.SellerRegister(sellerRegisterDto);
            if (result.Succeeded)
            {
                return RedirectToAction("Login");
            }
            ModelState.AddModelError("", "Lütfen girilen değerleri kontrol ediniz!");
            return View(sellerRegisterDto);
        }
        public async Task<IActionResult> LogOut()
        {
            await _authService.Logout();
            return RedirectToAction("Login");
        }
    }
}
