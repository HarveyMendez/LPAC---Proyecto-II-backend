using OrderFlow.Business.DTO.Autenticacion;
using OrderFlow.Business.Interfaces;
using OrderFlow.Data.Interfaces;
using System.Threading.Tasks;
using BCrypt.Net;

namespace OrderFlow.Business.Servicios.Autenticacion
{
    public class AuthService : IAuthService
    {
        private readonly IEmpleadoData _empleadoRepo;
        private readonly ITokenService _tokenService;

        public AuthService(IEmpleadoData empleadoRepo, ITokenService tokenService)
        {
            _empleadoRepo = empleadoRepo;
            _tokenService = tokenService;
        }

        public async Task<RespuestaAutenticacionDTO> LoginAsync(EmpleadoLoginDTO loginDto)
        {
            var empleado = await _empleadoRepo.ObtenerPorUsuarioAsync(loginDto.NombreUsuario);

            if (empleado == null || !BCrypt.Net.BCrypt.Verify(loginDto.Contrasena, empleado.contrasena_hash))
                return null; // O lanzar una excepción personalizada

            var token = await _tokenService.GenerarTokenAsync(empleado);
            var refreshToken = await _tokenService.GenerarRefreshTokenAsync(empleado);

            return new RespuestaAutenticacionDTO
            {
                Token = token,
                RefreshToken = refreshToken,
                Expiracion = DateTime.UtcNow.AddHours(1),
                NombreCompleto = $"{empleado.nombre_empleado} {empleado.apellidos_empleado}",
                Rol = empleado.Rol?.nombre_rol
            };
        }

        public async Task<TokenDTO> RefrescarTokenAsync(string refreshToken)
        {
            var empleadoId = await _tokenService.ValidarTokenAsync(refreshToken);
            var empleado = await _empleadoRepo.ObtenerPorIdAsync(empleadoId);

            if (empleado == null)
                return null; // O lanzar una excepción

            var newToken = await _tokenService.GenerarTokenAsync(empleado);
            var newRefreshToken = await _tokenService.GenerarRefreshTokenAsync(empleado);

            return new TokenDTO
            {
                Token = newToken,
                RefreshToken = newRefreshToken
            };
        }


    }
}
