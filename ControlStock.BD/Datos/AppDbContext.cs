using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.Data;
using System.Net.Http.Metrics;

namespace ControlStock.BD.Datos
{
    public class AppDbContext : DbContext
    {
        public DbSet<ControlStock2026.BD.Datos.Entity.DetalleVenta> DetalleVentas { get; set; }
        public DbSet<ControlStock2026.BD.Datos.Entity.Venta> Ventas { get; set; }
        public DbSet<ControlStock2026.BD.Datos.Entity.Producto> Productos { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options) { }
         protected AppDbContext() 
        {
        }
        
    }
}
