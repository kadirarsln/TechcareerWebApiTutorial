using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TechcareerWebApiTutorial.Models.ORM;

namespace TechcareerWebApiTutorial.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly TechCareerDbContext _context;
        public ClientController()
        {
            _context = new TechCareerDbContext();
        }

        [HttpGet]
        public IActionResult GetClients()
        {
            var client = _context.Clients.Include(cl => cl.Company).ToList();
            return Ok(client);
        }

        [HttpGet("{id}")]
        public IActionResult GetClient(int id)
        {
            var client = _context.Clients
            .Include(c => c.Company)
            .FirstOrDefault(c => c.Id == id);

            if (client == null)
            {
                return NotFound();
            }

            return Ok(client);
        }

        [HttpPost]
        public IActionResult PostClient(Client client)
        {
            Company company = _context.Companies.Find(client.CompanyId);
            if (company == null)
            {
                return NotFound("Sayfa bulunamadı");
            }
            client.Company = company;
            _context.Clients.Add(client);
            _context.SaveChanges();
            return StatusCode(StatusCodes.Status201Created, client);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateClient(int id, Client client)
        {
            if (id != client.Id)
            {
                return BadRequest("Geçersiz ID");
            }

            var updatedClient = _context.Clients.Find(id);

            if (updatedClient == null)
            {
                return NotFound("Sayfa bulunamadı");
            }

            // Manuel güncelleme
            updatedClient.Name = client.Name;
            updatedClient.Surname = client.Surname;
            updatedClient.BirthDate = client.BirthDate;
            updatedClient.Address = client.Address;
            updatedClient.Email = client.Email;
            updatedClient.CompanyId = client.CompanyId;


            _context.Update(updatedClient);
            _context.SaveChanges();

            return Ok(updatedClient);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteClient(int id)
        {
            var deleteClient = _context.Clients.Find(id);
            if (deleteClient == null)
            {
                return NotFound("Sayfa bulunamadı");
            }
            _context.Clients.Remove(deleteClient);
            _context.SaveChanges();
            return Ok(deleteClient);
        }
    }
}
