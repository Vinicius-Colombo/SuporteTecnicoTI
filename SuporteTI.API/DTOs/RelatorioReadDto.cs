namespace SuporteTI.API.DTOs
{
    public class RelatorioReadDto
    {
        public int TotalChamados { get; set; }
        public int ResolvidosNoPrazo { get; set; }
        public double TempoMedioResolucao { get; set; }
        public string CategoriaMaisIncidente { get; set; } = string.Empty;
        public int TotalAvaliacoes { get; set; }
    }

}
