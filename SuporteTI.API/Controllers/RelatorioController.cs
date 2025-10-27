using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SuporteTI.API.DTOs;
using SuporteTI.Data.Models;
using System.Globalization;

namespace SuporteTI.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RelatorioController : ControllerBase
    {
        private readonly SuporteTiDbContext _context;

        public RelatorioController(SuporteTiDbContext context)
        {
            _context = context;
        }

        // 🔹 GET: api/Relatorio/chamados-status?status=aberto
        [HttpGet("chamados-status")]
        public async Task<IActionResult> RelatorioPorStatus([FromQuery] string? status = null)
        {
            var query = _context.Chamados
                .Include(c => c.IdUsuarioNavigation)
                .Include(c => c.IdTecnicoNavigation)
                .Include(c => c.IdCategoriaNavigation)
                .AsQueryable();

            if (!string.IsNullOrWhiteSpace(status))
            {
                var statusLower = status.ToLower();
                query = query.Where(c => (c.StatusChamado ?? "").ToLower() == statusLower);
            }

            var chamados = await query.ToListAsync();

            var chamadosDto = chamados.Select(c => new ChamadoReadDto
            {
                IdChamado = c.IdChamado,
                Titulo = c.Titulo,
                Descricao = c.Descricao,
                Prioridade = c.Prioridade ?? "Média",
                StatusChamado = c.StatusChamado ?? "Aberto",
                DataAbertura = c.DataAbertura ?? DateTime.MinValue,
                DataFechamento = c.DataFechamento,
                NomeCliente = c.IdUsuarioNavigation?.Nome ?? "Não informado",
                NomeTecnico = c.IdTecnicoNavigation?.Nome ?? "Não atribuído",
                Categoria = c.IdCategoriaNavigation != null
                    ? new CategoriaReadDto
                    {
                        IdCategoria = c.IdCategoriaNavigation.IdCategoria,
                        Nome = c.IdCategoriaNavigation.Nome
                    }
                    : null
            }).ToList();

            var total = chamadosDto.Count;
            var abertos = chamadosDto.Count(c => (c.StatusChamado ?? "").ToLower() == "aberto");
            var fechados = chamadosDto.Count(c => (c.StatusChamado ?? "").ToLower() == "fechado");

            return Ok(new
            {
                TotalChamados = total,
                ChamadosAbertos = abertos,
                ChamadosFechados = fechados,
                Chamados = chamadosDto
            });
        }

        // 🔹 GET: api/Relatorio/chamados-prioridade?prioridade=Alta
        [HttpGet("chamados-prioridade")]
        public async Task<IActionResult> RelatorioPorPrioridade([FromQuery] string? prioridade = null)
        {
            var query = _context.Chamados
                .Include(c => c.IdUsuarioNavigation)
                .Include(c => c.IdTecnicoNavigation)
                .Include(c => c.IdCategoriaNavigation)
                .AsQueryable();

            if (!string.IsNullOrWhiteSpace(prioridade))
            {
                var prioridadeLower = prioridade.ToLower();
                query = query.Where(c => (c.Prioridade ?? "").ToLower() == prioridadeLower);
            }

            var chamados = await query.ToListAsync();

            var chamadosDto = chamados.Select(c => new ChamadoReadDto
            {
                IdChamado = c.IdChamado,
                Titulo = c.Titulo,
                Descricao = c.Descricao,
                Prioridade = c.Prioridade ?? "Média",
                StatusChamado = c.StatusChamado ?? "Aberto",
                DataAbertura = c.DataAbertura ?? DateTime.MinValue,
                DataFechamento = c.DataFechamento,
                NomeCliente = c.IdUsuarioNavigation?.Nome ?? "Não informado",
                NomeTecnico = c.IdTecnicoNavigation?.Nome ?? "Não atribuído",
                Categoria = c.IdCategoriaNavigation != null
                    ? new CategoriaReadDto
                    {
                        IdCategoria = c.IdCategoriaNavigation.IdCategoria,
                        Nome = c.IdCategoriaNavigation.Nome
                    }
                    : null

            }).ToList();

            var total = chamadosDto.Count;
            var alta = chamadosDto.Count(c => (c.Prioridade ?? "").ToLower() == "alta");
            var media = chamadosDto.Count(c => (c.Prioridade ?? "").ToLower() == "média" || (c.Prioridade ?? "").ToLower() == "media");
            var baixa = chamadosDto.Count(c => (c.Prioridade ?? "").ToLower() == "baixa");

            return Ok(new
            {
                TotalChamados = total,
                AltaPrioridade = alta,
                MediaPrioridade = media,
                BaixaPrioridade = baixa,
                Chamados = chamadosDto
            });
        }

        // 🔹 GET: api/Relatorio/avaliacoes?idTecnico=5
        [HttpGet("avaliacoes")]
        public async Task<IActionResult> Avaliacoes([FromQuery] int? idTecnico = null)
        {
            var query = _context.Avaliacoes
                .Include(a => a.IdChamadoNavigation)
                .ThenInclude(c => c.IdTecnicoNavigation)
                .AsQueryable();

            if (idTecnico.HasValue)
                query = query.Where(a => a.IdChamadoNavigation.IdTecnico == idTecnico);

            var avaliacoes = await query
                .Select(a => new AvaliacaoReadDto
                {
                    IdAvaliacao = a.IdAvaliacao,
                    IdChamado = a.IdChamado,
                    TituloChamado = a.IdChamadoNavigation.Titulo,
                    Nota = a.Nota,
                    Comentario = a.Comentario,
                    Tecnico = a.IdChamadoNavigation.IdTecnicoNavigation.Nome
                })
                .ToListAsync();

            return Ok(avaliacoes);
        }

        // 🔹 GET: api/Relatorio/chamados-diarios
        [HttpGet("chamados-diarios")]
        public async Task<IActionResult> RelatorioChamadosDiarios()
        {
            var hoje = DateTime.Today;

            var chamados = await _context.Chamados
                .Where(c => c.DataAbertura.HasValue && c.DataAbertura.Value.Date == hoje)
                .GroupBy(c => c.StatusChamado ?? "Aberto")
                .Select(g => new ChamadoStatusResumoDto
                {
                    Status = g.Key,
                    Quantidade = g.Count()
                })
                .ToListAsync();

            var todosStatus = new[] { "Aberto", "Em Atendimento", "Resolvido", "Encerrado" };

            var resultado = todosStatus.Select(s => new ChamadoStatusResumoDto
            {
                Status = s,
                Quantidade = chamados.FirstOrDefault(c => (c.Status ?? "").ToLower() == s.ToLower())?.Quantidade ?? 0
            });

            return Ok(resultado);
        }

        // 🔹 GET: api/Relatorio/mensal
        [HttpGet("mensal")]
        public async Task<IActionResult> RelatorioMensal()
        {
            var agora = DateTime.Now;
            int mesAtual = agora.Month;
            int anoAtual = agora.Year;

            var chamadosDoMes = _context.Chamados
                .Where(c => c.DataAbertura.HasValue &&
                            c.DataAbertura.Value.Month == mesAtual &&
                            c.DataAbertura.Value.Year == anoAtual);

            var total = await chamadosDoMes.CountAsync();
            var abertos = await chamadosDoMes.CountAsync(c => (c.StatusChamado ?? "").ToLower() == "aberto");
            var fechados = await chamadosDoMes.CountAsync(c => (c.StatusChamado ?? "").ToLower() == "fechado");

            var mesNome = agora.ToString("MMMM", new CultureInfo("pt-BR"));
            mesNome = char.ToUpper(mesNome[0]) + mesNome.Substring(1);

            var resultado = new RelatorioMensalDto
            {
                Mes = mesNome,
                TotalChamados = total,
                ChamadosAbertos = abertos,
                ChamadosFechados = fechados
            };

            return Ok(resultado);
        }

        // 🔹 POST: api/Relatorio/filtrado
        [HttpPost("filtrado")]
        public async Task<IActionResult> Filtrado([FromBody] RelatorioRequestDto filtros)
        {
            if (filtros == null)
                return BadRequest("Filtros inválidos.");

            // ===============================
            // 📊 Consulta Base
            // ===============================
            var query = _context.Chamados
                .Include(c => c.IdUsuarioNavigation)
                .Include(c => c.IdTecnicoNavigation)
                .Include(c => c.IdCategoriaNavigation)
                .AsQueryable();

            // ===============================
            // 📆 Filtro de Período
            // ===============================
            DateTime hoje = DateTime.Today;
            DateTime inicio = hoje, fim = DateTime.Now;

            switch ((filtros.Tipo ?? "").ToLower())
            {
                case "diário":
                case "diario":
                    inicio = hoje;
                    fim = hoje.AddDays(1);
                    break;
                case "semanal":
                    inicio = hoje.AddDays(-7);
                    break;
                case "mensal":
                    inicio = new DateTime(hoje.Year, hoje.Month, 1);
                    break;
                case "anual":
                    inicio = new DateTime(hoje.Year, 1, 1);
                    break;
                default:
                    inicio = DateTime.MinValue;
                    fim = DateTime.MaxValue;
                    break;
            }

            query = query.Where(c => c.DataAbertura >= inicio && c.DataAbertura <= fim);

            // ===============================
            // 👨‍🔧 Filtro por Técnico
            // ===============================
            if (filtros.IdTecnico.HasValue && filtros.IdTecnico > 0)
            {
                int idTec = filtros.IdTecnico.Value;
                query = query.Where(c => c.IdTecnico == idTec);
            }

            // ===============================
            // 🧩 Filtro por Categoria
            // ===============================
            if (filtros.IdCategoria.HasValue && filtros.IdCategoria > 0)
            {
                int idCat = filtros.IdCategoria.Value;
                query = query.Where(c => c.IdCategoria == idCat);
            }

            // ===============================
            // ⚙️ Filtro por Prioridade
            // ===============================
            if (!string.IsNullOrWhiteSpace(filtros.Prioridade) &&
                !filtros.Prioridade.Equals("todas", StringComparison.OrdinalIgnoreCase))
            {
                string prioridade = filtros.Prioridade.Trim().ToLower();
                query = query.Where(c => (c.Prioridade ?? "").ToLower() == prioridade);
            }

            // ===============================
            // 📦 Busca no banco
            // ===============================
            var chamados = await query.AsNoTracking().ToListAsync();

            // ===============================
            // 📋 Montagem dos dados do relatório
            // ===============================
            var totalChamados = chamados.Count;
            var resolvidosPrazo = chamados.Count(c => c.StatusChamado == "Encerrado");

            var tempoMedio = chamados
                .Where(c => c.DataFechamento != null)
                .Select(c => (c.DataFechamento!.Value - (c.DataAbertura ?? c.DataFechamento!.Value)).TotalHours)
                .DefaultIfEmpty(0)
                .Average();

            var topCategoria = chamados
                .Where(c => c.IdCategoriaNavigation != null)
                .GroupBy(c => c.IdCategoriaNavigation!.Nome)
                .OrderByDescending(g => g.Count())
                .Select(g => g.Key)
                .FirstOrDefault() ?? "Nenhuma";

            var chamadosDetalhados = chamados.Select(c => new ChamadoDetalhadoDto
            {
                IdChamado = c.IdChamado,
                DataAbertura = c.DataAbertura ?? DateTime.MinValue,
                Tecnico = c.IdTecnicoNavigation?.Nome ?? "Não atribuído",
                Cliente = c.IdUsuarioNavigation?.Nome ?? "N/A",
                Categoria = c.IdCategoriaNavigation?.Nome ?? "Sem categoria",
                Prioridade = c.Prioridade ?? "-",
                TempoAtendimento = c.DataFechamento != null
                    ? $"{(c.DataFechamento!.Value - (c.DataAbertura ?? c.DataFechamento!.Value)).TotalHours:F1}h"
                    : (c.StatusChamado == "Encerrado" ? "0h" : "Em andamento")
            }).ToList();

            // ===============================
            // 📈 GRÁFICOS
            // ===============================
            var graficos = new
            {
                categorias = chamados
                    .GroupBy(c => c.IdCategoriaNavigation != null ? c.IdCategoriaNavigation.Nome.Trim() : "Sem categoria")
                    .Select(g => new { Nome = g.Key, Quantidade = g.Count() })
                    .OrderByDescending(g => g.Quantidade)
                    .Take(10)
                    .ToList(),


                prioridades = chamados
                    .GroupBy(c => string.IsNullOrEmpty(c.Prioridade) ? "Sem prioridade" : c.Prioridade)
                    .Select(g => new { Nome = g.Key, Quantidade = g.Count() })
                    .OrderByDescending(g => g.Quantidade)
                    .ToList(),

                evolucao = chamados
                    .Where(c => c.DataAbertura.HasValue)
                    .GroupBy(c => c.DataAbertura!.Value.Date)
                    .Select(g => new { Data = g.Key, Quantidade = g.Count() })
                    .OrderBy(g => g.Data)
                    .ToList()
            };


            // ===============================
            // 🏅 RANKINGS
            // ===============================
            var rankings = new
            {
                tecnicos = chamados
                    .Where(c => c.IdTecnicoNavigation != null)
                    .GroupBy(c => c.IdTecnicoNavigation!.Nome)
                    .Select(g => new { Nome = g.Key, Quantidade = g.Count() })
                    .OrderByDescending(g => g.Quantidade)
                    .Take(10)
                    .ToList(),

                categorias = chamados
                    .Where(c => c.IdCategoriaNavigation != null)
                    .GroupBy(c => c.IdCategoriaNavigation!.Nome)
                    .Select(g => new { Nome = g.Key, Quantidade = g.Count() })
                    .OrderByDescending(g => g.Quantidade)
                    .Take(10)
                    .ToList()
            };

            // ===============================
            // ✅ Retorno final no formato padronizado
            // ===============================
            var retorno = new
            {
                resumo = new
                {
                    totalChamados,
                    tempoMedioResolucao = $"{TimeSpan.FromHours(tempoMedio):hh\\:mm}h",
                    resolvidosPrazo,
                    categoriaMaisIncidente = topCategoria,
                    totalAvaliacoes = await _context.Avaliacoes.CountAsync()
                },
                chamados = chamadosDetalhados,
                graficos,
                rankings
            };

            return Ok(retorno);
        }




    }
}
