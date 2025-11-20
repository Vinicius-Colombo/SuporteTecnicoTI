using System.ComponentModel.DataAnnotations.Schema;

namespace SuporteTI.Data.Models
{
    public partial class Usuario
    {
        [Column("codigo_verificacao")]
        public string? CodigoVerificacao { get; set; }
        [Column("expiracao_codigo")]
        public DateTime? ExpiracaoCodigo { get; set; }
    }
}
