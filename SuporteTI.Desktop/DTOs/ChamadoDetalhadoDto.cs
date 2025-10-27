using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuporteTI.Desktop.DTOs
{
    public class ChamadoDetalhadoDto
    {
        public int IdChamado { get; set; }
        public DateTime DataAbertura { get; set; }
        public string Tecnico { get; set; } = string.Empty;
        public string Cliente { get; set; } = string.Empty;
        public string Categoria { get; set; } = string.Empty;
        public string Prioridade { get; set; } = string.Empty;
        public string TempoAtendimento { get; set; } = string.Empty;
    }
}
