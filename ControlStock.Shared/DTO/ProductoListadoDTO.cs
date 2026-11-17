namespace ControlStock.Shared.DTOs
{
    public class ProductoListadoDTO
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string? Descripcion { get; set; }
        public decimal Precio { get; set; } // Asegúrate de que sea decimal aquí también
        public int StockActual { get; set; }
        public int StockMinimo { get; set; }
    }
}
