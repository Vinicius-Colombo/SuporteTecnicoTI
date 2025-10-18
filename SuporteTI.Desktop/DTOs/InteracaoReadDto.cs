﻿namespace SuporteTI.Desktop.DTOs
{
    public class InteracaoReadDto
    {
        public int IdInteracao { get; set; }
        public int IdUsuario { get; set; }
        public string NomeUsuario { get; set; } = string.Empty;
        public string Mensagem { get; set; } = string.Empty;
        public DateTime DataHora { get; set; }
    }
}
