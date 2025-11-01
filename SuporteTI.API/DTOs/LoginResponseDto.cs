namespace SuporteTI.API.DTOs
{
    public class LoginResponseDto
    {
        public int IdUsuario { get; set; }
        public string Nome { get; set; } = "";
        public string Email { get; set; } = "";
        public string? Tipo { get; set; }
        public string? Cpf { get; set; }
        public string? Telefone { get; set; }
        public string? Endereco { get; set; }            
        public DateOnly? DataNascimento { get; set; }    
        public string? Token { get; set; }
        public bool CodigoValidado { get; set; }
    }
}
