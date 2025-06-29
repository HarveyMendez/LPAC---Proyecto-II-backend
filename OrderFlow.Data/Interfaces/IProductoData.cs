using OrderFlow.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderFlow.Data.Interfaces
{
    public interface IProductoData
    {
        public void Crear(Producto producto);
        public void Modificar(Producto producto);
        public Producto VerProductoPorID(int id);
        public List<Producto> VerProductos();
        public void Eliminar(int id);

    }
}
