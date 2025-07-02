using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OrderFlow.API.DTO;
using OrderFlow.Business.Interfaces;


namespace OrderFlow.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClienteController : Controller
    {
        private readonly IClienteBusiness _clienteBusiness;

        public ClienteController(IClienteBusiness clienteBusiness)
        {
            _clienteBusiness = clienteBusiness;
        }

        [Authorize(Roles = "Admin,Usuario")]
        [HttpGet]
        public ActionResult<List<ClienteDTO>> VerClientes()
        {
            var clientes = _clienteBusiness.ObtenerTodos();

            if (clientes == null || !clientes.Any())
            {
                return NotFound();
            }

            return Ok(clientes);
            
        }

        [Authorize(Roles = "Admin,Usuario")]
        [HttpGet("{id}")]
        public ActionResult<ClienteDTO> VerClientePorID(int id)
        {
            var cliente = _clienteBusiness.ObtenerPorId(id);

            if (cliente == null)
            {
                return NotFound();
            }

            return Ok(cliente);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult CrearCliente([FromBody] ClienteDTO clienteDto)
        {
            if (clienteDto == null || string.IsNullOrEmpty(clienteDto.nombreCompania) || string.IsNullOrEmpty(clienteDto.nombreContacto))
            {
                return BadRequest("Datos de cliente inválidos.");
            }

            try
            {
                _clienteBusiness.Crear(clienteDto);

                return Ok(clienteDto);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error al crear cliente: {ex.Message}");
            }
        }

        [Authorize(Roles = "Admin")]
        [HttpPut("{id}")]
        public IActionResult ModificarCliente(int id, [FromBody] ClienteDTO clienteDto)
        {
            if (clienteDto == null || id != clienteDto.IdCliente || string.IsNullOrEmpty(clienteDto.nombreCompania) || string.IsNullOrEmpty(clienteDto.nombreContacto))
            {
                return BadRequest("Datos de cliente inválidos.");
            }
            var clienteExistente = _clienteBusiness.ObtenerPorId(id);

            if (clienteExistente == null)
            {
                return NotFound();
            }

            try
            {
                _clienteBusiness.Modificar(clienteDto);

                return Ok(clienteDto);

            }
            catch (Exception ex)
            {
                return BadRequest($"Error al modificar cliente: {ex.Message}");
            }
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public IActionResult EliminarCliente(int id)
        {
            var clienteExistente = _clienteBusiness.ObtenerPorId(id);

            if (clienteExistente == null)
            {
                return NotFound();
            }

            try
            {
                _clienteBusiness.Eliminar(id);

                return Ok($"Cliente con ID: {id} eliminado correctamente");

            } catch(Exception ex)
            {
                return BadRequest($"Error al eliminar cliente: {ex.Message}");
            }
        }
    }
}
