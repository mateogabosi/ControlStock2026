using ControlStock.BD.Datos;
using ControlStock2026.BD.Datos.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ControlStock2026.Server.Controllers
{
    [ApiController]
    [Route("api/venta")]
    public class VentaController : ControllerBase
    {
        private readonly AppDbContext context;

        public VentaController(AppDbContext context)
        {
            this.context = context;
        }

        [HttpGet] // api/venta
        public async Task<ActionResult<List<Venta>>> Get()
        {
            return await context.Ventas
                .Include(v => v.DetalleVentas)
                .ToListAsync();
        }

        [HttpGet("{id:int}")] // api/venta/{id}
        public async Task<ActionResult<Venta>> GetById(int id)
        {
            var venta = await context.Ventas
                .Include(v => v.DetalleVentas)
                .ThenInclude(d => d.Producto)
                .FirstOrDefaultAsync(v => v.Id == id);

            if (venta == null)
            {
                return NotFound("No se encontró la venta especificada.");
            }

            return venta;
        }

        [HttpPost] // api/venta
        public async Task<ActionResult<Venta>> Post(Venta venta)
        {
            context.Ventas.Add(venta);
            await context.SaveChangesAsync();
            return Ok(venta);
        }
    }
}
