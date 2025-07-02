using Microsoft.AspNetCore.Mvc;
using OrderFlow.Data.Interfaces;
using OrderFlow.Domain;
using OrderFlow.Business.Interfaces;
using OrderFlow.API.DTO;
using Microsoft.AspNetCore.Authorization;


namespace OrderFlow.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(Roles = "Admin")]
    public class RolController : Controller
    {
        private readonly IRolBusiness _rolBusiness;
        public RolController(IRolBusiness rolBusiness)
        {
            _rolBusiness = rolBusiness;
        }

        [HttpGet]
        public ActionResult<List<RolDTO>> ObtenerTodos()
        {
            var roles = _rolBusiness.VerRoles();

            if (roles == null || !roles.Any())
            {
                return NotFound("No se encontraron roles.");
            }

            return Ok(roles);
        }

        [HttpGet("{id}")]
        public ActionResult<RolDTO> ObtenerPorId(int id)
        {
            var rol = _rolBusiness.VerRolPorID(id);

            if (rol == null)
            {
                return NotFound($"No se encontró el rol con ID {id}.");
            }

            return Ok(rol);
        }

        [HttpPost]
        public IActionResult Crear([FromBody] RolDTO rol)
        {
            if (rol == null)
            {
                return BadRequest("El rol no puede ser nulo.");
            }

            try
            {

                _rolBusiness.Crear(rol);

                return Ok(rol);

            } catch(Exception ex)
            {
                return BadRequest($"Error al crear rol: {ex.Message}");
            }

        }

        [HttpPut("{id}")]
        public IActionResult Modificar(int id, [FromBody] RolDTO rol)
        {
            if (rol == null || rol.idRol != id)
            {
                return BadRequest("El rol no es válido o el ID no coincide.");
            }

            var rolExistente = _rolBusiness.VerRolPorID(id);

            if (rolExistente == null)
            {
                return NotFound($"No se encontró el rol con ID {id}.");
            }

            try
            {
                _rolBusiness.Modificar(rol);

                return Ok(rol);

            } catch (Exception ex)
            {
                return BadRequest($"Error al modificar rol: {ex.Message}");
            }


        }

        [HttpDelete("{id}")]
        public IActionResult Eliminar(int id)
        {
            var rolExistente = _rolBusiness.VerRolPorID(id);

            if (rolExistente == null)
            {
                return NotFound($"No se encontró el rol con ID {id}.");
            }

            try
            {
                _rolBusiness.Eliminar(id);

                return Ok($"Rol con ID: {id} eliminado correctamente");

            } catch (Exception ex)
            {
                return BadRequest($"Error al eliminar rol: {ex.Message}");
            }


        }
    }
}
