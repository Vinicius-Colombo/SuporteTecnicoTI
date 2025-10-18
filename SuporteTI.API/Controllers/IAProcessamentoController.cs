using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SuporteTI.Data.Models;
using SuporteTI.API.DTOs;
using SuporteTI.API.Services;

namespace SuporteTI.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class IAProcessamentoController : ControllerBase
    {
        private readonly SuporteTiDbContext _context;
        private readonly IAService _iaService;

        public IAProcessamentoController(SuporteTiDbContext context, IAService iaService)
        {
            _context = context;
            _iaService = iaService;
        }

        [HttpPost]
        public async Task<ActionResult<IAResponseDto>> ProcessarChamado([FromBody] IARequestDto dto)
        {
            if (dto == null || dto.IdChamado <= 0)
                return BadRequest("Dados inválidos.");

            var chamado = await _context.Chamados
                .Include(c => c.IdCategoria)
                .FirstOrDefaultAsync(c => c.IdChamado == dto.IdChamado);

            if (chamado == null)
                return NotFound("Chamado não encontrado.");

            var (categoriaSugerida, solucaoSugerida, prioridadeSugerida) =
                await _iaService.AnalisarChamadoAsync(dto.TextoEntrada ?? chamado.Descricao);

            // salva processamento
            var proc = new Iaprocessamento
            {
                IdChamado = chamado.IdChamado,
                EntradaTexto = dto.TextoEntrada ?? chamado.Descricao,
                SaidaClassificacao = categoriaSugerida,
                SolucaoSugerida = solucaoSugerida,
                DataProcessamento = DateTime.Now
            };
            _context.Iaprocessamentos.Add(proc);

            // atualiza prioridade
            chamado.Prioridade = prioridadeSugerida;

            // atribui categoria
            var categoria = await _context.Categoria.FirstOrDefaultAsync(c => c.Nome == categoriaSugerida);
            if (categoria == null)
            {
                categoria = new Categorium { Nome = categoriaSugerida };
                _context.Categoria.Add(categoria);
                await _context.SaveChangesAsync();
            }

            chamado.IdCategoria = new List<Categorium> { categoria };

            // seleciona técnico com menos chamados ativos
            var tecnicos = await _context.Usuarios
                .Where(t => t.Tipo == "Tecnico")
                .ToListAsync();

            if (tecnicos.Any())
            {
                var tecnicoComMenosChamados = tecnicos
                    .Select(t => new
                    {
                        Tecnico = t,
                        Qtde = _context.Chamados.Count(ch =>
                            ch.IdTecnico == t.IdUsuario &&
                            (ch.StatusChamado == "Aberto" || ch.StatusChamado == "Em andamento"))
                    })
                    .OrderBy(x => x.Qtde)
                    .First().Tecnico;

                chamado.IdTecnico = tecnicoComMenosChamados.IdUsuario;
            }

            await _context.SaveChangesAsync();

            return Ok(new IAResponseDto
            {
                IdChamado = chamado.IdChamado,
                Classificacao = categoriaSugerida,
                SolucaoSugerida = solucaoSugerida
            });
        }
    }
}
