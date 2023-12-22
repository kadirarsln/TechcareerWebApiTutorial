using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TechcareerWebApiTutorial.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CityController : ControllerBase
    {
        [HttpGet]
        public string[] GetCities()
        {
            string[] cities = new string[] { "Istanbul", "Ankara", "Izmir", "Bursa", "Antalya" };
            return cities;
        }
    }
}
