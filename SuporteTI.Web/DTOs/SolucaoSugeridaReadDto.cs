namespace SuporteTI.Web.DTOs
{
    public class SolucaoSugeridaReadDto
    {
        public int IdSolucao { get; set; }
        public int IdChamado { get; set; }
        public string TituloChamado { get; set; } = string.Empty;
        public string Titulo { get; set; } = string.Empty;
        public string Conteudo { get; set; } = string.Empty;
        public bool Aceita { get; set; }
    }

}
