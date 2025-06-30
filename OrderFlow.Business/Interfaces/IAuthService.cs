using OrderFlow.Business.DTO.Autenticacion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderFlow.Business.Interfaces
{
    public interface IAuthService
    {
        Task<RespuestaAutenticacionDTO> LoginAsync(EmpleadoLoginDTO loginDto);
        Task<TokenDTO> RefrescarTokenAsync(string refreshToken);
    }
}
