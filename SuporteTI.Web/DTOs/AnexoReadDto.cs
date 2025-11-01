using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuporteTI.Web.DTOs
{
    public class AnexoReadDto
    {
        public int IdAnexo { get; set; }
        public string NomeArquivo { get; set; } = string.Empty;
        public string Extensao { get; set; } = string.Empty;
        public DateTime DataEnvio { get; set; }
        public string TituloChamado { get; set; } = string.Empty;
        public byte[]? Conteudo { get; set; }
    }
}



