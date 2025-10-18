using Microsoft.AspNetCore.Mvc;
using SuporteTI.Data.Models;
using System.Threading.Tasks;

namespace SuporteTI.API.Strategies
{
    public interface IAutenticacaoStrategy
    {
        Task<IActionResult> ExecutarAsync(Usuario usuario);
    }
}

