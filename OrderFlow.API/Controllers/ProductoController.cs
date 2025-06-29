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
                idProducto = p.id_producto,
                nombreProducto = p.nombre_producto,
                precio = p.precio,
                categoria = new CategoriaDTO
                {
                    codCategoria = p.cod_categoria,
                    descripcion = p.Categoria.descripcion,
                },
                cantidadExistencias = p.cantidad_existencias,
                puntoReorden = p.punto_reorden,
                aplicaImpuesto = p.aplica_impuesto,
                talla = p.talla,
                eliminado = p.eliminado
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
                idProducto = producto.id_producto,
                nombreProducto = producto.nombre_producto,
                precio = producto.precio,
                categoria = new CategoriaDTO
                {
                    codCategoria = producto.cod_categoria,
                    descripcion = producto.Categoria?.descripcion ?? string.Empty,
                },
                cantidadExistencias = producto.cantidad_existencias,
                puntoReorden = producto.punto_reorden,
                aplicaImpuesto = producto.aplica_impuesto,
                talla = producto.talla,
                eliminado = producto.eliminado
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
                nombre_producto = productoDto.nombreProducto,
                precio = productoDto.precio,
                cantidad_existencias = productoDto.cantidadExistencias,
                punto_reorden = productoDto.puntoReorden,
                aplica_impuesto = productoDto.aplicaImpuesto,
                talla = productoDto.talla,
                eliminado = productoDto.eliminado,
                cod_categoria = productoDto.categoria.codCategoria

            };

            _productoBusiness.Crear(producto);

            return CreatedAtAction(nameof(VerProductoPorID), new { id = producto.id_producto }, producto);
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

            producto.nombre_producto = productoDto.nombreProducto;
            producto.precio = productoDto.precio;
            producto.cantidad_existencias = productoDto.cantidadExistencias;
            producto.punto_reorden = productoDto.puntoReorden;
            producto.aplica_impuesto = productoDto.aplicaImpuesto;
            producto.talla = productoDto.talla;
            producto.eliminado = productoDto.eliminado;
            producto.cod_categoria = productoDto.categoria.codCategoria;

            _productoBusiness.Modificar(producto);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var producto = _productoBusiness.VerProductoPorID(id);

            if (producto == null)
            {
                return NotFound();

            }
            _productoBusiness.Eliminar(id);

            return NoContent();
        }

    }
}
