using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TechcareerWebApiTutorial.Models.ORM;

namespace TechcareerWebApiTutorial.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        TechCareerDbContext _context;
        public OrderController()
        {
            _context = new TechCareerDbContext();
        }
        [HttpGet]
        public IActionResult GetOrderWebUser()
        {
            var orders = _context.Orders.Include(o=>o.WebUsers).ToList();
            return Ok(orders);
        }
    }
}
