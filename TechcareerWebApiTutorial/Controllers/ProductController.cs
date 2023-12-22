using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TechcareerWebApiTutorial.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        [HttpGet]
        public string Hello()
        {
            return "Hello World;";
        }
    }
}
