using System.Collections.Generic;

namespace SuporteTI.API.DTOs
{
    public class RelatorioFiltradoResumoDto
    {
        public int TotalChamados { get; set; }
        public int Abertos { get; set; }
        public int EmAtendimento { get; set; }
        public int Resolvidos { get; set; }
        public int Encerrados { get; set; }

        public List<ChamadoReadDto>? Chamados { get; set; } // detalhado, opcional
    }
}
