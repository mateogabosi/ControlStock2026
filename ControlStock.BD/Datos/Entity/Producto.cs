using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ControlStock2026.BD.Datos.Entity
{
    [Table("Productos")]
    public class Producto : EntityBase
    {
        [Key]
        [Column("IdProductos")]
        public new int Id { get; set; }

        [Required]
        public string Nombre { get; set; } = string.Empty;

        public string Descripcion { get; set; } = string.Empty;

        // decimal(18,2) es el tipo que ya usa la columna Precio en SQL Server.
        [Column(TypeName = "decimal(18,2)")]
        public decimal Precio { get; set; }

        // La columna en la base de datos se llama "StockAcatual" (typo histórico).
        // Se mantiene el nombre para no romper los datos existentes.
        [Column("StockAcatual")]
        public int StockActual { get; set; }

        public int StockMinimo { get; set; }
    }
}
