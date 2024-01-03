using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace TechcareerWebApiTutorial.Models.Auth
{
    public class TechCareerTokenHandler
    {
        public TokenModel CreateAccessToken(string email)
        {
            var claims = new[]
            {
                new Claim(ClaimTypes.Email, email),
            };

            var token = new TokenModel();
            token.ExpiredDate = DateTime.Now.AddMinutes(10);

            SymmetricSecurityKey key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("superSecretKey@345"));

            SigningCredentials credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            JwtSecurityToken jwtSecurityToken = new JwtSecurityToken(
                               issuer: "arslnkadir1@gmail.com",
                               audience: "arslnkadir2@gmail.com",
                               signingCredentials: credentials,
                               claims: claims,
                               expires: token.ExpiredDate
                               );

            // bu class token oluşturmak için kullanılır
            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();

            token.accesToken = tokenHandler.WriteToken(jwtSecurityToken);
            return token;
        }
    }
}