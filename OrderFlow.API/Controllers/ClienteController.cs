using Microsoft.AspNetCore.Mvc;
using OrderFlow.API.DTO;
using OrderFlow.Data.Interfaces;
using OrderFlow.Domain;

namespace OrderFlow.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClienteController : Controller
    {
        private readonly IClienteData _clienteData;

        public ClienteController(IClienteData clienteData)
        {
            _clienteData = clienteData;
        }

        [HttpGet]
        public List<ClienteDTO> VerClientes()
        {
            var clientes = _clienteData.ObtenerTodos();

            if (clientes == null || !clientes.Any())
            {
                return new List<ClienteDTO>();
            }

            return clientes.Select(c => new ClienteDTO
            {
                IdCliente = c.cliente_id,
                nombreCompania = c.nombre_compania,
                nombreContacto = c.nombre_contacto,
                puestoContacto = c.puesto_contacto,
                direccion = c.direccion,
                ciudad = c.ciudad,
                provincia = c.provincia,
                codigoPostal = c.codigo_postal,
                pais = c.pais,
                telefono = c.telefono,
                numFax = c.num_fax,
                eliminado = c.eliminado
            }).ToList();
        }

        [HttpGet("{id}")]
        public ActionResult<ClienteDTO> VerClientePorID(int id)
        {
            var cliente = _clienteData.ObtenerPorId(id);
            if (cliente == null)
            {
                return NotFound();
            }
            return new ClienteDTO
            {
                IdCliente = cliente.cliente_id,
                nombreCompania = cliente.nombre_compania,
                nombreContacto = cliente.nombre_contacto,
                puestoContacto = cliente.puesto_contacto,
                direccion = cliente.direccion,
                ciudad = cliente.ciudad,
                provincia = cliente.provincia,
                codigoPostal = cliente.codigo_postal,
                pais = cliente.pais,
                telefono = cliente.telefono,
                numFax = cliente.num_fax,
                eliminado = cliente.eliminado
            };
        }

        [HttpPost]
        public IActionResult CrearCliente([FromBody] ClienteDTO clienteDto)
        {
            if (clienteDto == null || string.IsNullOrEmpty(clienteDto.nombreCompania) || string.IsNullOrEmpty(clienteDto.nombreContacto))
            {
                return BadRequest("Datos de cliente inválidos.");
            }
            var cliente = new Cliente
            {
                nombre_compania = clienteDto.nombreCompania,
                nombre_contacto = clienteDto.nombreContacto,
                puesto_contacto = clienteDto.puestoContacto,
                direccion = clienteDto.direccion,
                ciudad = clienteDto.ciudad,
                provincia = clienteDto.provincia,
                codigo_postal = clienteDto.codigoPostal,
                pais = clienteDto.pais,
                telefono = clienteDto.telefono,
                num_fax = clienteDto.numFax,
                eliminado = clienteDto.eliminado
            };
            _clienteData.Crear(cliente);
            return CreatedAtAction(nameof(VerClientePorID), new { id = cliente.cliente_id }, cliente);
        }

        [HttpPut("{id}")]
        public IActionResult ModificarCliente(int id, [FromBody] ClienteDTO clienteDto)
        {
            if (clienteDto == null || id != clienteDto.IdCliente || string.IsNullOrEmpty(clienteDto.nombreCompania) || string.IsNullOrEmpty(clienteDto.nombreContacto))
            {
                return BadRequest("Datos de cliente inválidos.");
            }
            var clienteExistente = _clienteData.ObtenerPorId(id);

            if (clienteExistente == null)
            {
                return NotFound();
            }
            
            clienteExistente.telefono = clienteDto.telefono;
            clienteExistente.num_fax = clienteDto.numFax;
            clienteExistente.nombre_compania = clienteDto.nombreCompania;
            clienteExistente.nombre_contacto = clienteDto.nombreContacto;
            clienteExistente.puesto_contacto = clienteDto.puestoContacto;
            clienteExistente.direccion = clienteDto.direccion;
            clienteExistente.ciudad = clienteDto.ciudad;
            clienteExistente.provincia = clienteDto.provincia;
            clienteExistente.codigo_postal = clienteDto.codigoPostal;
            clienteExistente.pais = clienteDto.pais;
            clienteExistente.eliminado = clienteDto.eliminado;

            _clienteData.Modificar(clienteExistente);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult EliminarCliente(int id)
        {
            var clienteExistente = _clienteData.ObtenerPorId(id);
            if (clienteExistente == null)
            {
                return NotFound();
            }
            _clienteData.Eliminar(id);
            return NoContent();
        }
    }
}
