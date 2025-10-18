using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using SuporteTI.Data.Models;

namespace SuporteTI.API.Strategies
{
    public class CodigoAtivoNaoValidadoStrategy : IAutenticacaoStrategy
    {
        public CodigoAtivoNaoValidadoStrategy() { }

        public Task<IActionResult> ExecutarAsync(Usuario usuario)
        {
            return Task.FromResult<IActionResult>(
                new OkObjectResult(new { Mensagem = "Já existe um código ativo. Digite o código enviado anteriormente." })
            );
        }
    }
}
