using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderFlow.Business.DTO.Autenticacion
{
    public class RespuestaAutenticacionDTO
    {
        public string Token { get; set; }
        public string RefreshToken { get; set; }
        public DateTime Expiracion { get; set; }
        public string NombreCompleto { get; set; }
        public string Rol { get; set; }
    }
}
