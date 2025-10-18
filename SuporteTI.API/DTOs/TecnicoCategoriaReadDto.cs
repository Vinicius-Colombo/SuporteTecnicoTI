namespace SuporteTI.API.DTOs
{
    public class TecnicoCategoriaReadDto
    {
        public int IdTecnico { get; set; }
        public string NomeTecnico { get; set; } = string.Empty;
        public int IdCategoria { get; set; }
        public string NomeCategoria { get; set; } = string.Empty;
    }
}
