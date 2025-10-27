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
                chamado.IdCategoria = categoriaExistente.IdCategoria; // ✅ agora 1:N

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

        // 🔹 PUT: api/SolucaoSugerida/aceitar/{id}
        [HttpPut("aceitar/{id}")]
        public async Task<ActionResult> Aceitar(int id)
        {
            var solucao = await _context.SolucaoSugerida.FindAsync(id);
            if (solucao == null)
                return NotFound("Solução não encontrada.");

            solucao.Aceita = true;
            await _context.SaveChangesAsync();

            return Ok(new { mensagem = "Solução aceita com sucesso.", idChamado = solucao.IdChamado });
        }

        // 🔹 PUT: api/SolucaoSugerida/rejeitar/{id}
        [HttpPut("rejeitar/{id}")]
        public async Task<ActionResult<SolucaoSugeridaReadDto>> Rejeitar(int id)
        {
            var solucao = await _context.SolucaoSugerida
                .Include(s => s.IdChamadoNavigation)
                .ThenInclude(c => c.IdCategoriaNavigation)
                .FirstOrDefaultAsync(s => s.IdSolucao == id);

            if (solucao == null)
                return NotFound("Solução não encontrada.");

            var chamado = solucao.IdChamadoNavigation;
            if (chamado == null)
                return NotFound("Chamado não encontrado.");

            // 🔹 Marca como rejeitada
            solucao.Aceita = false;

            // 🔹 Busca categoria do chamado
            var categoria = chamado.IdCategoriaNavigation;
            if (categoria == null)
                return BadRequest("Não foi possível identificar a categoria do chamado.");

            // 🔹 Busca técnicos vinculados à categoria
            var tecnicos = await _context.TecnicoCategorias
                .Where(tc => tc.IdCategoria == categoria.IdCategoria)
                .Select(tc => tc.IdTecnico)
                .ToListAsync();

            if (!tecnicos.Any())
                return BadRequest("Nenhum técnico vinculado a essa categoria foi encontrado.");

            // 🔹 Conta quantos chamados abertos cada técnico tem
            var tecnicoMenosOcupado = await _context.Usuarios
                .Where(u => tecnicos.Contains(u.IdUsuario))
                .Select(u => new
                {
                    Tecnico = u,
                    ChamadosAbertos = _context.Chamados.Count(c =>
                        c.IdTecnico == u.IdUsuario &&
                        c.StatusChamado == "Aberto")
                })
                .OrderBy(t => t.ChamadosAbertos)
                .Select(t => t.Tecnico)
                .FirstOrDefaultAsync();

            if (tecnicoMenosOcupado == null)
                return BadRequest("Não foi possível determinar um técnico disponível.");

            // 🔹 Atribui o chamado ao técnico menos ocupado
            chamado.IdTecnico = tecnicoMenosOcupado.IdUsuario;

            await _context.SaveChangesAsync();

            var dto = new SolucaoSugeridaReadDto
            {
                IdSolucao = solucao.IdSolucao,
                IdChamado = solucao.IdChamado,
                Titulo = solucao.Titulo,
                Conteudo = solucao.Conteudo,
                Aceita = solucao.Aceita ?? false
            };

            return Ok(new
            {
                mensagem = $"Solução rejeitada. Chamado atribuído ao técnico {tecnicoMenosOcupado.Nome}.",
                solucao = dto
            });
        }
    }
}
