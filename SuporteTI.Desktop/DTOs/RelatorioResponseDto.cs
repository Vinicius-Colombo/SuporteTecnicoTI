using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuporteTI.Desktop.DTOs
{
    public class RelatorioResponseDto
    {
        public ResumoRelatorioDto Resumo { get; set; } = new();
        public List<ChamadoDetalhadoDto> Chamados { get; set; } = new();
        public GraficosRelatorioDto Graficos { get; set; } = new();
        public RankingsRelatorioDto Rankings { get; set; } = new();
    }

    public class ResumoRelatorioDto
    {
        public int TotalChamados { get; set; }
        public string TempoMedioResolucao { get; set; } = string.Empty;
        public int ResolvidosPrazo { get; set; }
        public string CategoriaMaisIncidente { get; set; } = string.Empty;
        public int TotalAvaliacoes { get; set; }
    }

    public class GraficosRelatorioDto
    {
        public List<ContagemDto> Categorias { get; set; } = new();
        public List<ContagemDto> Prioridades { get; set; } = new();
        public List<EvolucaoDto> Evolucao { get; set; } = new();
    }

    public class RankingsRelatorioDto
    {
        public List<ContagemDto> Tecnicos { get; set; } = new();
        public List<ContagemDto> Categorias { get; set; } = new();
    }

    public class ContagemDto
    {
        public string Nome { get; set; } = string.Empty;
        public int Quantidade { get; set; }
    }

    public class EvolucaoDto
    {
        public string Data { get; set; } = string.Empty;
        public int Quantidade { get; set; }
    }
}

