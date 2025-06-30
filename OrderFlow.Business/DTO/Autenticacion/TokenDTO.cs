using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderFlow.Business.DTO.Autenticacion
{
    public class TokenDTO
    {
        public string Token { get; set; }
        public string RefreshToken { get; set; }
    }
}
