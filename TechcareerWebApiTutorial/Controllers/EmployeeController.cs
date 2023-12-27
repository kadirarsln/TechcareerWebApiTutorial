using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TechcareerWebApiTutorial.Models.ORM;

namespace TechcareerWebApiTutorial.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly TechCareerDbContext _context;

        public EmployeeController()
        {
            _context = new TechCareerDbContext();
        }
        [HttpGet]
        public IActionResult GetEmployee()
        {

            var employees = _context.Employees.ToList();
            return Ok(employees);
        }

        [HttpGet("{id}")]
        public IActionResult GetByEmployeeId(int id)
        {

            //firstordefault metodu icerisine yazdığımız sorguya göre arama yapar
            var employee = _context.Employees.FirstOrDefault(x => x.Id == id);

            //blog yoksa 404 döndür
            if (employee == null)
            {
                return NotFound();
            }

            return Ok(employee);
        }

        [HttpPost]
        public IActionResult Create(Employee employee)
        {

            _context.Employees.Add(employee);
            _context.SaveChanges();

            return StatusCode(201, employee);
        }

        //delete
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var employee = _context.Employees.FirstOrDefault(x => x.Id == id);

            if (employee == null)
            {
                return NotFound();
            }

            _context.Employees.Remove(employee);
            _context.SaveChanges();

            return Ok(employee);
        }
    }
}
