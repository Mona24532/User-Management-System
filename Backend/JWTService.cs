using Backend.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace Backend
{
    public class JWTService
    {
        private readonly IConfiguration _config;
        public JWTService(IConfiguration config)
        {
            _config = config;
        }

        public string GenerateToken(Employee e)
        {
            var claims = new List<Claim>
           {
               new Claim(ClaimTypes.NameIdentifier,e.Name.ToString()),
               new Claim(ClaimTypes.Email,e.Email),
               new Claim(ClaimTypes.Role,e.Role)
           };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:key"]));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _config["Jwt:Issuer"],
                audience: _config["Jwt:Audience"],
                claims:claims,
                expires: DateTime.Now.AddHours(2),
                signingCredentials: creds
                );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
