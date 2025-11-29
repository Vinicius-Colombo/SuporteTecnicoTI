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
                .Include(c => c.IdCategoriaNavigation)
                .FirstOrDefaultAsync(c => c.IdChamado == dto.IdChamado);

            if (chamado == null)
                return NotFound("Chamado não encontrado.");

            // IA analisa o texto do chamado
            var (categoriaSugerida, solucaoSugerida, prioridadeSugerida) =
                await _iaService.AnalisarChamadoAsync(dto.TextoEntrada ?? chamado.Descricao);

            // Registra o processamento
            var proc = new Iaprocessamento
            {
                IdChamado = chamado.IdChamado,
                EntradaTexto = dto.TextoEntrada ?? chamado.Descricao,
                SaidaClassificacao = categoriaSugerida,
                SolucaoSugerida = solucaoSugerida,
                DataProcessamento = DateTime.Now
            };
            _context.Iaprocessamentos.Add(proc);

            // Atualiza prioridade
            chamado.Prioridade = prioridadeSugerida;

            //  Atribui categoria sugerida pela IA (com fallback)
            var categoria = await _context.Categoria
                .FirstOrDefaultAsync(c => c.Nome.ToLower() == categoriaSugerida.ToLower());

            // Se a IA mandar algo fora da lista (ex: "Problema de rede") - cai em "Outros"
            if (categoria == null)
            {
                categoria = await _context.Categoria
                    .FirstOrDefaultAsync(c => c.Nome.ToLower() == "outros");
            }

            chamado.IdCategoria = categoria.IdCategoria;

            // Seleciona técnico com menos chamados ativos
            var tecnicos = await _context.Usuarios
                .Where(t => t.Tipo.ToLower() == "tecnico")
                .ToListAsync();

            if (tecnicos.Any())
            {
                var tecnicoComMenosChamados = tecnicos
                    .Select(t => new
                    {
                        Tecnico = t,
                        Qtde = _context.Chamados.Count(ch =>
                            ch.IdTecnico == t.IdUsuario &&
                            (ch.StatusChamado.Equals("Aberto", StringComparison.OrdinalIgnoreCase) ||
                             ch.StatusChamado.Equals("Em Andamento", StringComparison.OrdinalIgnoreCase)))
                    })
                    .OrderBy(x => x.Qtde)
                    .First().Tecnico;

                chamado.IdTecnico = tecnicoComMenosChamados.IdUsuario;
            }


            await _context.SaveChangesAsync();

            // Retorna a resposta para o front
            return Ok(new IAResponseDto
            {
                IdChamado = chamado.IdChamado,
                Classificacao = categoriaSugerida,
                SolucaoSugerida = solucaoSugerida
            });
        }
    }
}
