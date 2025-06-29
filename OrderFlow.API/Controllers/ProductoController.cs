using Microsoft.AspNetCore.Mvc;
using OrderFlow.API.DTO;
using OrderFlow.Business.Interfaces;

namespace OrderFlow.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductoController : Controller
    {
        private readonly IProductoBusiness _productoBusiness;

        public ProductoController(IProductoBusiness productoBusiness)
        {
            _productoBusiness = productoBusiness;
        }

        [HttpGet]
        public List<ProductoDTO> VerProductos()
        {
            var productos = _productoBusiness.VerProductos();

            if (productos == null || !productos.Any())
            {
                return new List<ProductoDTO>();
            }

            return productos.Select(p => new ProductoDTO
            {
                idProducto = p.IdProducto,
                nombreProducto = p.NombreProducto,
                precio = p.Precio,
                codCategoria = p.CodCategoria,
                cantidadExistencias = p.CantidadExistencias,
                puntoReorden = p.PuntoReorden
            }).ToList();

        }

        [HttpGet("{id}")]
        public ActionResult<ProductoDTO> VerProductoPorID(int id)
        {
            var producto = _productoBusiness.VerProductoPorID(id);

            if (producto == null)
            {
                return NotFound();
            }
            return new ProductoDTO
            {
                idProducto = producto.IdProducto,
                nombreProducto = producto.NombreProducto,
                precio = producto.Precio,
                codCategoria = producto.CodCategoria,
                cantidadExistencias = producto.CantidadExistencias,
                puntoReorden = producto.PuntoReorden
            };
        }

        [HttpPost]
        public IActionResult Crear([FromBody] ProductoDTO productoDto)
        {
            if (productoDto == null)
            {
                return BadRequest("Producto no puede ser nulo.");
            }

            var producto = new OrderFlow.Domain.Producto
            {
                NombreProducto = productoDto.nombreProducto,
                Precio = productoDto.precio,
                CodCategoria = productoDto.codCategoria,
                CantidadExistencias = productoDto.cantidadExistencias,
                PuntoReorden = productoDto.puntoReorden
            };

            _productoBusiness.Crear(producto);

            return CreatedAtAction(nameof(VerProductoPorID), new { id = producto.IdProducto }, producto);
        }

        [HttpPut("{id}")]
        public IActionResult Modificar(int id, [FromBody] ProductoDTO productoDto)
        {
            if (productoDto == null || id != productoDto.idProducto)
            {
                return BadRequest("Datos del producto no válidos.");
            }

            var producto = _productoBusiness.VerProductoPorID(id);

            if (producto == null)
            {
                return NotFound();
            }

            producto.NombreProducto = productoDto.nombreProducto;
            producto.Precio = productoDto.precio;
            producto.CodCategoria = productoDto.codCategoria;
            producto.CantidadExistencias = productoDto.cantidadExistencias;
            producto.PuntoReorden = productoDto.puntoReorden;

            _productoBusiness.Modificar(producto);

            return NoContent();
        }
    }
}
