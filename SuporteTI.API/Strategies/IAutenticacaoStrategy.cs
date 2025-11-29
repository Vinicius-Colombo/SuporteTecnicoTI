using Microsoft.AspNetCore.Mvc;
using SuporteTI.Data.Models;

namespace SuporteTI.API.Strategies
{
    public interface IAutenticacaoStrategy
    {
        Task<IActionResult> ExecutarAsync(Usuario usuario);
    }
}

