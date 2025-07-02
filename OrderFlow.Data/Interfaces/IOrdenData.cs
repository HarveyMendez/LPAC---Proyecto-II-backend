using OrderFlow.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderFlow.Data.Interfaces
{
    public interface IOrdenData
    {
        public Orden Crear(Orden orden);
        
        public Orden ObtenerPorId(int id);

        public List<Orden> ObtenerOrdenes(); 

    }
}
