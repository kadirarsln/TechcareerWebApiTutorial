using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TechcareerWebApiTutorial.Models.Auth;
using TechcareerWebApiTutorial.Models.DTO;
using TechcareerWebApiTutorial.Models.ORM;

namespace TechcareerWebApiTutorial.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        TechCareerDbContext _context;
        public AuthController()
        {
            _context = new TechCareerDbContext();
        }

        [HttpPost]
        public IActionResult Login(LoginRequestModel loginRequestModel)
        {
            var user = _context.UsersForTokens.FirstOrDefault(u => u.Email == loginRequestModel.Email && u.Password == loginRequestModel.Password);

            if (user != null)
            {
                TechCareerTokenHandler tokenHandler = new TechCareerTokenHandler();
                var token = tokenHandler.CreateAccessToken(user.Email);

                return Ok(token);
            }
            else
            {
                return BadRequest("Kullanıcı adı veya şifre hatalı");
            }
        }
    }
}
