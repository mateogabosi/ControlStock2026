using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ControlStock2026.BD.Datos.Entity
{
    public class Producto : EntityBase
    {
        
        [Key]
        public int IdProductos { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public int Precio { get; set; }
        public string StockAcatual { get; set; }
        public string StockMinimo {get; set; }

    }

    public class EntityBase
    {
    }
}
