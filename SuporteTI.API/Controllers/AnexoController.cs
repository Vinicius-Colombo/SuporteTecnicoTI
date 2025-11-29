using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SuporteTI.Data.Models;
using SuporteTI.API.DTOs;

namespace SuporteTI.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AnexoController : ControllerBase
    {
        private readonly SuporteTiDbContext _context;

        public AnexoController(SuporteTiDbContext context)
        {
            _context = context;
        }

        [HttpPost("{chamadoId}")]
        public async Task<ActionResult<AnexoReadDto>> Upload(int chamadoId, IFormFile arquivo)
        {
            var chamado = await _context.Chamados.FindAsync(chamadoId);
            if (chamado == null)
                return NotFound("Chamado não encontrado.");

            if (arquivo == null || arquivo.Length == 0)
                return BadRequest("Nenhum arquivo enviado.");

            byte[] conteudo;
            using (var ms = new MemoryStream())
            {
                await arquivo.CopyToAsync(ms);
                conteudo = ms.ToArray();
            }

            var anexo = new Anexo
            {
                IdChamado = chamadoId,
                NomeArquivo = arquivo.FileName,
                CaminhoArquivo = Path.GetExtension(arquivo.FileName), 
                Conteudo = conteudo,
                DataEnvio = DateTime.Now
            };

            _context.Anexos.Add(anexo);
            await _context.SaveChangesAsync();

            return Ok(new AnexoReadDto
            {
                IdAnexo = anexo.IdAnexo,
                NomeArquivo = anexo.NomeArquivo,
                Extensao = Path.GetExtension(arquivo.FileName),
                DataEnvio = (DateTime)anexo.DataEnvio
            });
        }

        [HttpGet("{chamadoId}")]
        public async Task<ActionResult<IEnumerable<AnexoReadDto>>> GetAnexosPorChamado(int chamadoId)
        {
            var anexos = await _context.Anexos
                .Include(a => a.IdChamadoNavigation)
                .Where(a => a.IdChamado == chamadoId)
                .Select(a => new AnexoReadDto
                {
                    IdAnexo = a.IdAnexo,
                    NomeArquivo = a.NomeArquivo,
                    Extensao = Path.GetExtension(a.NomeArquivo),
                    DataEnvio = (DateTime)a.DataEnvio,
                    TituloChamado = a.IdChamadoNavigation.Titulo,
                    Conteudo = a.Conteudo
                })
                .ToListAsync();

            return Ok(anexos);
        }

        [HttpGet("download/{id}")]
        public async Task<IActionResult> DownloadAnexo(int id)
        {
            var anexo = await _context.Anexos.FindAsync(id);
            if (anexo == null || anexo.Conteudo == null)
                return NotFound("Anexo não encontrado.");

            return File(anexo.Conteudo, "application/octet-stream", anexo.NomeArquivo);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAnexo(int id)
        {
            var anexo = await _context.Anexos.FindAsync(id);
            if (anexo == null)
                return NotFound("Anexo não encontrado.");

            _context.Anexos.Remove(anexo);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
