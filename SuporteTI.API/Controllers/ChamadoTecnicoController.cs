using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SuporteTI.Data.Models;
using SuporteTI.API.DTOs;

namespace SuporteTI.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ChamadoTecnicoController : ControllerBase
    {
        private readonly SuporteTiDbContext _context;

        public ChamadoTecnicoController(SuporteTiDbContext context)
        {
            _context = context;
        }

        // 🔹 GET: api/ChamadoTecnico/{idTecnico}
        // Lista chamados atribuídos a um técnico (apenas abertos e em andamento)
        [HttpGet("{idTecnico}")]
        public async Task<ActionResult<IEnumerable<ChamadoReadDto>>> GetChamadosTecnico(int idTecnico)
        {
            var chamados = await _context.Chamados
                .Include(c => c.IdUsuarioNavigation)
                .Where(c => c.IdTecnico == idTecnico &&
                    (c.StatusChamado == "Aberto" || c.StatusChamado == "Em Andamento"))
                .ToListAsync();

            var chamadosDto = chamados.Select(c => new ChamadoReadDto
            {
                IdChamado = c.IdChamado,
                Titulo = c.Titulo,
                Descricao = c.Descricao,
                Prioridade = c.Prioridade,
                StatusChamado = c.StatusChamado,
                DataAbertura = (DateTime)c.DataAbertura,
                Usuario = c.IdUsuarioNavigation == null ? null : new UsuarioReadDto
                {
                    IdUsuario = c.IdUsuarioNavigation.IdUsuario,
                    Nome = c.IdUsuarioNavigation.Nome,
                    Email = c.IdUsuarioNavigation.Email
                }
            }).ToList();

            return Ok(chamadosDto);
        }

        // 🔹 GET: api/ChamadoTecnico/detalhes/{idChamado}
        // Retorna detalhes do chamado + histórico de mensagens
        [HttpGet("detalhes/{idChamado}")]
        public async Task<ActionResult<object>> GetDetalhesChamado(int idChamado)
        {
            var chamado = await _context.Chamados
                .Include(c => c.IdUsuarioNavigation)
                .FirstOrDefaultAsync(c => c.IdChamado == idChamado);

            if (chamado == null)
                return NotFound("Chamado não encontrado.");

            var interacoes = await _context.Interacoes
                .Where(i => i.IdChamado == idChamado)
                .OrderBy(i => i.DataHora)
                .Select(i => new InteracaoReadDto
                {
                    IdInteracao = i.IdInteracao,
                    IdChamado = i.IdChamado,
                    IdUsuario = i.IdUsuario,
                    Mensagem = i.Mensagem,
                    DataHora = (DateTime)i.DataHora,
                    Origem = i.Origem
                })
                .ToListAsync();

            return Ok(new
            {
                Chamado = new ChamadoReadDto
                {
                    IdChamado = chamado.IdChamado,
                    Titulo = chamado.Titulo,
                    Descricao = chamado.Descricao,
                    Prioridade = chamado.Prioridade,
                    StatusChamado = chamado.StatusChamado,
                    DataAbertura = (DateTime)chamado.DataAbertura,
                    Usuario = chamado.IdUsuarioNavigation == null ? null : new UsuarioReadDto
                    {
                        IdUsuario = chamado.IdUsuarioNavigation.IdUsuario,
                        Nome = chamado.IdUsuarioNavigation.Nome,
                        Email = chamado.IdUsuarioNavigation.Email
                    }
                },
                Interacoes = interacoes
            });
        }

        // 🔹 POST: api/ChamadoTecnico/mensagem/{idChamado}
        // Envia uma nova mensagem e atualiza o status automaticamente
        [HttpPost("mensagem/{idChamado}")]
        public async Task<IActionResult> EnviarMensagem(int idChamado, [FromBody] InteracaoCreateDto dto)
        {
            var chamado = await _context.Chamados.FindAsync(idChamado);
            if (chamado == null)
                return NotFound("Chamado não encontrado.");

            var mensagem = new Interacao
            {
                IdChamado = idChamado,
                IdUsuario = dto.IdUsuario,
                Mensagem = dto.Mensagem,
                DataHora = DateTime.Now,
                Origem = "Tecnico"
            };

            _context.Interacoes.Add(mensagem);

            // Se for a primeira mensagem do técnico → muda status
            if (string.Equals(chamado.StatusChamado, "Aberto", StringComparison.OrdinalIgnoreCase))
                chamado.StatusChamado = "Em Andamento";
 
            await _context.SaveChangesAsync();
            await _context.Entry(chamado).ReloadAsync(); // garante atualização do estado no banco

            return Ok("Mensagem enviada e status atualizado (se aplicável).");
        }

        // 🔹 PUT: api/ChamadoTecnico/encerrar/{idChamado}
        // Encerra o chamado como resolvido ou encerrado sem solução
        [HttpPut("encerrar/{idChamado}")]
        public async Task<IActionResult> EncerrarChamado(int idChamado, [FromBody] EncerrarChamadoDto dto)
        {
            var chamado = await _context.Chamados.FindAsync(idChamado);
            if (chamado == null)
                return NotFound("Chamado não encontrado.");

            chamado.StatusChamado = dto.Resolvido ? "Resolvido" : "Encerrado";
            chamado.DataFechamento = DateTime.Now;

            await _context.SaveChangesAsync();
            return Ok("Chamado encerrado com sucesso.");
        }
    }
}
