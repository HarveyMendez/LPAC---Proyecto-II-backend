using Microsoft.AspNetCore.Mvc;
using OrderFlow.Business.DTO.Autenticacion;
using OrderFlow.Business.Interfaces;
using BCrypt.Net; 


namespace OrderFlow.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService) => _authService = authService;

        [HttpPost("login")]
        public async Task<ActionResult<RespuestaAutenticacionDTO>> Login(EmpleadoLoginDTO loginDto)
        {
            var respuesta = await _authService.LoginAsync(loginDto);
            return respuesta != null ? Ok(respuesta) : Unauthorized();
        }

        [HttpPost("refresh")]
        public async Task<ActionResult<TokenDTO>> Refresh([FromBody] string refreshToken)
        {
            var respuesta = await _authService.RefrescarTokenAsync(refreshToken);
            return respuesta != null ? Ok(respuesta) : Unauthorized();
        }

        [HttpPost]
        public string encriptarTexto(string texto)
        {
            string contrasenaHasheada = BCrypt.Net.BCrypt.HashPassword(texto);

            return contrasenaHasheada;
        }
    }
}
