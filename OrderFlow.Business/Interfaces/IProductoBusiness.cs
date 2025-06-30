using OrderFlow.API.DTO;
using OrderFlow.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderFlow.Business.Interfaces
{
    public interface IProductoBusiness
    {
        public void Crear(ProductoDTO producto);
        public void Modificar(ProductoDTO producto);
        public ProductoDTO VerProductoPorID(int id);
        public List<ProductoDTO> VerProductos();
        public void Eliminar(int id);
    }
}
