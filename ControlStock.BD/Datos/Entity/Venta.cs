using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ControlStock2026.BD.Datos.Entity
{
    public class Venta : EntityBase
    {
        //[Required(ErrorMessage = "El dato es obligatorio")]
        [Key]
        public int IdVentas { get; set; }
        public int Total { get; set; }
        public int ProductoId { get; set; }
        public int Cantidad { get; set; }
        public decimal PrecioUnitario { get; set; }
        public decimal Subtotal { get; set; }
    }
}