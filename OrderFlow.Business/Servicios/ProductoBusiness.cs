using OrderFlow.API.DTO;
using OrderFlow.Business.Interfaces;
using OrderFlow.Business.Mappers;
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

        public void Crear(ProductoDTO productoDTO)
        {
            var producto = new Producto
            {
                precio = productoDTO.precio,
                nombre_producto = productoDTO.nombreProducto,
                cantidad_existencias = productoDTO.cantidadExistencias,
                talla = productoDTO.talla,
                punto_reorden = productoDTO.puntoReorden,
                aplica_impuesto = productoDTO.aplicaImpuesto,
                eliminado = productoDTO.eliminado,
                cod_categoria = productoDTO.categoria.codCategoria,
            };

            this._productoData.Crear(producto);
        }

        public void Modificar(ProductoDTO producto)
        {
            var productoExistente = _productoData.VerProductoPorID(producto.idProducto);

            productoExistente.precio = producto.precio;
            productoExistente.nombre_producto = producto.nombreProducto;
            productoExistente.cantidad_existencias = producto.cantidadExistencias;
            productoExistente.talla = producto.talla;
            productoExistente.punto_reorden = producto.puntoReorden;
            productoExistente.aplica_impuesto = producto.aplicaImpuesto;
            productoExistente.eliminado = producto.eliminado;
            productoExistente.Categoria.cod_categoria = producto.categoria.codCategoria;
            productoExistente.Categoria.descripcion = producto.categoria.descripcion;

            this._productoData.Modificar(productoExistente);
        }

        public ProductoDTO VerProductoPorID(int id)
        {
            var producto = this._productoData.VerProductoPorID(id);

            return ProductoMapper.ToDTO(producto);
        }

        public List<ProductoDTO> VerProductos()
        {
            var productos =  this._productoData.VerProductos();

            return productos.Select(p => ProductoMapper.ToDTO(p)).ToList();
        }

        public void Eliminar(int id)
        {
            this._productoData.Eliminar(id);
        }
    }
}
