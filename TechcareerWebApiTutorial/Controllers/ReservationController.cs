using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TechcareerWebApiTutorial.Models.ORM;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace TechcareerWebApiTutorial.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationController : ControllerBase
    {
        private readonly TechCareerDbContext _context;
        public ReservationController()
        {
            _context = new TechCareerDbContext();
        }

        [HttpGet]
        public IActionResult GetReservations()
        {
            var reservations = _context.Reservations.Include(r => r.Room).Include(rc => rc.Client.Company).ToList();

            return Ok(reservations);
        }

        [HttpGet("{id}")]
        public IActionResult GetReservationById(int id)
        {
            var reservation = _context.Reservations.Include(r => r.Room).Include(rc => rc.Client.Company).FirstOrDefault(r => r.Id == id);

            if (reservation == null)
            {
                return NotFound("Sayfa Bulunamadı");
            }
            return Ok(reservation);
        }


        [HttpPost]
        public IActionResult PostReservation(Reservation reservation)
        {
            Client client = _context.Clients.Find(reservation.ClientId);
            Room room = _context.Rooms.Find(reservation.RoomId);

            if (client == null)
            {
                return NotFound("Sayfa bulunamadı");
            }
            reservation.Client = client;
            reservation.ClientId = client.Id;

            if (room == null)
            {
                return NotFound("Sayfa bulunamadı");
            }

            reservation.Room = room;
            reservation.RoomId = room.Id;

            _context.Reservations.Add(reservation);
            _context.SaveChanges();
            return StatusCode(StatusCodes.Status201Created, reservation);
        }


        [HttpDelete("{id}")]
        public IActionResult DeleteReservation(int id)
        {
            var reservation = _context.Reservations.Find(id);

            if (reservation == null)
            {
                return NotFound("Sayfa Bulunamadı");
            }

            _context.Reservations.Remove(reservation);
            _context.SaveChanges();

            return Ok(reservation);
        }

    }
}
