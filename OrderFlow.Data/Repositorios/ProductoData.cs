using Microsoft.Extensions.Configuration;
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
    public class ProductoData : IProductoData
    {
        private readonly ContextoDbSQLServer _contexto;

        public ProductoData(ContextoDbSQLServer contexto)
        {
            _contexto = contexto;
        }

        public void Crear(Producto producto)
        {
            _contexto.Productos.Add(producto);

            _contexto.SaveChanges();
        }

        public void Modificar(Producto producto)
        {
            _contexto.Productos
        }

        public Producto VerProductoPorID(int id)
        {
            var producto = _contexto.Productos.FirstOrDefault(p => p.IdProducto == id);

            return producto;
        }

        public List<Producto> VerProductos()
        {
            var productos = _contexto.Productos.ToList();

            return productos;
        }

        public void Eliminar(int id)
        {
            var producto = VerProductoPorID(id);

            if (producto != null)
            {
                _contexto.Productos.Remove(producto);
                _contexto.SaveChanges();
            }
        }


    }
}
