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

        [HttpGet]
        public ActionResult<InformacionDeMiCompaniaDTO> Get()
        {
            var informacion = _informacionDeMiCompaniaService.ObtenerInfoCompaniaMasRecienteAsync();

            if (informacion == null)
            {
                return NotFound();
            }

            return Ok(informacion);
        }   
    }
}
