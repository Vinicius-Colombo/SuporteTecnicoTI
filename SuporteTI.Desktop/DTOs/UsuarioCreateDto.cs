using System.ComponentModel.DataAnnotations;

namespace SuporteTI.Desktop.DTOs
{
    public class UsuarioCreateDto
    {
        [Required, StringLength(100)]
        public string Nome { get; set; } = string.Empty;

        [Required, EmailAddress, StringLength(100)]
        public string Email { get; set; } = string.Empty;

        [StringLength(100, MinimumLength = 6)]
        public string Senha { get; set; } = string.Empty;

        [Required]
        public string Tipo { get; set; } = "Cliente";

        public string? Cpf { get; set; }
        public string? Telefone { get; set; }
        public string? Endereco { get; set; }
        public DateTime? DataNascimento { get; set; }
    }
}
