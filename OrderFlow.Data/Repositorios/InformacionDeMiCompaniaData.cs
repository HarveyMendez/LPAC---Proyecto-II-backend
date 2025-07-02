using Microsoft.EntityFrameworkCore;
using OrderFlow.Data.Contexto;
using OrderFlow.Data.Interfaces;
using OrderFlow.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderFlow.Data.Repositorios
{
    public class InformacionDeMiCompaniaData : IInformacionDeMiCompaniaData
    {
        private readonly ContextoDbSQLServer _contexto;

        public InformacionDeMiCompaniaData(ContextoDbSQLServer contexto)
        {
            _contexto = contexto;
        }

        public async Task<InformacionDeMiCompania> ObtenerInfoCompaniaMasRecienteAsync()
        {

            var inforCompaniaMasNueva = await _contexto.InformacionDeMiCompania
                .OrderByDescending(x => x.setupid)
                .FirstOrDefaultAsync();

            return inforCompaniaMasNueva;
        }
    }
}
