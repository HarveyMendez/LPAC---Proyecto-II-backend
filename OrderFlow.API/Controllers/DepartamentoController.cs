using Microsoft.AspNetCore.Mvc;
using OrderFlow.Business.Interfaces;
using OrderFlow.API.DTO;
using Microsoft.AspNetCore.Authorization;


namespace OrderFlow.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DepartamentoController : Controller
    {
        private readonly IDepartamentoBusiness _departamentoBusiness;

        public DepartamentoController(IDepartamentoBusiness departamentoBusiness)
        {
            _departamentoBusiness = departamentoBusiness;
        }

        [Authorize(Roles = "Admin,Usuario")]
        [HttpGet]
        public ActionResult<List<DepartamentoDTO>> VerDepartamentos()
        {
            var departamentos = _departamentoBusiness.ObtenerTodos();

            if (departamentos == null || !departamentos.Any())
            {
                return new List<DepartamentoDTO>();
            }

            return Ok(departamentos);
        }

        [Authorize(Roles = "Admin,Usuario")]
        [HttpGet("{id}")]
        public ActionResult<DepartamentoDTO> VerDepartamentoPorID(string id)
        {
            var departamento = _departamentoBusiness.ObtenerPorId(id);

            if (departamento == null)
            {
                return NotFound();
            }

            return Ok(departamento);

        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult CrearDepartamento([FromBody] DepartamentoDTO departamentoDto)
        {
            if (departamentoDto == null || string.IsNullOrEmpty(departamentoDto.codDepartamento) || string.IsNullOrEmpty(departamentoDto.nombreDepartamento))
            {
                return BadRequest("Datos de departamento inválidos.");
            }

            try
            {
                _departamentoBusiness.Crear(departamentoDto);

                return Ok(departamentoDto);

            } catch(Exception ex)
            {
                return BadRequest($"Error al crear departamento: {ex.Message}");
            }
        }

        [Authorize(Roles = "Admin")]
        [HttpPut("{id}")]
        public IActionResult ModificarDepartamento(string id, [FromBody] DepartamentoDTO departamentoDto)
        {
            if (departamentoDto == null || string.IsNullOrEmpty(departamentoDto.codDepartamento) || string.IsNullOrEmpty(departamentoDto.nombreDepartamento))
            {
                return BadRequest("Datos de departamento inválidos.");
            }

            var departamento = _departamentoBusiness.ObtenerPorId(id);

            if (departamento == null)
            {
                return NotFound();
            }

            try
            {
                _departamentoBusiness.Modificar(departamentoDto);

                return Ok(departamentoDto);

            } catch(Exception ex)
            {
                return BadRequest($"Error al modificar departamento: {ex.Message}");
            }
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public IActionResult EliminarDepartamento(string id)
        {
            var departamento = _departamentoBusiness.ObtenerPorId(id);

            if (departamento == null)
            {
                return NotFound();
            }

            try
            {
                _departamentoBusiness.Eliminar(id);

                return Ok($"Departamento con ID: {id} eliminado correctamente");

            } catch(Exception ex)
            {
                return BadRequest($"Error al eliminar departamento: {ex.Message}");
            }

   
        }
    }
}
