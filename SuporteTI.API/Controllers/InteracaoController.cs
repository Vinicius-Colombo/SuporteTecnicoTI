using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SuporteTI.Data.Models;
using SuporteTI.API.DTOs;

namespace SuporteTI.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class InteracaoController : ControllerBase
    {
        private readonly SuporteTiDbContext _context;

        public InteracaoController(SuporteTiDbContext context)
        {
            _context = context;
        }

        // ✅ POST: api/Interacao
        [HttpPost]
        public async Task<ActionResult<InteracaoReadDto>> PostInteracao([FromBody] InteracaoCreateDto dto)
        {
            if (dto == null)
                return BadRequest("Dados inválidos.");

            var chamado = await _context.Chamados.FindAsync(dto.IdChamado);
            if (chamado == null)
                return NotFound($"Chamado com ID {dto.IdChamado} não encontrado.");

            var usuario = await _context.Usuarios.FindAsync(dto.IdUsuario);
            if (usuario == null)
                return NotFound($"Usuário com ID {dto.IdUsuario} não encontrado.");

            var interacao = new Interacao
            {
                IdChamado = dto.IdChamado,
                IdUsuario = dto.IdUsuario,
                Mensagem = dto.Mensagem,
                DataHora = DateTime.Now,
                Origem = string.IsNullOrWhiteSpace(dto.Origem)
                    ? usuario.Tipo // se não enviar origem, usa tipo do usuário (Cliente, Técnico, etc.)
                    : dto.Origem
            };

            _context.Interacoes.Add(interacao);
            await _context.SaveChangesAsync();

            var readDto = new InteracaoReadDto
            {
                IdInteracao = interacao.IdInteracao,
                IdChamado = interacao.IdChamado,
                IdUsuario = interacao.IdUsuario,
                NomeUsuario = usuario.Nome,
                Mensagem = interacao.Mensagem,
                DataHora = interacao.DataHora ?? DateTime.Now,
                Origem = interacao.Origem
            };

            return CreatedAtAction(nameof(GetPorChamado), new { chamadoId = dto.IdChamado }, readDto);
        }

        // ✅ GET: api/Interacao/chamado/{chamadoId}
        [HttpGet("chamado/{chamadoId}")]
        public async Task<ActionResult<IEnumerable<InteracaoReadDto>>> GetPorChamado(int chamadoId)
        {
            var interacoes = await _context.Interacoes
                .Include(i => i.IdUsuarioNavigation)
                .Where(i => i.IdChamado == chamadoId)
                .OrderBy(i => i.DataHora)
                .Select(i => new InteracaoReadDto
                {
                    IdInteracao = i.IdInteracao,
                    IdChamado = i.IdChamado,
                    IdUsuario = i.IdUsuario,
                    NomeUsuario = i.IdUsuarioNavigation.Nome,
                    Mensagem = i.Mensagem,
                    DataHora = i.DataHora ?? DateTime.Now,
                    Origem = i.Origem
                })
                .ToListAsync();

            return Ok(interacoes);
        }
    }
}
