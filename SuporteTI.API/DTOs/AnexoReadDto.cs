namespace SuporteTI.API.DTOs
{
    public class AnexoReadDto
    {
        public int IdAnexo { get; set; }
        public string NomeArquivo { get; set; } = string.Empty;
        public string Extensao { get; set; } = string.Empty;
        public DateTime DataEnvio { get; set; }
        public string TituloChamado { get; set; } = string.Empty;


        // 🔹 Novo campo — conteúdo do arquivo (imagem, pdf, etc)
        public byte[]? Conteudo { get; set; }
    }
}

