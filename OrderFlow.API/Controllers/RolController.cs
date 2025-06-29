using Microsoft.AspNetCore.Mvc;
using OrderFlow.Data.Interfaces;
using OrderFlow.Domain;
using OrderFlow.Business.Interfaces;


namespace OrderFlow.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RolController : Controller
    {
        private readonly IRolBusiness _rolBusiness;
        public RolController(IRolBusiness rolBusiness)
        {
            _rolBusiness = rolBusiness;
        }

        [HttpGet]
        public IActionResult ObtenerTodos()
        {
            var roles = _rolBusiness.VerRoles();

            if (roles == null || !roles.Any())
            {
                return NotFound("No se encontraron roles.");
            }

            return Ok(roles);
        }

        [HttpGet("{id}")]
        public IActionResult ObtenerPorId(int id)
        {
            var rol = _rolBusiness.VerRolPorID(id);

            if (rol == null)
            {
                return NotFound($"No se encontró el rol con ID {id}.");
            }

            return Ok(rol);
        }

        [HttpPost]
        public IActionResult Crear([FromBody] Rol rol)
        {
            if (rol == null)
            {
                return BadRequest("El rol no puede ser nulo.");
            }

            _rolBusiness.Crear(rol);

            return CreatedAtAction(nameof(ObtenerPorId), new { id = rol.id_rol }, rol);
        }

        [HttpPut("{id}")]
        public IActionResult Modificar(int id, [FromBody] Rol rol)
        {
            if (rol == null || rol.id_rol != id)
            {
                return BadRequest("El rol no es válido o el ID no coincide.");
            }

            var rolExistente = _rolBusiness.VerRolPorID(id);

            if (rolExistente == null)
            {
                return NotFound($"No se encontró el rol con ID {id}.");
            }

            rolExistente.nombre_rol = rol.nombre_rol;

            _rolBusiness.Modificar(rol);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Eliminar(int id)
        {
            var rolExistente = _rolBusiness.VerRolPorID(id);

            if (rolExistente == null)
            {
                return NotFound($"No se encontró el rol con ID {id}.");
            }

            _rolBusiness.Eliminar(id);

            return NoContent();
        }
    }
}
