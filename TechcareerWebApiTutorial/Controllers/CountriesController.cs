using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TechcareerWebApiTutorial.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountriesController : ControllerBase
    {
        private static string[] AllCountries = {
        "Turkey", "USA", "Germany", "France", "UK",
        "Italy", "Japan", "China", "Russia", "India",
        "Brazil", "Canada", "Australia", "South Korea", "Mexico",
        "South Africa", "Saudi Arabia", "Spain", "Argentina", "Nigeria"
    };

        [HttpGet]
        public IActionResult GetAllCountries()
        {
            return Ok(AllCountries);
        }

        [HttpGet("{count}")]
        public IActionResult GetCountCountries(int count)
        {
            string[] selectedCountries = AllCountries.TakeLast(count).ToArray();
            return Ok(selectedCountries);
        }
    }

}
