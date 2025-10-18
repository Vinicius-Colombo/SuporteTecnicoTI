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
        private readonly IWebHostEnvironment _env;

        public AnexoController(SuporteTiDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }

        // 🔹 POST: api/Anexo/{chamadoId}
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
                Extensao = anexo.CaminhoArquivo,
                DataEnvio = (DateTime)anexo.DataEnvio
            });
        }


        // 🔹 GET: api/Anexo/{chamadoId}
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
                    Conteudo = a.Conteudo // 🔹 <-- importante!
                })
                .ToListAsync();

            return Ok(anexos);
        }


        // 🔹 GET: api/Anexo/download/{id}
        [HttpGet("download/{id}")]
        public async Task<IActionResult> DownloadAnexo(int id)
        {
            var anexo = await _context.Anexos.FindAsync(id);
            if (anexo == null || anexo.Conteudo == null)
                return NotFound("Anexo não encontrado.");

            var contentType = "application/octet-stream";
            return File(anexo.Conteudo, contentType, anexo.NomeArquivo);
        }



        // 🔹 DELETE: api/Anexo/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAnexo(int id)
        {
            var anexo = await _context.Anexos.FindAsync(id);
            if (anexo == null)
                return NotFound("Anexo não encontrado.");

            // 🔸 Deleta o arquivo físico se existir
            var caminhoCompleto = Path.Combine(_env.WebRootPath, anexo.CaminhoArquivo.TrimStart('/'));
            if (System.IO.File.Exists(caminhoCompleto))
                System.IO.File.Delete(caminhoCompleto);

            // 🔸 Remove do banco
            _context.Anexos.Remove(anexo);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
