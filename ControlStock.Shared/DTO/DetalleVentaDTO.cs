namespace ControlStock.Shared.DTOs
{
    public class DetalleVentaDTO
    {
        public int Id { get; set; }
        public int IdProductos { get; set; }
        public int Cantidad { get; set; }
        public decimal PrecioUnitario { get; set; }
        public decimal SubTotal { get; set; }
    }
}
