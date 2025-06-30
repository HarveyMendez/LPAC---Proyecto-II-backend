using OrderFlow.API.DTO;
using OrderFlow.Business.DTO;
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
    public class OrdenBusiness: IOrdenBusiness
    {
        private readonly IOrdenData _ordenData;

        public OrdenBusiness(IOrdenData ordenData)
        {
            this._ordenData = ordenData;
        }

        public void Crear(OrdenDTO ordenDTO)
        {
            var orden = new Orden()
            {
                ciudad_viaje = ordenDTO.cuidad_viaje,
                fecha_viaje = ordenDTO.fecha_viaje,
                direccion_viaje = ordenDTO.direccion_viaje,
                fecha_orden = ordenDTO.fecha_orden,
                pais_viaje = ordenDTO.pais_viaje,
                provincia_viaje = ordenDTO.provincia_viaje,
                telefono_viaje = ordenDTO.telefono_viaje,
                cliente_id = ordenDTO.Cliente.IdCliente,
                id_empleado = ordenDTO.Empleado.idEmpleado,

            };

            foreach (DetalleOrdenDTO detalleOrdenDTO in ordenDTO.Detalles)
            {
                var detalleOrden = new DetalleOrden()
                {
                    cantidad = detalleOrdenDTO.cantidad,
                    precio_unitario = detalleOrdenDTO.precioUnitario,
                    impuesto_aplicado = detalleOrdenDTO.impuestoAplicado,
                    id_orden = ordenDTO.idOrden,
                    id_producto = detalleOrdenDTO.Producto.idProducto
                };

                orden.Detalles.Add(detalleOrden);
            }

            _ordenData.Crear(orden);

        }

        public List<OrdenDTO> ObtenerOrdenes()
        {
            var ordenes = _ordenData.ObtenerOrdenes();

            if(ordenes == null)
            {
                return null;
            }

            return ordenes.Select(o => new OrdenDTO
            {
                idOrden = o.id_orden,
                cuidad_viaje = o.ciudad_viaje,
                fecha_viaje = o.fecha_viaje,
                direccion_viaje = o.direccion_viaje,
                fecha_orden = o.fecha_orden,
                pais_viaje = o.pais_viaje,
                provincia_viaje = o.provincia_viaje,
                telefono_viaje = o.telefono_viaje,
                Cliente = ClienteMapper.ToDTO(o.Cliente),
                Empleado = EmpleadoMapper.ToDTO(o.Empleado),
                Detalles = o.Detalles.Select(d => new DetalleOrdenDTO
                {
                    cantidad = (float)d.cantidad,
                    precioUnitario = (float)d.precio_unitario,
                    impuestoAplicado = d.impuesto_aplicado,
                    Producto = ProductoMapper.ToDTO(d.Producto)

                }).ToList()
            }).ToList();
        }

        public OrdenDTO ObtenerPorId(int id)
        {
            var ordenDTO = _ordenData.ObtenerPorId(id);

            return new OrdenDTO
            {
                idOrden = ordenDTO.id_orden,
                cuidad_viaje = ordenDTO.ciudad_viaje,
                fecha_viaje = ordenDTO.fecha_viaje,
                direccion_viaje = ordenDTO.direccion_viaje,
                fecha_orden = ordenDTO.fecha_orden,
                pais_viaje = ordenDTO.pais_viaje,
                provincia_viaje = ordenDTO.provincia_viaje,
                telefono_viaje = ordenDTO.telefono_viaje,
                Cliente = ClienteMapper.ToDTO(ordenDTO.Cliente),
                Empleado = EmpleadoMapper.ToDTO(ordenDTO.Empleado),
                Detalles = ordenDTO.Detalles.Select(d => new DetalleOrdenDTO
                {
                    cantidad = (float)d.cantidad,
                    precioUnitario = (float)d.precio_unitario,
                    impuestoAplicado = d.impuesto_aplicado,
                    Producto = ProductoMapper.ToDTO(d.Producto)

                }).ToList()
            };
        }
    }
}
