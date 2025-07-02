using Microsoft.AspNetCore.Mvc;
using OrderFlow.API.DTO;
using OrderFlow.Business.Interfaces;

namespace OrderFlow.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoriaController : Controller
    {
        private readonly ICategoriaBusiness _categoriaBusiness;

        public CategoriaController(ICategoriaBusiness categoriaBusiness)
        {
            _categoriaBusiness = categoriaBusiness;
        }

        [HttpGet]
        public ActionResult<List<CategoriaDTO>> VerCategorias()
        {
            var categorias = _categoriaBusiness.VerCategorias();

            if (categorias == null || !categorias.Any())
            {
                return new List<CategoriaDTO>();
            }

            return Ok(categorias);
        }

        [HttpGet("{id}")]
        public ActionResult<CategoriaDTO> VerCategoriaPorID(string id)
        {
            var categoria = _categoriaBusiness.VerCategoriaPorID(id);

            if (categoria == null)
            {
                return NotFound();
            }

            return Ok(categoria);
        }

        [HttpPost]
        public IActionResult CrearCategoria([FromBody] CategoriaDTO categoriaDto)
        {
            if (categoriaDto == null || string.IsNullOrEmpty(categoriaDto.codCategoria) || string.IsNullOrEmpty(categoriaDto.descripcion))
            {
                return BadRequest("Datos de categoría inválidos.");
            }

            try
            {
                _categoriaBusiness.Crear(categoriaDto);

                return Ok(categoriaDto);

            } catch (Exception ex)
            {
                return BadRequest($"Error al crear categoria: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public IActionResult ModificarCategoria(string id, [FromBody] CategoriaDTO categoriaDto)
        {
            if (categoriaDto == null || string.IsNullOrEmpty(categoriaDto.codCategoria) || string.IsNullOrEmpty(categoriaDto.descripcion))
            {
                return BadRequest("Datos de categoría inválidos.");
            }

            var categoriaExistente = _categoriaBusiness.VerCategoriaPorID(id);

            if (categoriaExistente == null)
            {
                return NotFound();
            }

            try
            {
                _categoriaBusiness.Modificar(categoriaDto);

                return Ok(categoriaDto);

            } catch(Exception ex)
            {
                return BadRequest($"Error al modificar categoria: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            var categoria = _categoriaBusiness.VerCategoriaPorID(id);

            if (categoria == null)
            {
                return NotFound();
            }

            try
            {
                _categoriaBusiness.Eliminar(id);

                return Ok($"Categoria con ID: {id} eliminada correctamente");

            }
            catch (Exception ex)
            {
                return BadRequest($"Error al eliminar la categoría: {ex.Message}");
            }

        }
    }
}
