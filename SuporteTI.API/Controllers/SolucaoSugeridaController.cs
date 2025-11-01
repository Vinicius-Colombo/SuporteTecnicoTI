using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SuporteTI.API.DTOs;
using SuporteTI.API.Services;
using SuporteTI.Data.Models;

namespace SuporteTI.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SolucaoSugeridaController : ControllerBase
    {
        private readonly SuporteTiDbContext _context;
        private readonly IAService _iaService;

        public SolucaoSugeridaController(SuporteTiDbContext context, IAService iaService)
        {
            _context = context;
            _iaService = iaService;
        }

        // 🔹 GET: api/SolucaoSugerida/{chamadoId}
        [HttpGet("{chamadoId}")]
        public async Task<ActionResult<IEnumerable<SolucaoSugeridaReadDto>>> Listar(int chamadoId)
        {
            var solucoes = await _context.SolucaoSugerida
                .Include(s => s.IdChamadoNavigation)
                .Where(s => s.IdChamado == chamadoId)
                .Select(s => new SolucaoSugeridaReadDto
                {
                    IdSolucao = s.IdSolucao,
                    IdChamado = s.IdChamado,
                    TituloChamado = s.IdChamadoNavigation.Titulo,
                    Titulo = s.Titulo,
                    Conteudo = s.Conteudo,
                    Aceita = s.Aceita ?? false
                })
                .ToListAsync();

            return Ok(solucoes);
        }

        // 🔹 POST: api/SolucaoSugerida
        [HttpPost]
        public async Task<ActionResult<ChamadoReadDto>> Criar([FromBody] ChamadoCreateDto dto)
        {
            if (dto == null)
                return BadRequest("Chamado inválido.");

            var usuario = await _context.Usuarios.FindAsync(dto.IdUsuario);
            if (usuario == null)
                return BadRequest("Usuário informado não existe.");

            // 1️⃣ Cria o chamado inicial
            var chamado = new Chamado
            {
                Titulo = dto.Titulo,
                Descricao = dto.Descricao,
                Prioridade = "Média",
                StatusChamado = "Aberto",
                DataAbertura = DateTime.Now,
                IdUsuario = dto.IdUsuario
            };

            _context.Chamados.Add(chamado);
            await _context.SaveChangesAsync();

            // 2️⃣ IA analisa o texto do chamado
            var (categoria, solucao, prioridade) = await _iaService.AnalisarChamadoAsync(dto.Descricao);
            chamado.Prioridade = prioridade;

            // 3️⃣ Associa categoria sugerida
            var categoriaExistente = await _context.Categoria
                .FirstOrDefaultAsync(c => c.Nome.ToLower() == categoria.ToLower());
            if (categoriaExistente != null)
                chamado.IdCategoria = categoriaExistente.IdCategoria;

            await _context.SaveChangesAsync();

            // 4️⃣ Registra o processamento da IA
            var processamento = new Iaprocessamento
            {
                IdChamado = chamado.IdChamado,
                EntradaTexto = dto.Descricao,
                SaidaClassificacao = categoria,
                SolucaoSugerida = solucao,
                DataProcessamento = DateTime.Now
            };
            _context.Iaprocessamentos.Add(processamento);
            await _context.SaveChangesAsync();

            // 5️⃣ Cria a solução sugerida
            var solucaoIA = new SolucaoSugeridum
            {
                IdChamado = chamado.IdChamado,
                Titulo = $"Solução sugerida pela IA ({categoria})",
                Conteudo = solucao,
                Aceita = null,
                DataCriacao = DateTime.Now
            };
            _context.SolucaoSugerida.Add(solucaoIA);
            await _context.SaveChangesAsync();

            // 6️⃣ Retorna DTO
            var readDto = new ChamadoReadDto
            {
                IdChamado = chamado.IdChamado,
                Titulo = chamado.Titulo,
                Descricao = chamado.Descricao,
                Prioridade = chamado.Prioridade,
                StatusChamado = chamado.StatusChamado,
                DataAbertura = chamado.DataAbertura ?? DateTime.Now,
                Usuario = new UsuarioReadDto
                {
                    IdUsuario = usuario.IdUsuario,
                    Nome = usuario.Nome,
                    Email = usuario.Email,
                    Tipo = usuario.Tipo,
                    Ativo = usuario.Ativo ?? false,
                    Cpf = usuario.Cpf,
                    Telefone = usuario.Telefone
                },
                Categoria = chamado.IdCategoriaNavigation != null
                    ? new CategoriaReadDto
                    {
                        IdCategoria = chamado.IdCategoriaNavigation.IdCategoria,
                        Nome = chamado.IdCategoriaNavigation.Nome
                    }
                    : null
            };

            return CreatedAtAction(nameof(Listar), new { chamadoId = chamado.IdChamado }, readDto);
        }

        // 🔹 PUT: api/SolucaoSugerida/aceitar/{idChamado}
        // 🔹 PUT: api/SolucaoSugerida/aceitar/{idChamado}
        [HttpPut("aceitar/{idChamado}")]
        public async Task<ActionResult> Aceitar(int idChamado)
        {
            var solucao = await _context.SolucaoSugerida
                .FirstOrDefaultAsync(s => s.IdChamado == idChamado);

            if (solucao == null)
                return NotFound("Nenhuma solução encontrada para este chamado.");

            var chamado = await _context.Chamados.FindAsync(idChamado);
            if (chamado == null)
                return NotFound("Chamado não encontrado.");

            solucao.Aceita = true;
            chamado.StatusChamado = "Resolvido";

            // ✅ Garante que a data de fechamento seja registrada
            chamado.DataFechamento = DateTime.Now;

            await _context.SaveChangesAsync();

            return Ok(new
            {
                mensagem = "✅ Solução aceita. Chamado marcado como resolvido.",
                idChamado = idChamado,
                dataFechamento = chamado.DataFechamento
            });
        }


        // 🔹 PUT: api/SolucaoSugerida/rejeitar/{idChamado}
        [HttpPut("rejeitar/{idChamado}")]
        public async Task<ActionResult> Rejeitar(int idChamado)
        {
            var solucao = await _context.SolucaoSugerida
                .Include(s => s.IdChamadoNavigation)
                .ThenInclude(c => c.IdCategoriaNavigation)
                .FirstOrDefaultAsync(s => s.IdChamado == idChamado);

            if (solucao == null)
                return NotFound("Solução não encontrada para este chamado.");

            var chamado = solucao.IdChamadoNavigation;
            if (chamado == null)
                return NotFound("Chamado não encontrado.");

            solucao.Aceita = false;

            // 🔹 Busca técnicos da categoria
            var categoria = chamado.IdCategoriaNavigation;
            if (categoria == null)
                return BadRequest("Categoria não identificada.");

            var tecnicos = await _context.TecnicoCategorias
                .Where(tc => tc.IdCategoria == categoria.IdCategoria)
                .Select(tc => tc.IdTecnico)
                .ToListAsync();

            if (!tecnicos.Any())
                return BadRequest("Nenhum técnico vinculado à categoria.");

            var tecnicoMenosOcupado = await _context.Usuarios
                .Where(u => tecnicos.Contains(u.IdUsuario))
                .Select(u => new
                {
                    Tecnico = u,
                    ChamadosAbertos = _context.Chamados.Count(c =>
                        c.IdTecnico == u.IdUsuario &&
                        (c.StatusChamado == "Aberto" || c.StatusChamado == "Em andamento"))
                })
                .OrderBy(t => t.ChamadosAbertos)
                .Select(t => t.Tecnico)
                .FirstOrDefaultAsync();

            if (tecnicoMenosOcupado == null)
                return BadRequest("Não foi possível determinar um técnico disponível.");

            chamado.IdTecnico = tecnicoMenosOcupado.IdUsuario;
            chamado.StatusChamado = "Aberto"; // 👈 mantém aberto até o técnico responder

            await _context.SaveChangesAsync();

            return Ok(new
            {
                mensagem = $"🔄 Solução rejeitada. Chamado atribuído ao técnico {tecnicoMenosOcupado.Nome}.",
                idChamado = idChamado
            });
        }

    }
}
