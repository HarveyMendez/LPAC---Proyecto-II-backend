using OrderFlow.Business.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderFlow.Business.Interfaces
{
    public interface IInformacionDeMiCompaniaService
    {
        public Task<InformacionDeMiCompaniaDTO> ObtenerInfoCompaniaMasRecienteAsync();

    }
}
