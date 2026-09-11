using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
namespace ControlStock2026.BD.Datos.Entity
{
    public class DetalleVenta : EntityBase
    {
        //[Required(ErrorMessage = "El dato es obligatorio")]
        [Key]
        public int IdDetalleVentas { get; set; }

        //[Required(ErrorMessage = "El dato es obligatorio")]
        public int IdVentas { get; set; }

        //[Required(ErrorMessage = "El dato es obligatorio")]
        public int IdProductos { get; set; }

        public int Cantidad { get; set; }

        public string PrecioUnitario { get; set; }

        public string SubTotal { get; set; }
    }
}

