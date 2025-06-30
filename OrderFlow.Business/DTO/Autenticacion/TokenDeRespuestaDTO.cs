using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderFlow.Business.DTO.Autenticacion
{
    public class TokenDeRespuestaDTO
    {
        public string TokenDeAcceso { get; set; }
        public string TokenDeRefresco { get; set; }
        public DateTime ExpiraEn { get; set; }
    }
}
