using System;
using System.Collections.Generic;
using System.Text;

namespace ControlStock.Shared.DTO 
  { 
public class ProductoListadoPrecioDTO
{
    public int IdProductos { get; set; }
    public string Nombre { get; set; } = string.Empty;
    public int Precio { get; set; }
}
  }