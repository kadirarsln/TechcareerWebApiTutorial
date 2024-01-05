using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TechcareerWebApiTutorial.Models.ORM;

namespace TechcareerWebApiTutorial.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly TechCareerDbContext _context;

        public CompanyController()
        {
            _context = new TechCareerDbContext();
        }

        [HttpGet]
        public ActionResult<Company> GetCompanies()
        {
            var companies = _context.Companies.ToList();
            return Ok(companies);
        }


        [HttpGet("{id}")]
        public ActionResult<Company> GetByCompanyId(int id)
        {
            var company = _context.Companies.Include(c => c.Reservations)
            .FirstOrDefault(c => c.Id == id);

            if (company == null)
            {
                return NotFound("Sayfa Bulunamadı");
            }

            return Ok(company);
        }

        [HttpPost]
        public IActionResult PostCompany(Company company)
        {
            _context.Companies.Add(company);
            _context.SaveChanges();

            return StatusCode(StatusCodes.Status201Created, company);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateCompany(int id, Company company)
        {
            var updateCompany = _context.Companies.Find(id);

            if (updateCompany == null)
            {
                return NotFound("Sayfa Bulunamadı");
            }

            // Manuel güncelleme
            updateCompany.Name = company.Name;
            updateCompany.Address = company.Address;

            _context.Update(updateCompany);
            _context.SaveChanges();

            return Ok(updateCompany);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCompany(int id)
        {
            var company = _context.Companies.Find(id);

            if (company == null)
            {
                return NotFound("Sayfa Bulunamadı"); // 404 Not Found
            }

            _context.Companies.Remove(company);
            _context.SaveChanges();

            return NoContent(); // 204 No Content
        }

    }
}
