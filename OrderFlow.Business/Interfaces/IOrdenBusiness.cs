using OrderFlow.Business.DTO;
using OrderFlow.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderFlow.Business.Interfaces
{
    public interface IOrdenBusiness
    {
        public OrdenDTO Crear(OrdenDTO orden);

        public OrdenDTO ObtenerPorId(int id);

        public List<OrdenDTO> ObtenerOrdenes();

        Task<byte[]> GenerarFacturaPdfAsync(OrdenDTO ordenDTO); // Nuevo método

    }
}
