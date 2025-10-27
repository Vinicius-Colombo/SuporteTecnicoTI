namespace SuporteTI.Desktop.DTOs
{
    public class AvaliacaoReadDto
    {
        public int IdAvaliacao { get; set; }
        public int ChamadoId { get; set; }
        public string TituloChamado { get; set; } = string.Empty;
        public int Nota { get; set; }
        public string Comentario { get; set; } = string.Empty;
        public string Tecnico { get; set; } = string.Empty;
        public string NomeUsuario { get; set; } = string.Empty;

    }
}
