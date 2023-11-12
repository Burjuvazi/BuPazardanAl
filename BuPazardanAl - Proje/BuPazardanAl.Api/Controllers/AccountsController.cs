
using BuPazardanAl.Business.Abstract;
using BuPazardanAl.Entities.Concrete.Dtos;
using BuPazardanAl.Entities.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace BuPazardanAl.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly IAuthService _authService;
        public AccountsController(IAuthService authService) => _authService = authService;

        [HttpPost]
        public async Task<IActionResult> Login([FromBody]LoginDto loginDto)
        {
           string token =  _authService.CreateToken(loginDto).Result;
           return token is not null ? Ok(token) : NotFound("Başarısız giriş...");
        }
        [HttpPost("/Seller")]
        public async Task<IActionResult> SellerRegister(SellerRegisterDto registerDto)
        {
            var result = await _authService.SellerRegister(registerDto);
            return result.Succeeded ? Ok(result) : NotFound("Üye işlemi başarısız...");
        }
        [HttpPost("/Customer")]
        public async Task<IActionResult> CustomerRegister(CustomerRegisterDto registerDto)
        {
            var result = await _authService.CustomerRegister(registerDto);
            return result.Succeeded ? Ok(result) : NotFound("Üye işlemi başarısız...");
        }
    }
}
