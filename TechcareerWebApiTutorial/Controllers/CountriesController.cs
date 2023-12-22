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
                "Ulke1","Ulke2","Ulke3","Ulke4","Ulke5","Ulke6","Ulke7","Ulke8","Ulke9","Ulke10","Ulke11","Ulk12","Ulke13","Ulke14","Ulke15","Ulke16","Ulke17",
                "Ulke18","Ulke10","Ulke20"
            };
            return Ok(countries);
        }
    }
}
