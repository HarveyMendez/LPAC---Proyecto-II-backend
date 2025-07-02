using OrderFlow.Business.DTO;
using OrderFlow.Business.Interfaces;
using OrderFlow.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderFlow.Business.Servicios
{
    public class InformacionDeMiCompaniaService : IInformacionDeMiCompaniaService
    {

        private readonly IInformacionDeMiCompaniaData informacionDeMiCompaniaData;

        public InformacionDeMiCompaniaService(IInformacionDeMiCompaniaData informacionDeMiCompaniaData)
        {
            this.informacionDeMiCompaniaData = informacionDeMiCompaniaData;
        }

        public async Task<InformacionDeMiCompaniaDTO> ObtenerInfoCompaniaMasRecienteAsync()
        {
            var info =  await this.informacionDeMiCompaniaData.ObtenerInfoCompaniaMasRecienteAsync();

            if (info == null)
            {
                return null;
            }

            return new InformacionDeMiCompaniaDTO
            {
                telefono = info.telefono,
                terminosPago = info.terminos_pago,
                setupid = info.setupid,
                codigoPostal = info.codigo_postal,
                direccion = info.direccion,
                ciudad = info.ciudad,
                estadoOProvincia = info.estado_o_provincia,
                impuestoVenta = info.impuestoVenta,
                mensaje = info.mensaje,
                nombre = info.nombre,
                numFax = info.num_fax,
                pais = info.pais

            };
        }
    }
}
