using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TechcareerWebApiTutorial.Models.ORM;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace TechcareerWebApiTutorial.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomController : ControllerBase
    {
        private readonly TechCareerDbContext _context;

        public RoomController()
        {
            _context = new TechCareerDbContext();
        }

        [HttpGet]
        public ActionResult<Room> GetRooms()
        {
            var rooms = _context.Rooms.Include(r => r.Reservations).ToList();
            return Ok(rooms);
        }

        [HttpGet("{id}")]
        public ActionResult<Room> GetByRoomId(int id)
        {
            var room = _context.Rooms.Find(id);
            if (room == null)
            {
                return NotFound();
            }

            return Ok(room);
        }


        [HttpPost]
        public IActionResult PostRoom(Room room)
        {
            _context.Rooms.Add(room);
            _context.SaveChanges();

            return StatusCode(StatusCodes.Status201Created, room);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateCompany(int id, Room room)
        {
            var updateRoom = _context.Rooms.Find(id);

            if (updateRoom == null)
            {
                return NotFound("Sayfa Bulunamadı");
            }

            // Manuel güncelleme
            updateRoom.Name = room.Name;
            
            _context.Update(room);
            _context.SaveChanges();

            return Ok(updateRoom);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteRoom(int id)
        {
            var room = _context.Rooms.Find(id);

            if (room == null)
            {
                return NotFound("Sayfa Bulunamadı"); // 404 Not Found
            }

            _context.Rooms.Remove(room);
            _context.SaveChanges();

            return NoContent(); // 204 No Content
        }

    }
}
