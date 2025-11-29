namespace SuporteTI.Web.DTOs
{
    public class ChamadoReadDto
    {
        public int IdChamado { get; set; }
        public string Titulo { get; set; } = string.Empty;
        public string Descricao { get; set; } = string.Empty;
        public string? Prioridade { get; set; }
        public string? StatusChamado { get; set; }
        public DateTime DataAbertura { get; set; }
        public int? IdTecnico { get; set; }

        public UsuarioReadDto? Tecnico { get; set; }
        public UsuarioReadDto? Usuario { get; set; }
        public CategoriaReadDto? Categoria { get; set; }
    }
}
