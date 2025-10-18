namespace SuporteTI.Desktop.DTOs
{
    public class LoginResponseDto
    {
        public int IdUsuario { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Tipo { get; set; } = string.Empty;
        public string? Cpf { get; set; }
        public string? Telefone { get; set; }

        // Se depois usar JWT, pode adicionar aqui:
        // public string Token { get; set; } = string.Empty;
    }
}
