using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using SuporteTI.API.DTOs;
using SuporteTI.API.Strategies;
using SuporteTI.Data.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Net.Mail;
using System.Security.Claims;
using System.Text;

namespace SuporteTI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly SuporteTiDbContext _context;
        private readonly IConfiguration _configuration;

        public AuthController(SuporteTiDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }


        [HttpPost("solicitar-codigo")]
        public async Task<IActionResult> SolicitarCodigo([FromBody] SolicitarCodigoDto dto)
        {
            var usuario = await _context.Usuarios.FirstOrDefaultAsync(u =>
                u.Email == dto.Email &&
                u.Senha == dto.Senha &&
                u.Ativo == true);

            if (usuario == null)
                return Unauthorized("Usuário ou senha inválidos.");

            var strategy = AutenticacaoStrategyFactory.ObterStrategy(usuario, _context, _configuration);
            var resultado = await strategy.ExecutarAsync(usuario);
            return resultado;

        }




        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginCodigoModel login)
        {
            var usuario = await _context.Usuarios.FirstOrDefaultAsync(u =>
                u.Email == login.Email &&
                u.CodigoVerificacao == login.Codigo &&
                u.ExpiracaoCodigo > DateTime.Now);

            if (usuario == null)
                return Unauthorized("Código inválido ou expirado.");

            usuario.CodigoValidado = true;
            await _context.SaveChangesAsync();

            // ✅ Claims (informações dentro do token)
            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, usuario.IdUsuario.ToString()),
                new Claim(ClaimTypes.Email, usuario.Email),
                new Claim(ClaimTypes.Role, usuario.Tipo),
                new Claim(ClaimTypes.Name, usuario.Nome),
            };

            // ✅ Gera o token
            var key = Encoding.UTF8.GetBytes(_configuration["Jwt:Key"] ?? string.Empty);
            var creds = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.Now.AddHours(2),
                signingCredentials: creds
            );

            return Ok(new LoginResponseDto
            {
                IdUsuario = usuario.IdUsuario,
                Nome = usuario.Nome,
                Email = usuario.Email,
                Tipo = usuario.Tipo,
                Cpf = usuario.Cpf,
                Telefone = usuario.Telefone,
                Endereco = usuario.Endereco,
                DataNascimento = usuario.DataNascimento,
                Token = new JwtSecurityTokenHandler().WriteToken(token)
            });

        }

        [HttpPost("validar-usuario")]
        public async Task<IActionResult> ValidarUsuario([FromBody] LoginModelDto login)
        {
            var usuario = await _context.Usuarios.FirstOrDefaultAsync(u =>
                u.Email == login.Email &&
                u.Senha == login.Senha &&
                u.Ativo == true);

            if (usuario == null)
                return Unauthorized("Usuário ou senha inválidos.");

            // 🔹 Retorna também o campo CodigoValidado
            return Ok(new
            {
                IdUsuario = usuario.IdUsuario,
                Nome = usuario.Nome,
                Email = usuario.Email,
                Tipo = usuario.Tipo,
                CodigoValidado = usuario.CodigoValidado  == true// 👈 ADICIONADO AQUI
            });
        }




        public class LoginCodigoModel
        {
            public string Email { get; set; } = string.Empty;
            public string Codigo { get; set; } = string.Empty;
        }

    }
}
