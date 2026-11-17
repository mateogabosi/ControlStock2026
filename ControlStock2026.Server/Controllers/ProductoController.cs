using ControlStock.BD.Datos;
using ControlStock.Shared.DTOs;
using ControlStock2026.BD.Datos.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ControlStock2026.Server.Controllers
{
    [ApiController]
    [Route("api/producto")]
    public class ProductoController : ControllerBase
    {
        private readonly AppDbContext context;

        public ProductoController(AppDbContext context)
        {
            this.context = context;
        }

        // GET: api/producto
        [HttpGet]
        public async Task<ActionResult<List<ProductoListadoDTO>>> Get()
        {
            try
            {
                var lista = await context.Productos
                    .AsNoTracking()
                    .OrderBy(p => p.Nombre)
                    .Select(p => new ProductoListadoDTO
                    {
                        Id = p.Id,
                        Nombre = p.Nombre,
                        Descripcion = p.Descripcion,
                        Precio = p.Precio,
                        StockActual = p.StockActual,
                        StockMinimo = p.StockMinimo
                    })
                    .ToListAsync();

                return Ok(lista);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    $"Error interno en el GET: {ex.Message}");
            }
        }

        // GET: api/producto/5
        [HttpGet("{idproducto:int}")]
        public async Task<ActionResult<ProductoDTO>> GetById(int idproducto)
        {
            var entidad = await context.Productos
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == idproducto);

            if (entidad is null)
            {
                return NotFound($"No existe el registro con id: {idproducto}.");
            }

            return Ok(MapearADto(entidad));
        }

        // POST: api/producto
        [HttpPost]
        public async Task<ActionResult<ProductoDTO>> Post([FromBody] ProductoDTO productoDto)
        {
            // [ApiController] valida automáticamente, pero dejamos el chequeo explícito.
            if (!ModelState.IsValid)
            {
                return ValidationProblem(ModelState);
            }

            var producto = new Producto
            {
                Nombre = (productoDto.Nombre ?? string.Empty).Trim(),
                Descripcion = productoDto.Descripcion?.Trim() ?? string.Empty,
                Precio = productoDto.Precio,
                StockActual = productoDto.StockActual,
                StockMinimo = productoDto.StockMinimo
            };

            context.Productos.Add(producto);

            try
            {
                await context.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    $"No se pudo guardar el producto en la base de datos: {ex.InnerException?.Message ?? ex.Message}");
            }

            var resultado = MapearADto(producto);

            // 201 Created + Location: api/producto/{id}
            return CreatedAtAction(nameof(GetById), new { idproducto = producto.Id }, resultado);
        }

        // PUT: api/producto/5
        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(int id, [FromBody] ProductoDTO productoDto)
        {
            if (id != productoDto.Id)
            {
                return BadRequest("El ID del producto no coincide.");
            }

            if (!ModelState.IsValid)
            {
                return ValidationProblem(ModelState);
            }

            var producto = await context.Productos.FindAsync(id);
            if (producto is null)
            {
                return NotFound("El producto no existe.");
            }

            producto.Nombre = (productoDto.Nombre ?? string.Empty).Trim();
            producto.Descripcion = productoDto.Descripcion?.Trim() ?? string.Empty;
            producto.Precio = productoDto.Precio;
            producto.StockActual = productoDto.StockActual;
            producto.StockMinimo = productoDto.StockMinimo;

            await context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: api/producto/todos?confirmar=true
        [HttpDelete("todos")]
        public async Task<ActionResult<int>> DeleteTodos([FromQuery] bool confirmar = false)
        {
            // Protección básica: sin confirmar=true no se borra nada.
            if (!confirmar)
            {
                return BadRequest("Debe enviar confirmar=true para eliminar todos los productos.");
            }

            try
            {
                // ExecuteDeleteAsync genera un único DELETE FROM Productos
                // y devuelve la cantidad de filas afectadas.
                var eliminados = await context.Productos.ExecuteDeleteAsync();
                return Ok(eliminados);
            }
            catch (DbUpdateException ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    $"No se pudieron eliminar los productos: {ex.InnerException?.Message ?? ex.Message}");
            }
        }

        // DELETE: api/producto/5
        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                // Delete en una sola consulta: devuelve 0 si el Id no existe.
                var eliminados = await context.Productos
                    .Where(p => p.Id == id)
                    .ExecuteDeleteAsync();

                if (eliminados == 0)
                {
                    return NotFound($"No existe el producto con id: {id}.");
                }

                return NoContent();
            }
            catch (DbUpdateException ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    $"No se pudo eliminar el producto: {ex.InnerException?.Message ?? ex.Message}");
            }
        }

        private static ProductoDTO MapearADto(Producto entidad) => new()
        {
            Id = entidad.Id,
            Nombre = entidad.Nombre,
            Descripcion = entidad.Descripcion,
            Precio = entidad.Precio,
            StockActual = entidad.StockActual,
            StockMinimo = entidad.StockMinimo
        };
    }
}
