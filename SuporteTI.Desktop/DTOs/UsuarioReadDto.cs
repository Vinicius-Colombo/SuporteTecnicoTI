﻿namespace SuporteTI.Desktop.DTOs
{
    public class UsuarioReadDto
    {
        public int IdUsuario { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string? Tipo { get; set; }
        public bool Ativo { get; set; }
        public string? Cpf { get; set; }
        public string? Telefone { get; set; }
    }
}
