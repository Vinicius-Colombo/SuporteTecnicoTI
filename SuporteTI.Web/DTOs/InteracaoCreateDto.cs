using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuporteTI.Web.DTOs
{
    public class InteracaoCreateDto
    {
        [Required] public int IdChamado { get; set; }
        [Required] public int IdUsuario { get; set; }
        [Required] public string Mensagem { get; set; } = string.Empty;
        [Required] public string Origem { get; set; } = string.Empty;
    }

}
