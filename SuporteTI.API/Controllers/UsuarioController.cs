using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SuporteTI.Data.Models;
using SuporteTI.API.DTOs;

namespace SuporteTI.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly SuporteTiDbContext _context;

        public UsuarioController(SuporteTiDbContext context)
        {
            _context = context;
        }

        // GET: api/Usuario
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UsuarioReadDto>>> GetUsuarios()
        {
            var usuarios = await _context.Usuarios.ToListAsync();

            // Mapeamento manual para o DTO de leitura
            var usuariosDto = usuarios.Select(static u => new UsuarioReadDto
            {
                IdUsuario = u.IdUsuario,
                Nome = u.Nome,
                Email = u.Email,
                Tipo = u.Tipo,
                Ativo = u.Ativo ?? false,
                Cpf = u.Cpf,
                Telefone = u.Telefone
            }).ToList();

            return Ok(usuariosDto);
        }

        // GET: api/Usuario/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UsuarioReadDto>> GetUsuario(int id)
        {
            var usuario = await _context.Usuarios.FindAsync(id);

            if (usuario == null)
                return NotFound();

            return Ok(new UsuarioReadDto
            {
                IdUsuario = usuario.IdUsuario,
                Nome = usuario.Nome,
                Email = usuario.Email,
                Tipo = usuario.Tipo,
                Ativo = usuario.Ativo ?? false,
                Cpf = usuario.Cpf,
                Telefone = usuario.Telefone,
                Endereco = usuario.Endereco,
                DataNascimento = usuario.DataNascimento.HasValue
                    ? usuario.DataNascimento.Value.ToDateTime(new TimeOnly(0, 0))
                    : null
            });
        }

        // POST: api/Usuario
        [HttpPost]
        public async Task<ActionResult<UsuarioReadDto>> PostUsuario([FromBody] UsuarioCreateDto dto)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest("Os dados informados são inválidos.");

                // 🔹 Validação de CPF, se informado
                if (!string.IsNullOrWhiteSpace(dto.Cpf) && !CpfValidator.IsValid(dto.Cpf))
                    return BadRequest("CPF inválido.");

                // 🔹 Gera uma senha automática de 6 dígitos numéricos
                var random = new Random();
                var senhaGerada = random.Next(100000, 999999).ToString();

                // 🔹 Cria o objeto usuário com a senha gerada
                var usuario = new Usuario
                {
                    Nome = dto.Nome.Trim(),
                    Email = dto.Email.Trim(),
                    Senha = senhaGerada, // salva a senha gerada no banco
                    Tipo = dto.Tipo,
                    Cpf = dto.Cpf,
                    Telefone = dto.Telefone,
                    Endereco = dto.Endereco,
                    DataNascimento = dto.DataNascimento.HasValue
                        ? DateOnly.FromDateTime(dto.DataNascimento.Value)
                        : null,
                    Ativo = true
                };

                _context.Usuarios.Add(usuario);
                await _context.SaveChangesAsync();

                // 🔹 (Opcional futuramente) Envio de e-mail comentado
                /*
                await _emailService.EnviarEmailAsync(usuario.Email, "Conta criada com sucesso",
                    $"Olá {usuario.Nome}, sua conta foi criada com sucesso.\nSua senha de acesso é: {senhaGerada}");
                */

                // 🔹 Retorno incluindo a senha gerada (somente para testes)
                return Ok(new
                {
                    usuario.IdUsuario,
                    usuario.Nome,
                    usuario.Email,
                    usuario.Tipo,
                    usuario.Ativo,
                    usuario.Cpf,
                    usuario.Telefone,
                    SenhaGerada = senhaGerada
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro ao criar usuário: {ex.Message}");
            }
        }


        // PUT: api/Usuario/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUsuario(int id, [FromBody] UsuarioUpdateDto dto)
        {
            if (id != dto.IdUsuario) return BadRequest("Id do caminho difere do corpo.");

            var usuario = await _context.Usuarios.FindAsync(id);
            if (usuario == null) return NotFound("Usuário não encontrado.");

            // Atualiza apenas se o DTO trouxe valor (preserva no banco se vier null)
            if (!string.IsNullOrWhiteSpace(dto.Nome)) usuario.Nome = dto.Nome.Trim();
            if (!string.IsNullOrWhiteSpace(dto.Email)) usuario.Email = dto.Email.Trim();
            if (dto.Cpf != null) usuario.Cpf = dto.Cpf;
            if (dto.Telefone != null) usuario.Telefone = dto.Telefone;

            // 👇 Endereco preservado se vier null
            if (dto.Endereco != null) usuario.Endereco = dto.Endereco;

            // 👇 Converte DateTime? → DateOnly? (e preserva se veio null)
            if (dto.DataNascimento.HasValue)
                usuario.DataNascimento = DateOnly.FromDateTime(dto.DataNascimento.Value);

            if (dto.Ativo.HasValue) usuario.Ativo = dto.Ativo.Value;

            _context.Usuarios.Update(usuario);
            await _context.SaveChangesAsync();

            return NoContent();
        }


        // DELETE: api/Usuario/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUsuario(int id)
        {
            var usuario = await _context.Usuarios.FindAsync(id);
            if (usuario == null)
                return NotFound();

            _context.Usuarios.Remove(usuario);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }

    // 🔹 Classe validadora de CPF
    public static class CpfValidator
    {
        public static bool IsValid(string cpf)
        {
            if (string.IsNullOrWhiteSpace(cpf))
                return false;

            cpf = cpf.Replace(".", "").Replace("-", "").Trim();

            if (cpf.Length != 11 || cpf.All(c => c == cpf[0]))
                return false;

            int[] mult1 = { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] mult2 = { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };

            string tempCpf = cpf.Substring(0, 9);
            int soma = 0;

            for (int i = 0; i < 9; i++)
                soma += int.Parse(tempCpf[i].ToString()) * mult1[i];

            int resto = soma % 11;
            resto = resto < 2 ? 0 : 11 - resto;
            string digito = resto.ToString();
            tempCpf += digito;
            soma = 0;

            for (int i = 0; i < 10; i++)
                soma += int.Parse(tempCpf[i].ToString()) * mult2[i];

            resto = soma % 11;
            resto = resto < 2 ? 0 : 11 - resto;
            digito += resto.ToString();

            return cpf.EndsWith(digito);
        }
    }
}
