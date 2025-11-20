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

        // Pesquisa todos os chamados
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ChamadoReadDto>>> GetChamados()
        {
            var chamados = await _context.Chamados
                .Include(c => c.IdUsuarioNavigation)
                .Include(c => c.IdCategoriaNavigation)
                .ToListAsync();

            var chamadosDto = chamados.Select(c => new ChamadoReadDto
            {
                IdChamado = c.IdChamado,
                Titulo = c.Titulo,
                Descricao = c.Descricao,
                Prioridade = c.Prioridade,
                StatusChamado = c.StatusChamado,
                DataAbertura = c.DataAbertura ?? DateTime.MinValue,
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
                Categoria = c.IdCategoriaNavigation != null
                ? new CategoriaReadDto
                {
                    IdCategoria = c.IdCategoriaNavigation.IdCategoria,
                    Nome = c.IdCategoriaNavigation.Nome
                }
                : null

            }).ToList();

            return Ok(chamadosDto);
        }

        // Pesquisa chamado por ID
        [HttpGet("{id}")]
        public async Task<ActionResult<ChamadoReadDto>> GetChamado(int id)
        {
            var chamado = await _context.Chamados
                .Include(c => c.IdUsuarioNavigation)
                .Include(c => c.IdCategoriaNavigation)
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
                DataAbertura = chamado.DataAbertura ?? DateTime.MinValue,
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
                Categoria = chamado.IdCategoriaNavigation != null
                    ? new CategoriaReadDto
                    {
                        IdCategoria = chamado.IdCategoriaNavigation.IdCategoria,
                        Nome = chamado.IdCategoriaNavigation.Nome
                    }
                    : null
            };

            return Ok(dto);
        }

        // Cria um novo chamado
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

            // IA analisa o texto do chamado
            var (categoria, solucao, prioridade) = await _iaService.AnalisarChamadoAsync(dto.Descricao);

            // Atualiza o chamado com categoria e prioridade sugerida
            chamado.Prioridade = prioridade;

            // Procura categoria sugerida pela IA
            var categoriaExistente = await _context.Categoria
                .FirstOrDefaultAsync(c => c.Nome.ToLower() == categoria.ToLower());

            // Fallback: se a IA gerar algo inesperado, usa 'Outros'
            if (categoriaExistente == null)
            {
                categoriaExistente = await _context.Categoria
                    .FirstOrDefaultAsync(c => c.Nome.ToLower() == "outros");
            }

            // Se existir mesmo assim, atribui ao chamado
            if (categoriaExistente != null)
            {
                chamado.IdCategoria = categoriaExistente.IdCategoria;
            }


            await _context.SaveChangesAsync();

            // Registra o processamento IA
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

            // Cria automaticamente uma Solução Sugerida
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

            // Registra a mensagem da IA como interação no histórico
            if (!string.IsNullOrWhiteSpace(solucao))
            {
                var interacaoIA = new Interacao
                {
                    IdChamado = chamado.IdChamado,
                    IdUsuario = 9999, // ID da IA
                    Mensagem = solucao,
                    DataHora = DateTime.Now,
                    Origem = "IA"
                };

                _context.Interacoes.Add(interacaoIA);
                await _context.SaveChangesAsync();
            }

            // Retorna DTO completo
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

            return CreatedAtAction(nameof(GetChamado), new { id = chamado.IdChamado }, readDto);
        }

        // Edita um chamado existente
        [HttpPut("{id}")]
        public async Task<IActionResult> PutChamado(int id, [FromBody] ChamadoUpdateDto dto)
        {
            if (dto == null)
                return BadRequest("Dados inválidos.");

            var chamado = await _context.Chamados
                .Include(c => c.IdCategoriaNavigation)
                .FirstOrDefaultAsync(c => c.IdChamado == id);

            if (chamado == null)
                return NotFound();

            chamado.Titulo = dto.Titulo;
            chamado.Descricao = dto.Descricao;
            chamado.Prioridade = dto.Prioridade;
            chamado.StatusChamado = dto.StatusChamado;

            if (dto.StatusChamado == "Encerrado")
                chamado.DataFechamento = DateTime.Now;
            else
                chamado.DataFechamento = null;

            // Atualiza categoria (nova estrutura 1:N)
            if (dto.IdCategoria.HasValue)
            {
                chamado.IdCategoria = dto.IdCategoria;
            }


            await _context.SaveChangesAsync();
            return NoContent();
        }

        // Deletar um chamado
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

        // Obter notificações de novas mensagens para o cliente
        [HttpGet("notificacoes/mensagens/{idCliente}")]
        public async Task<IActionResult> ObterNotificacoesMensagens(int idCliente)
        {
            // Busca todos os chamados do cliente
            var chamados = await _context.Chamados
                .Where(c => c.IdUsuario == idCliente)
                .ToListAsync();

            var notificacoes = new List<object>();

            foreach (var chamado in chamados)
            {
                // Busca a última interação
                var ultima = await _context.Interacoes
                    .Where(i => i.IdChamado == chamado.IdChamado)
                    .OrderByDescending(i => i.DataHora)
                    .FirstOrDefaultAsync();

                if (ultima == null)
                    continue;

                // Se a última interação NÃO for do cliente → nova resposta
                if (ultima.IdUsuario != idCliente)
                {
                    notificacoes.Add(new
                    {
                        idChamado = chamado.IdChamado,
                        idInteracao = ultima.IdInteracao,
                        titulo = $"Chamado #{chamado.IdChamado} - Nova resposta do suporte",
                        mensagem = ultima.Mensagem.Length > 80
                            ? ultima.Mensagem.Substring(0, 80) + "..."
                            : ultima.Mensagem,
                        data = ultima.DataHora
                    });
                }
            }

            return Ok(notificacoes.OrderByDescending(n =>
                n.GetType().GetProperty("data")!.GetValue(n)));
        }

    }
}
