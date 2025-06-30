using OrderFlow.Business.DTO.Autenticacion;
using OrderFlow.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderFlow.Business.Interfaces
{
    public interface IMapeador
    {
        RespuestaAutenticacionDTO MapToAuthResponse(Empleado empleado, (string tokenDeAcceso, string tokenDeRefresco, DateTime expiracion) tokens);
    }
}
