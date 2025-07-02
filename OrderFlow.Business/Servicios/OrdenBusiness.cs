using OrderFlow.Business.DTO;
using OrderFlow.Business.Interfaces;
using OrderFlow.Business.Mappers;
using OrderFlow.Data.Interfaces;
using OrderFlow.Data.Repositorios;
using OrderFlow.Domain;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace OrderFlow.Business.Servicios
{
    public class OrdenBusiness: IOrdenBusiness
    {
        private readonly IOrdenData _ordenData;
        private readonly IInformacionDeMiCompaniaService _infoCompaniaBusiness;
        private readonly IProductoData productData;

        public OrdenBusiness(IOrdenData ordenData, IInformacionDeMiCompaniaService infoCompaniaBusiness, IProductoData productoData)
        {
            this._ordenData = ordenData;
            _infoCompaniaBusiness = infoCompaniaBusiness;
            this.productData = productoData;
        }

        public OrdenDTO Crear(OrdenDTO ordenDTO)
        {
            // Primero validar que haya suficiente stock para todos los productos
            foreach (var detalle in ordenDTO.Detalles)
            {
                var producto = productData.VerProductoPorID(detalle.Producto.idProducto);
                if (producto == null)
                {
                    throw new InvalidOperationException($"Producto con ID {detalle.Producto.idProducto} no encontrado");
                }

                if (producto.cantidad_existencias < detalle.cantidad)
                {
                    throw new InvalidOperationException(
                        $"No hay suficiente stock para el producto {producto.nombre_producto}. " +
                        $"Stock disponible: {producto.cantidad_existencias}, solicitado: {detalle.cantidad}");
                }
            }

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

                // Actualizar el stock del producto
                var producto = productData.VerProductoPorID(detalleOrdenDTO.Producto.idProducto);
                producto.cantidad_existencias -= (int)detalleOrdenDTO.cantidad;
                productData.Modificar(producto);
            }

            var ordenCreada = _ordenData.Crear(orden);

            return new OrdenDTO
            {
                idOrden = ordenCreada.id_orden,
                cuidad_viaje = ordenCreada.ciudad_viaje,
                fecha_viaje = ordenCreada.fecha_viaje,
                direccion_viaje = ordenCreada.direccion_viaje,
                fecha_orden = ordenCreada.fecha_orden,
                pais_viaje = ordenCreada.pais_viaje,
                provincia_viaje = ordenCreada.provincia_viaje,
                telefono_viaje = ordenCreada.telefono_viaje,
                Cliente = ClienteMapper.ToDTO(ordenCreada.Cliente),
                Empleado = EmpleadoMapper.ToDTO(ordenCreada.Empleado),
                Detalles = ordenCreada.Detalles.Select(d => new DetalleOrdenDTO
                {
                    cantidad = (float)d.cantidad,
                    precioUnitario = (float)d.precio_unitario,
                    impuestoAplicado = d.impuesto_aplicado,
                    Producto = ProductoMapper.ToDTO(d.Producto)
                }).ToList()
            };
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

            if (ordenDTO == null)
            {
                return null;
            }

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

        public async Task<byte[]> GenerarFacturaPdfAsync(OrdenDTO ordenDTO)
        {
            // Obtener informacion de la compañía
            var infoCompania = await _infoCompaniaBusiness.ObtenerInfoCompaniaMasRecienteAsync();

            // Calcular totales
            decimal subtotal = (decimal)ordenDTO.Detalles.Sum(d => d.cantidad * d.precioUnitario);
            decimal impuestos = ordenDTO.Detalles.Sum(d =>
                d.impuestoAplicado > 0 ?
                (decimal)(d.cantidad * d.precioUnitario) * (decimal)d.impuestoAplicado / 100 : 0);
            decimal total = subtotal + impuestos;

            // Crear el documento PDF
            var document = QuestPDF.Fluent.Document.Create(container =>
            {
                container.Page(page =>
                {
                    page.Size(PageSizes.A4);
                    page.Margin(2, Unit.Centimetre);
                    page.PageColor(Colors.White);
                    page.DefaultTextStyle(x => x.FontSize(11));

                    page.Header()
                        .AlignCenter()
                        .Text($"FACTURA #{ordenDTO.idOrden}")
                        .SemiBold().FontSize(20).FontColor(Colors.Blue.Medium);

                    page.Content()
                        .PaddingVertical(1, Unit.Centimetre)
                        .Column(column =>
                        {
                            column.Spacing(20);

                            // Información de la compañía
                            column.Item().Row(row =>
                            {
                                row.RelativeItem().Column(col =>
                                {
                                    col.Item().Text(infoCompania.nombre).SemiBold();
                                    col.Item().Text(infoCompania.direccion);
                                    col.Item().Text($"{infoCompania.ciudad}, {infoCompania.estadoOProvincia}, {infoCompania.pais}");
                                    col.Item().Text($"Tel: {infoCompania.telefono} | Fax: {infoCompania.numFax}");
                                });

                                row.RelativeItem().Column(col =>
                                {
                                    col.Item().AlignRight().Text($"Fecha: {ordenDTO.fecha_orden:dd/MM/yyyy}");
                                    col.Item().AlignRight().Text($"Factura #: {ordenDTO.idOrden}");
                                    col.Item().AlignRight().Text($"Fecha Entrega: {ordenDTO.fecha_viaje:dd/MM/yyyy}");
                                });
                            });

                            // Separador
                            column.Item().LineHorizontal(1).LineColor(Colors.Grey.Lighten1);

                            // Información del cliente
                            column.Item().Row(row =>
                            {
                                row.RelativeItem().Column(col =>
                                {
                                    col.Item().Text("Cliente:").SemiBold();
                                    col.Item().Text(ordenDTO.Cliente.nombreCompania);
                                    col.Item().Text($"{ordenDTO.Cliente.telefono} {ordenDTO.Cliente.nombreContacto}");
                                    col.Item().Text(ordenDTO.Cliente.direccion);
                                    col.Item().Text($"{ordenDTO.Cliente.ciudad}, {ordenDTO.Cliente.provincia}");
                                });

                                row.RelativeItem().Column(col =>
                                {
                                    col.Item().Text("Dirección de Envío:").SemiBold();
                                    col.Item().Text(ordenDTO.direccion_viaje);
                                    col.Item().Text($"{ordenDTO.cuidad_viaje}, {ordenDTO.provincia_viaje}");
                                    col.Item().Text(ordenDTO.pais_viaje);
                                    col.Item().Text($"Tel: {ordenDTO.telefono_viaje}");
                                });
                            });

                            // Tabla de productos
                            column.Item().Table(table =>
                            {
                                table.ColumnsDefinition(columns =>
                                {
                                    columns.ConstantColumn(25); // Ícono
                                    columns.RelativeColumn(3);  // Producto
                                    columns.RelativeColumn();   // Cantidad
                                    columns.RelativeColumn();   // Precio
                                    columns.RelativeColumn();   // Impuesto
                                    columns.RelativeColumn();   // Total
                                });

                                // Encabezado
                                table.Header(header =>
                                {
                                    header.Cell().Text("#");
                                    header.Cell().Text("Producto").SemiBold();
                                    header.Cell().AlignRight().Text("Cantidad").SemiBold();
                                    header.Cell().AlignRight().Text("Precio Unit.").SemiBold();
                                    header.Cell().AlignRight().Text("Impuesto").SemiBold();
                                    header.Cell().AlignRight().Text("Total").SemiBold();

                                    header.Cell().ColumnSpan(6).PaddingTop(5).BorderBottom(1).BorderColor(Colors.Black);
                                });

                                // Contenido
                                int index = 1;
                                foreach (var detalle in ordenDTO.Detalles)
                                {
                                    decimal totalLinea = (decimal)(detalle.cantidad * detalle.precioUnitario);
                                    decimal impuestoLinea = detalle.impuestoAplicado > 0 ?
                                        totalLinea * (decimal)detalle.impuestoAplicado / 100 : 0;

                                    table.Cell().Element(CellStyle).Text(index.ToString());
                                    table.Cell().Element(CellStyle).Text(detalle.Producto.nombreProducto);
                                    table.Cell().Element(CellStyle).AlignRight().Text(detalle.cantidad.ToString("N2"));
                                    table.Cell().Element(CellStyle).AlignRight().Text(detalle.precioUnitario.ToString("C"));
                                    table.Cell().Element(CellStyle).AlignRight().Text($"{impuestoLinea:C}");
                                    table.Cell().Element(CellStyle).AlignRight().Text($"{totalLinea + impuestoLinea:C}");

                                    index++;
                                }

                                // Pie de tabla
                                table.Footer(footer =>
                                {
                                    footer.Cell().ColumnSpan(4).Text(string.Empty);
                                    footer.Cell().AlignRight().Text("Subtotal:").SemiBold();
                                    footer.Cell().AlignRight().Text($"{subtotal:C}");

                                    footer.Cell().ColumnSpan(4).Text(string.Empty);
                                    footer.Cell().AlignRight().Text("Impuestos:").SemiBold();
                                    footer.Cell().AlignRight().Text($"{impuestos:C}");

                                    footer.Cell().ColumnSpan(4).Text(string.Empty);
                                    footer.Cell().AlignRight().Text("Total:").SemiBold();
                                    footer.Cell().AlignRight().Text($"{total:C}");
                                });
                            });

                            // Términos y condiciones
                            column.Item().PaddingTop(20).Column(col =>
                            {
                                col.Item().Text("Términos y Condiciones").SemiBold();
                                col.Item().Text(infoCompania.terminosPago);
                                col.Item().PaddingTop(10).Text(infoCompania.mensaje);
                            });
                        });

                    page.Footer()
                        .AlignCenter()
                        .Text(x =>
                        {
                            x.Span("Página ");
                            x.CurrentPageNumber();
                        });
                });
            });

            // Generar PDF en memoria
            return document.GeneratePdf();
        }
        private static IContainer CellStyle(IContainer container)
        {
            return container
                .BorderBottom(1)
                .BorderColor(Colors.Grey.Lighten2)
                .PaddingVertical(5);
        }
    }
}
