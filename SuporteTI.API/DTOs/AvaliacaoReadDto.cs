namespace SuporteTI.API.DTOs
{
    public class AvaliacaoReadDto
    {
        public int IdAvaliacao { get; set; }
        public int IdChamado { get; set; }
        public string TituloChamado { get; set; } = string.Empty;
        public string NomeUsuario { get; set; } = string.Empty;
        public int Nota { get; set; }
        public string? Comentario { get; set; }
    }

}
