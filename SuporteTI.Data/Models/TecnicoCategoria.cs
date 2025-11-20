namespace SuporteTI.Data.Models
{
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Tecnico_Categoria")]
    public class TecnicoCategoria
    {
        [Column("id_tecnico")]
        public int IdTecnico { get; set; }

        [Column("id_categoria")]
        public int IdCategoria { get; set; }

        [ForeignKey("IdTecnico")]
        public virtual Usuario Tecnico { get; set; }

        [ForeignKey("IdCategoria")]
        public virtual Categorium Categoria { get; set; }
    }


}
