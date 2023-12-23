using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TechcareerWebApiTutorial.Models;

namespace TechcareerWebApiTutorial.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CityController : ControllerBase
    {
        [HttpGet]
        public string[] GetCities()
        {
            //instance of WebUser class
            var webUser = new WebUser();

            string[] cities = new string[] { "Istanbul", "Ankara", "Izmir", "Bursa", "Antalya" };
            return cities;
        }
    }
}
