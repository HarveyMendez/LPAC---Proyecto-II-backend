using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OrderFlow.Business.DTO;
using OrderFlow.Business.Interfaces;

namespace OrderFlow.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(Roles = "Admin,Usuario")]
    public class OrdenController : Controller
    {
        private readonly IOrdenBusiness _ordenBusiness;

        public OrdenController(IOrdenBusiness ordenBusiness)
        {
            _ordenBusiness = ordenBusiness;
        }

        [HttpPost]
        public ActionResult<OrdenDTO> CrearOrden([FromBody] OrdenDTO ordenDTO)
        {
            if (ordenDTO == null)
            {
                return BadRequest("Orden no puede ser nula.");
            }
            try
            {
                var ordenCreada = _ordenBusiness.Crear(ordenDTO);

                return Ok(ordenCreada);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al crear del orden: {ex.Message}");
            }
        }

        [HttpGet]
        public ActionResult<List<OrdenDTO>> ObtenerOrdenes()
        {
            try
            {
                var ordenes = _ordenBusiness.ObtenerOrdenes();

                if (ordenes == null || !ordenes.Any())
                {
                    return NotFound("No se encontraron ordenes.");
                }

                return Ok(ordenes);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al obtener las ordenes: {ex.Message}");
            }

        }

        [HttpGet("{id}")]
        public ActionResult<OrdenDTO> ObtenerOrdenPorId(int id)
        {
            try
            {
                var orden = _ordenBusiness.ObtenerPorId(id);

                if (orden == null)
                {
                    return NotFound($"Orden con ID {id} no encontrada.");
                }

                return Ok(orden);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al obtener la orden: {ex.Message}");
            }
        }

        [HttpPost("generar-factura")]
        public async Task<IActionResult> GenerarFacturaPdf([FromBody] OrdenDTO ordenDTO)
        {
            if (ordenDTO == null)
            {
                return BadRequest("Orden no puede ser nula.");
            }

            try
            {
                byte[] pdfBytes = await _ordenBusiness.GenerarFacturaPdfAsync(ordenDTO);

                return File(pdfBytes, "application/pdf", $"Factura_{ordenDTO.idOrden}.pdf");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al generar el PDF: {ex.Message}");
                return StatusCode(404, $"Error al generar el PDF: {ex.Message}");
            }
        }
    }
}
