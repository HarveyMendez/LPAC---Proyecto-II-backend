using OrderFlow.API.DTO;
using OrderFlow.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderFlow.Business.Mappers
{
    public static class ProductoMapper
    {
        public static ProductoDTO ToDTO(Producto producto)
        {
            if (producto == null)
            {
                return null;
            }
            return new ProductoDTO
            {
                idProducto = producto.id_producto,
                nombreProducto = producto.nombre_producto,
                aplicaImpuesto = producto.aplica_impuesto,
                cantidadExistencias = producto.cantidad_existencias,
                categoria = CategoriaMapper.ToDTO(producto.Categoria),
                eliminado = producto.eliminado,
                precio = producto.precio,
                puntoReorden = producto.punto_reorden,
                talla = producto.talla

            };
        }
    }
}
