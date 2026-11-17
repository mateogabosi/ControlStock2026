using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ControlStock2026.BD.Datos.Entity
{
    public class DetalleVenta : EntityBase
    {
        public int IdDetalleVentas { get; set; }

        public int IdVentas { get; set; }
        [ForeignKey("IdVentas")]
        public virtual Venta? Venta { get; set; }

        public int IdProductos { get; set; }
        [ForeignKey("IdProductos")]
        public virtual Producto? Producto { get; set; }

        public int Cantidad { get; set; }

        public decimal PrecioUnitario { get; set; }

        public decimal SubTotal { get; set; }
    }
}