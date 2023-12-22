using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TechcareerWebApiTutorial.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        [HttpGet]
        public ActionResult<IEnumerable<string>> GetCountries()
        {
            List<string> countries = new List<string>
            {
                "Turkey", "United States", "China", "India", "Russia", "Germany", "France", "United Kingdom", "Japan", "Brazil", "Canada", "Italy",
                "South Korea", "Mexico", "South Africa", "Australia", "Saudi Arabia", "Iran", "Argentina", "Spain"
            };
            return Ok(countries);
        }
    }
}
