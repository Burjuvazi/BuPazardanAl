using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BuPazardanAl.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        List<string> isimler = new List<string> {"Ayşe","Ümit","Hüseyin","Mustafa","Doğanay","Zeynep","Cahit"};
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(isimler);
        }
        [HttpGet("/api/Birsey")]
        public IActionResult GetBirsey()
        {
            return Ok("Buradan isimler gelecek");
        }
        [HttpPost]
        public IActionResult Post(string a)
        {
            isimler.Add(a);
            return BadRequest(ModelState.IsValid);
        }
    }
}
