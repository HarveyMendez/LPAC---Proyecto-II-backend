using OrderFlow.Business.Interfaces;
using OrderFlow.Data.Interfaces;
using OrderFlow.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderFlow.Business.Servicios
{
    public class ProductoBusiness : IProductoBusiness
    {
        private readonly IProductoData _productoData;

        public ProductoBusiness(IProductoData productoData)
        {
            _productoData = productoData;
        }

        public void Crear(Producto producto)
        {
            this._productoData.Crear(producto);
        }

        public void Modificar(Producto producto)
        {
            this._productoData.Modificar(producto);
        }

        public Producto VerProductoPorID(int id)
        {
            return this._productoData.VerProductoPorID(id);
        }

        public List<Producto> VerProductos()
        {
            return this._productoData.VerProductos();
        }

        public void Eliminar(int id)
        {
            this._productoData.Eliminar(id);
        }
}
