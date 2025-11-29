using Microsoft.AspNetCore.Mvc;
using SuporteTI.Data.Models;


namespace SuporteTI.API.Strategies
{
    public class CodigoExpiradoStrategy : IAutenticacaoStrategy
    {
        private readonly SuporteTiDbContext _context;
        private readonly IConfiguration _configuration;

        public CodigoExpiradoStrategy(SuporteTiDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        public async Task<IActionResult> ExecutarAsync(Usuario usuario)
        {
            // Gera novo código e seta expiração de 24h
            var codigo = new Random().Next(100000, 999999).ToString();
            usuario.CodigoVerificacao = codigo;
            usuario.ExpiracaoCodigo = DateTime.Now.AddHours(24);
            usuario.CodigoValidado = false;

            await _context.SaveChangesAsync();

            return new OkObjectResult(new { Mensagem = "Código de verificação enviado com sucesso!" });
        }
    }
}
