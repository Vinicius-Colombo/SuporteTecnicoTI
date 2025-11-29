using System.ComponentModel.DataAnnotations;

namespace SuporteTI.API.DTOs
{
    public class ChamadoCreateDto
    {
        [Required, StringLength(100)]
        public string Titulo { get; set; } = string.Empty;

        [Required]
        public string Descricao { get; set; } = string.Empty;

        public string Prioridade { get; set; } = "Media";

        [Required]
        public int IdUsuario { get; set; }

        public string Categoria { get; set; } = string.Empty;

    }
}
