using OrderFlow.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderFlow.Data.Interfaces
{
    public interface IInformacionDeMiCompaniaData
    {
        public Task<InformacionDeMiCompania> ObtenerInfoCompaniaMasRecienteAsync();

    }
}
