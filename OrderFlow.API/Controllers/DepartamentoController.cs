using Microsoft.AspNetCore.Mvc;
using OrderFlow.Business.Interfaces;
using OrderFlow.API.DTO;
using OrderFlow.Domain;


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

        [HttpGet]
        public List<DepartamentoDTO> VerDepartamentos()
        {
            var departamentos = _departamentoBusiness.ObtenerTodos();

            if (departamentos == null || !departamentos.Any())
            {
                return new List<DepartamentoDTO>();
            }

            return departamentos.Select(d => new DepartamentoDTO
            {
                codDepartamento = d.depto_cod,
                nombreDepartamento = d.nombre_departament

            }).ToList();
        }

        [HttpGet("{id}")]
        public ActionResult<DepartamentoDTO> VerDepartamentoPorID(string id)
        {
            var departamento = _departamentoBusiness.ObtenerPorId(id);
            if (departamento == null)
            {
                return NotFound();
            }
            return new DepartamentoDTO
            {
                codDepartamento = departamento.depto_cod,
                nombreDepartamento = departamento.nombre_departament
            };
        }

        [HttpPost]
        public IActionResult CrearDepartamento([FromBody] DepartamentoDTO departamentoDto)
        {
            if (departamentoDto == null || string.IsNullOrEmpty(departamentoDto.codDepartamento) || string.IsNullOrEmpty(departamentoDto.nombreDepartamento))
            {
                return BadRequest("Datos de departamento inválidos.");
            }
            var departamento = new Departamento
            {
                depto_cod = departamentoDto.codDepartamento,
                nombre_departament = departamentoDto.nombreDepartamento
            };
            _departamentoBusiness.Crear(departamento);
            return CreatedAtAction(nameof(VerDepartamentoPorID), new { id = departamento.depto_cod }, departamentoDto);
        }

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

            departamento.nombre_departament = departamentoDto.nombreDepartamento;

            _departamentoBusiness.Modificar(departamento);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult EliminarDepartamento(string id)
        {
            var departamento = _departamentoBusiness.ObtenerPorId(id);
            if (departamento == null)
            {
                return NotFound();
            }
            _departamentoBusiness.Eliminar(id);
            return NoContent();
        }
    }
}
