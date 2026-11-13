
using Api.Models;
using Api.Migrations;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Api
{
    public class TokenService
    {

        private readonly IConfiguration _configuration;
        public TokenService(IConfiguration confi)
        {
            _configuration = confi;
        }

        public string Token(Usuario usuario)
        {

            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, usuario.Id.ToString()),
                new Claim(ClaimTypes.Email, usuario.Email)
            };

            var chave = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(
                    _configuration["Jwt:Key"]!
                )
            );

            var credenciais = new SigningCredentials(
                chave,
                SecurityAlgorithms.HmacSha256
            );

            var token = new JwtSecurityToken(
                claims: claims,
                signingCredentials: credenciais
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
