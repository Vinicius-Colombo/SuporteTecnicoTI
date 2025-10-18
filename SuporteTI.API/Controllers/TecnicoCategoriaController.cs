using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SuporteTI.API.DTOs;
using SuporteTI.Data.Models;

namespace SuporteTI.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TecnicoCategoriaController : ControllerBase
    {
        private readonly SuporteTiDbContext _context;

        public TecnicoCategoriaController(SuporteTiDbContext context)
        {
            _context = context;
        }

        // 🔹 GET: api/TecnicoCategoria
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TecnicoCategoriaReadDto>>> GetVinculos()
        {
            var vinculos = await _context.TecnicoCategorias
                .Include(tc => tc.Tecnico)
                .Include(tc => tc.Categoria)
                .Select(tc => new TecnicoCategoriaReadDto
                {
                    IdTecnico = tc.IdTecnico,
                    NomeTecnico = tc.Tecnico.Nome,
                    IdCategoria = tc.IdCategoria,
                    NomeCategoria = tc.Categoria.Nome
                })
                .ToListAsync();

            return Ok(vinculos);
        }

        // 🔹 POST: api/TecnicoCategoria
        [HttpPost]
        public async Task<ActionResult> Vincular([FromBody] TecnicoCategoriaCreateDto dto)
        {
            var tecnico = await _context.Usuarios
            .FirstOrDefaultAsync(u => u.IdUsuario == dto.IdTecnico &&
            EF.Functions.Like(u.Tipo.ToLower(), "%tecnic%"));

            if (tecnico == null)
                return BadRequest("O usuário informado não é um técnico válido.");

            var categoria = await _context.Categoria.FindAsync(dto.IdCategoria);
            if (categoria == null)
                return BadRequest("Categoria não encontrada.");

            var vinculoExistente = await _context.TecnicoCategorias
                .FirstOrDefaultAsync(tc => tc.IdTecnico == dto.IdTecnico && tc.IdCategoria == dto.IdCategoria);

            if (vinculoExistente != null)
                return Conflict("Esse técnico já está vinculado a essa categoria.");

            var novoVinculo = new TecnicoCategoria
            {
                IdTecnico = dto.IdTecnico,
                IdCategoria = dto.IdCategoria
            };

            _context.TecnicoCategorias.Add(novoVinculo);
            await _context.SaveChangesAsync();

            return Ok(new
            {
                mensagem = $"Técnico '{tecnico.Nome}' vinculado à categoria '{categoria.Nome}' com sucesso!"
            });
        }

        // 🔹 DELETE: api/TecnicoCategoria/{idTecnico}/{idCategoria}
        [HttpDelete("{idTecnico}/{idCategoria}")]
        public async Task<ActionResult> Desvincular(int idTecnico, int idCategoria)
        {
            var vinculo = await _context.TecnicoCategorias
                .FirstOrDefaultAsync(tc => tc.IdTecnico == idTecnico && tc.IdCategoria == idCategoria);

            if (vinculo == null)
                return NotFound("Vínculo não encontrado.");

            _context.TecnicoCategorias.Remove(vinculo);
            await _context.SaveChangesAsync();

            return Ok(new { mensagem = "Vínculo removido com sucesso." });
        }
    }
}
