using System.ComponentModel.DataAnnotations;

namespace ControlStock2026.BD.Datos.Entity
{
    public class Venta : EntityBase
    {
        public DateTime Fecha { get; set; } = DateTime.Now;

        public decimal Total { get; set; }

        // Propiedad de navegación para los detalles de la venta (si lo usas en tu relación)
        public virtual ICollection<DetalleVenta>? DetalleVentas { get; set; }
    }
}