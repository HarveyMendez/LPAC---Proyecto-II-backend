using Microsoft.AspNetCore.Mvc;
using OrderFlow.API.DTO;
using OrderFlow.Business.Interfaces;
using OrderFlow.Domain;

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
        public List<CategoriaDTO> VerCategorias()
        {
            var categorias = _categoriaBusiness.VerCategorias();

            if (categorias == null || !categorias.Any())
            {
                return new List<CategoriaDTO>();
            }

            return categorias.Select(c => new CategoriaDTO
            {
                codCategoria = c.cod_categoria,
                descripcion = c.descripcion
            }).ToList();
        }

        [HttpGet("{id}")]
        public ActionResult<CategoriaDTO> VerCategoriaPorID(string id)
        {
            var categoria = _categoriaBusiness.VerCategoriaPorID(id);
            if (categoria == null)
            {
                return NotFound();
            }
            return new CategoriaDTO
            {
                codCategoria = categoria.cod_categoria,
                descripcion = categoria.descripcion
            };
        }

        [HttpPost]
        public IActionResult CrearCategoria([FromBody] CategoriaDTO categoriaDto)
        {
            if (categoriaDto == null || string.IsNullOrEmpty(categoriaDto.codCategoria) || string.IsNullOrEmpty(categoriaDto.descripcion))
            {
                return BadRequest("Datos de categoría inválidos.");
            }

            var categoria = new Categoria
            {
                cod_categoria = categoriaDto.codCategoria,
                descripcion = categoriaDto.descripcion
            };

            _categoriaBusiness.Crear(categoria);

            return CreatedAtAction(nameof(VerCategoriaPorID), new { id = categoria.cod_categoria }, categoriaDto);
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

            categoriaExistente.descripcion = categoriaDto.descripcion;

            _categoriaBusiness.Modificar(categoriaExistente);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            var categoria = _categoriaBusiness.VerCategoriaPorID(id);

            if (categoria == null)
            {
                return NotFound();
            }

            _categoriaBusiness.Eliminar(id);

            return NoContent();
        }
    }
}
