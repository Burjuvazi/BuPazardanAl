using BuPazardanAl.Business.Abstract;
using BuPazardanAl.Entities.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BuPazardanAl.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CitiesController : ControllerBase
    {

        private readonly ICityService _cityService;
        public CitiesController(ICityService cityService) => _cityService = cityService;

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            City city = _cityService.GetCityAsync(id).Result;
            return city is not null ? Ok(city) : BadRequest("Şehir bulunamadı.");
        }

        
        [HttpGet]
        [Authorize(Roles ="Customer")]
        public IActionResult GetList()
        {
            List<City> cities = _cityService.GetCitiesAsync().Result;
            return Ok(cities);
        }

        [HttpPost]
        public IActionResult Add(City city)
        {
           bool response = _cityService.AddCityAsync(city).Result;
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> Update(City city)
        {
            bool response = await _cityService.UpdateCityAsync(city);
            return Ok(response);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            bool response = await _cityService.DeleteCityAsync(id);
            return Ok(response);
        }


    }
}
