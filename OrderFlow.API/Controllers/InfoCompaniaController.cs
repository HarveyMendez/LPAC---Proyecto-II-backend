using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OrderFlow.Business.DTO;
using OrderFlow.Business.Interfaces;

namespace OrderFlow.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InfoCompaniaController : Controller
    {
        private readonly IInformacionDeMiCompaniaService _informacionDeMiCompaniaService;

        public InfoCompaniaController(IInformacionDeMiCompaniaService informacionDeMiCompaniaService)
        {
            _informacionDeMiCompaniaService = informacionDeMiCompaniaService;
        }

        [Authorize(Roles = "Admin,Usuario")]
        [HttpGet]
        public async Task<ActionResult<InformacionDeMiCompaniaDTO>> Get()
        {
            var informacion = await _informacionDeMiCompaniaService.ObtenerInfoCompaniaMasRecienteAsync();

            if (informacion == null)
            {
                return NotFound();
            }

            return Ok(informacion);
        }   
    }
}
