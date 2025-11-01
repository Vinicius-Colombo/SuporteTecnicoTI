namespace SuporteTI.Web.DTOs
{
    public class InteracaoReadDto
    {
        public int IdInteracao { get; set; }
        public int IdChamado { get; set; }
        public int IdUsuario { get; set; }
        public string NomeUsuario { get; set; } = string.Empty;
        public string Mensagem { get; set; } = string.Empty;
        public DateTime DataHora { get; set; }
        public string Origem { get; set; } = string.Empty;
    }
}

