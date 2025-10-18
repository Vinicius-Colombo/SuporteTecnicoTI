using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SuporteTI.API.DTOs;
using SuporteTI.API.Services;
using SuporteTI.Data.Models;

namespace SuporteTI.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ChamadoController : ControllerBase
    {
        private readonly SuporteTiDbContext _context;
        private readonly IAService _iaService;

        public ChamadoController(SuporteTiDbContext context, IAService iaService)
        {
            _context = context;
            _iaService = iaService;
        }

        // 🔹 GET: api/Chamado
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ChamadoReadDto>>> GetChamados()
        {
            var chamados = await _context.Chamados
                .Include(c => c.IdUsuarioNavigation)
                .Include(c => c.IdCategoria)
                .ToListAsync();

            // Mapeamento manual para DTO de leitura
            var chamadosDto = chamados.Select(c => new ChamadoReadDto
            {
                IdChamado = c.IdChamado,
                Titulo = c.Titulo,
                Descricao = c.Descricao,
                Prioridade = c.Prioridade,
                StatusChamado = c.StatusChamado,
                DataAbertura = (DateTime)c.DataAbertura,
                DataFechamento = c.DataFechamento,
                Usuario = c.IdUsuarioNavigation == null ? null : new UsuarioReadDto
                {
                    IdUsuario = c.IdUsuarioNavigation.IdUsuario,
                    Nome = c.IdUsuarioNavigation.Nome,
                    Email = c.IdUsuarioNavigation.Email,
                    Tipo = c.IdUsuarioNavigation.Tipo,
                    Ativo = c.IdUsuarioNavigation.Ativo ?? false,
                    Cpf = c.IdUsuarioNavigation.Cpf,
                    Telefone = c.IdUsuarioNavigation.Telefone
                },
                Categorias = c.IdCategoria?.Select(cat => new CategoriaReadDto
                {
                    IdCategoria = cat.IdCategoria,
                    Nome = cat.Nome
                }).ToList()
            }).ToList();

            return Ok(chamadosDto);
        }

        // 🔹 GET: api/Chamado/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<ChamadoReadDto>> GetChamado(int id)
        {
            var chamado = await _context.Chamados
                .Include(c => c.IdUsuarioNavigation)
                .Include(c => c.IdCategoria)
                .FirstOrDefaultAsync(c => c.IdChamado == id);

            if (chamado == null)
                return NotFound();

            var dto = new ChamadoReadDto
            {
                IdChamado = chamado.IdChamado,
                Titulo = chamado.Titulo,
                Descricao = chamado.Descricao,
                Prioridade = chamado.Prioridade,
                StatusChamado = chamado.StatusChamado,
                DataAbertura = (DateTime)chamado.DataAbertura,
                DataFechamento = chamado.DataFechamento,
                Usuario = chamado.IdUsuarioNavigation == null ? null : new UsuarioReadDto
                {
                    IdUsuario = chamado.IdUsuarioNavigation.IdUsuario,
                    Nome = chamado.IdUsuarioNavigation.Nome,
                    Email = chamado.IdUsuarioNavigation.Email,
                    Tipo = chamado.IdUsuarioNavigation.Tipo,
                    Ativo = chamado.IdUsuarioNavigation.Ativo ?? false,
                    Cpf = chamado.IdUsuarioNavigation.Cpf,
                    Telefone = chamado.IdUsuarioNavigation.Telefone
                },
                Categorias = chamado.IdCategoria?.Select(cat => new CategoriaReadDto
                {
                    IdCategoria = cat.IdCategoria,
                    Nome = cat.Nome
                }).ToList()
            };

            return Ok(dto);
        }

        // 🔹 POST: api/Chamado
        [HttpPost]
        public async Task<ActionResult<ChamadoReadDto>> PostChamado([FromBody] ChamadoCreateDto dto)
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

            // 3️⃣ Atualiza o chamado com categoria e prioridade sugerida
            chamado.Prioridade = prioridade;

            var categoriaExistente = await _context.Categoria
                .FirstOrDefaultAsync(c => c.Nome.ToLower() == categoria.ToLower());

            if (categoriaExistente != null)
                chamado.IdCategoria = new List<Categorium> { categoriaExistente };

            await _context.SaveChangesAsync();

            // 4️⃣ Registra o processamento IA
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

            // 5️⃣ Cria automaticamente uma Solução Sugerida
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

            // 6️⃣ Registra a mensagem da IA como interação no histórico
            if (!string.IsNullOrWhiteSpace(solucao))
            {
                var interacaoIA = new Interacao
                {
                    IdChamado = chamado.IdChamado,
                    IdUsuario = 9999, // ID simbólico representando a IA
                    Mensagem = solucao,
                    DataHora = DateTime.Now,
                    Origem = "IA"
                };

                _context.Interacoes.Add(interacaoIA);
                await _context.SaveChangesAsync();
            }

            // 7️⃣ Retorna DTO completo
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
                Categorias = chamado.IdCategoria?.Select(cat => new CategoriaReadDto
                {
                    IdCategoria = cat.IdCategoria,
                    Nome = cat.Nome
                }).ToList()
            };

            return CreatedAtAction(nameof(GetChamado), new { id = chamado.IdChamado }, readDto);
        }


        // 🔹 PUT: api/Chamado/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> PutChamado(int id, [FromBody] ChamadoUpdateDto dto)
        {
            if (dto == null)
                return BadRequest("Dados inválidos.");

            var chamado = await _context.Chamados
                .Include(c => c.IdCategoria)
                .FirstOrDefaultAsync(c => c.IdChamado == id);

            if (chamado == null)
                return NotFound();

            // Atualiza campos permitidos
            chamado.Titulo = dto.Titulo;
            chamado.Descricao = dto.Descricao;
            chamado.Prioridade = dto.Prioridade;
            chamado.StatusChamado = dto.StatusChamado;

            // Define DataFechamento se status mudou para Fechado
            if (dto.StatusChamado == "Fechado")
                chamado.DataFechamento = DateTime.Now;
            else
                chamado.DataFechamento = null;

            // Atualiza categorias (se enviadas)
            if (dto.IdCategorias != null)
            {
                chamado.IdCategoria.Clear();
                foreach (var catId in dto.IdCategorias)
                {
                    var categoria = await _context.Categoria.FindAsync(catId);
                    if (categoria != null)
                        chamado.IdCategoria.Add(categoria);
                }
            }

            await _context.SaveChangesAsync();
            return NoContent();
        }

        // 🔹 DELETE: api/Chamado/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteChamado(int id)
        {
            var chamado = await _context.Chamados.FindAsync(id);
            if (chamado == null)
                return NotFound();

            _context.Chamados.Remove(chamado);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
