using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace SuporteTI.Data.Models
{
    // OBS: o nome do namespace deve bater com o do arquivo gerado pelo scaffold
    public partial class Usuario
    {
        // propriedades correspondentes às colunas novas
        [Column("codigo_verificacao")]
        public string? CodigoVerificacao { get; set; }
        [Column("expiracao_codigo")]
        public DateTime? ExpiracaoCodigo { get; set; }
    }
}
