using ControlStock.BD.Datos;
using ControlStock.Shared.DTO;
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
        
        [HttpGet]//api/Producto
        public async Task<ActionResult<List<Producto>>> Get()
        {

            var listado = await context.Productos.ToListAsync();
            if (listado == null)
            {
                return NotFound("No se encontro elementos de la lista, VERIFICAR");
            }
            return Ok(listado);
        }
        [HttpGet("listaproductoprecio")] //api/producto/listaproductoprecio
        public async Task<ActionResult<List<ProductoListadoPrecioDTO>>> ListaProducto()
        {
            var lista = await context.Productos
                .Select(p => new ProductoListadoPrecioDTO
                {
                    IdProductos = p.IdProductos,
                    Nombre = p.Nombre,
                    Precio = p.Precio,
                })
                .ToListAsync();
            
            if (lista == null)
            {
                return NotFound("No se encontro elementos de la lista, VERIFICAR.");
            }

            if (lista.Count == 0)
            {
                return NotFound("Lista sin registros.");
            }

            return Ok(lista);
        }

        [HttpGet("{idproducto:int}")]
        public async Task<ActionResult<ProductoDTO>> GetById(int idproducto)
        {
            var entidad = await context.Productos.FirstOrDefaultAsync(x=>x.IdProductos == idproducto);

            if (entidad is null)
            {
                return NotFound($"No existe el registro con id: {idproducto}.");
            } 
            var DTO = new ProductoDTO();
            DTO.IdProductos = entidad.IdProductos;
            DTO.Nombre = entidad.Nombre;

            return Ok(DTO);
        }

    }
}