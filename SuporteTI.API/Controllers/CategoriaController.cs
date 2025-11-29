using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SuporteTI.Data.Models;
using SuporteTI.API.DTOs;

namespace SuporteTI.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoriaController : ControllerBase
    {
        private readonly SuporteTiDbContext _context;

        public CategoriaController(SuporteTiDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoriaReadDto>>> GetCategorias()
        {
            var categorias = await _context.Categoria.ToListAsync();

            if (!categorias.Any())
                return NotFound("Nenhuma categoria encontrada.");

            var categoriasDto = categorias.Select(c => new CategoriaReadDto
            {
                IdCategoria = c.IdCategoria,
                Nome = c.Nome
            }).ToList();

            return Ok(categoriasDto);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CategoriaReadDto>> GetCategoria(int id)
        {
            var categoria = await _context.Categoria.FindAsync(id);

            if (categoria == null)
                return NotFound("Categoria não encontrada.");

            var dto = new CategoriaReadDto
            {
                IdCategoria = categoria.IdCategoria,
                Nome = categoria.Nome
            };

            return Ok(dto);
        }

        [HttpPost]
        public async Task<ActionResult<CategoriaReadDto>> PostCategoria([FromBody] CategoriaCreateDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest("Os dados informados são inválidos.");

            // Verifica se já existe categoria com o mesmo nome
            bool existe = await _context.Categoria.AnyAsync(c => c.Nome.ToLower() == dto.Nome.ToLower());
            if (existe)
                return Conflict("Já existe uma categoria com esse nome.");

            var categoria = new Categorium
            {
                Nome = dto.Nome
            };

            _context.Categoria.Add(categoria);
            await _context.SaveChangesAsync();

            var readDto = new CategoriaReadDto
            {
                IdCategoria = categoria.IdCategoria,
                Nome = categoria.Nome
            };

            return CreatedAtAction(nameof(GetCategoria), new { id = categoria.IdCategoria }, readDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutCategoria(int id, [FromBody] CategoriaCreateDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest("Os dados informados são inválidos.");

            var categoria = await _context.Categoria.FindAsync(id);
            if (categoria == null)
                return NotFound("Categoria não encontrada.");

            bool existe = await _context.Categoria.AnyAsync(c => c.Nome.ToLower() == dto.Nome.ToLower() && c.IdCategoria != id);
            if (existe)
                return Conflict("Já existe outra categoria com esse nome.");

            categoria.Nome = dto.Nome;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategoria(int id)
        {
            var categoria = await _context.Categoria.FindAsync(id);
            if (categoria == null)
                return NotFound("Categoria não encontrada.");

            _context.Categoria.Remove(categoria);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
