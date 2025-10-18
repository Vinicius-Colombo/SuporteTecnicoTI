using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using SuporteTI.Data.Models;
using Microsoft.Extensions.Configuration;
using SuporteTI.API.DTOs;

namespace SuporteTI.API.Strategies
{
    public class CodigoAtivoValidadoStrategy : IAutenticacaoStrategy
    {
        private readonly IConfiguration _configuration;

        public CodigoAtivoValidadoStrategy(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public Task<IActionResult> ExecutarAsync(Usuario usuario)
        {
            var token = GerarJwtToken(usuario);
            var response = new LoginResponseDto
            {
                IdUsuario = usuario.IdUsuario,
                Nome = usuario.Nome,
                Email = usuario.Email,
                Tipo = usuario.Tipo,
                Token = token
            };

            return Task.FromResult<IActionResult>(new OkObjectResult(response));
        }

        private string GerarJwtToken(Usuario usuario)
        {
            var claims = new[]
            {
            new Claim(ClaimTypes.NameIdentifier, usuario.IdUsuario.ToString()),
            new Claim(ClaimTypes.Email, usuario.Email),
            new Claim(ClaimTypes.Role, usuario.Tipo)
        };

            var key = Encoding.UTF8.GetBytes(_configuration["Jwt:Key"] ?? string.Empty);
            var creds = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.Now.AddHours(2),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
