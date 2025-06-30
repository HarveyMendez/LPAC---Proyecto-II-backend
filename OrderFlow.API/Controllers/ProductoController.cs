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
        public ActionResult<List<ProductoDTO>> VerProductos()
        {
            var productos = _productoBusiness.VerProductos();

            if (productos == null || !productos.Any())
            {
                return NotFound();
            }

            return Ok(productos);

        }

        [HttpGet("{id}")]
        public ActionResult<ProductoDTO> VerProductoPorID(int id)
        {
            var producto = _productoBusiness.VerProductoPorID(id);

            if (producto == null)
            {
                return NotFound();
            }

            return Ok(producto);
        }

        [HttpPost]
        public IActionResult Crear([FromBody] ProductoDTO productoDto)
        {
            if (productoDto == null)
            {
                return BadRequest("Producto no puede ser nulo.");
            }

            try
            {
                _productoBusiness.Crear(productoDto);

                return Ok(productoDto);
                
            } catch(Exception ex)
            {
                return BadRequest($"Error al crear producto: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public IActionResult Modificar(int id, [FromBody] ProductoDTO productoDto)
        {
            if (productoDto == null || id != productoDto.idProducto)
            {
                return BadRequest("Datos del producto no válidos.");
            }

            var producto = _productoBusiness.VerProductoPorID(id);

            if(producto == null)
            {
                return BadRequest("El producto no puede ser nulo");
            }

            try
            {
                _productoBusiness.Modificar(productoDto);

                return Ok(productoDto);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error al modificar producto: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var producto = _productoBusiness.VerProductoPorID(id);

            if (producto == null)
            {
                return NotFound($"No se encontro el producto con ID: {id}");

            }

            try
            {
                _productoBusiness.Eliminar(id);

                return Ok($"Producto con ID: {id} eliminado");
            }
            catch (Exception ex) 
            {
                return BadRequest($"Error al eliminar producto: {ex.Message}");
            }
            
        }

    }
}
