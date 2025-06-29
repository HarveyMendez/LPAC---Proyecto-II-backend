using Microsoft.AspNetCore.Mvc;
using OrderFlow.API.DTO;
using OrderFlow.Business.Interfaces;

namespace OrderFlow.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmpleadoController : Controller
    {
        private readonly IEmpleadoBusiness _empleadoBusiness;

        public EmpleadoController(IEmpleadoBusiness empleadoBusiness)
        {
            _empleadoBusiness = empleadoBusiness;
        }

        [HttpGet]
        public ActionResult<List<EmpleadoDTO>> ObtenerTodos()
        {
            var empleados = _empleadoBusiness.ObtenerTodos();

            if (empleados == null || !empleados.Any())
            {
                return NotFound("No se encontraron empleados.");
            }

            return Ok(empleados);
        }

        [HttpGet]
        [Route("{id:int}")]
        public ActionResult<EmpleadoDTO> ObtenerPorId(int id)
        {
            var empleadoDTO = _empleadoBusiness.ObtenerPorId(id);

            if (empleadoDTO == null)
            {
                return BadRequest($"No se encontró un empleado con el ID {id}.");
            }

            return empleadoDTO;

        }

        [HttpPost]
        public IActionResult CrearEmpleado([FromBody] EmpleadoDTO empleadoDto)
        {
            if (empleadoDto == null)
            {
                return BadRequest("El empleado no puede ser nulo.");
            }

            try
            {
                _empleadoBusiness.Crear(empleadoDto);

                return Ok(empleadoDto);

            }
            catch (Exception ex)
            {
                return BadRequest($"Error al crear el empleado: {ex.Message}");
            }

        }

        [HttpPut("{id}")]
        public IActionResult ModificarEmpleado([FromBody] EmpleadoDTO empleadoDto)
        {
            if (empleadoDto == null)
            {
                return BadRequest("El empleado no puede ser nulo.");
            }

            try
            {
                _empleadoBusiness.Modificar(empleadoDto);

                return Ok(empleadoDto);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error al modificar el empleado: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public IActionResult EliminarEmpleado(int id)
        {
            try
            {
                _empleadoBusiness.Eliminar(id);

                return Ok($"Empleado con ID {id} eliminado correctamente.");

            }
            catch (Exception ex)
            {
                return BadRequest($"Error al eliminar el empleado: {ex.Message}");
            }
        }
    }
}
