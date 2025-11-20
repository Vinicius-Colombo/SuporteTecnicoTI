namespace SuporteTI.API.DTOs
{
    public class RelatorioMensalDto
    {
        public string Mes { get; set; } = string.Empty;
        public int TotalChamados { get; set; }
        public int ChamadosAbertos { get; set; }
        public int ChamadosEncerrados { get; set; }
    }
}
