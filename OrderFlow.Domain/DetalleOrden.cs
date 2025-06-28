using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderFlow.Domain
{
    public class DetalleOrden
    {
        private int idOrden;
        private int idProducto;
        private decimal cantidad;
        private decimal precioLinea;

        public DetalleOrden()
        {
            // Constructor vacío
        }

        public DetalleOrden(int idOrden, int idProducto, decimal cantidad, decimal precioLinea)
        {
            this.idOrden = idOrden;
            this.idProducto = idProducto;
            this.cantidad = cantidad;
            this.precioLinea = precioLinea;
        }

        public int IdOrden { get => idOrden; set => idOrden = value; }
        public int IdProducto { get => idProducto; set => idProducto = value; }
        public decimal Cantidad { get => cantidad; set => cantidad = value; }
        public decimal PrecioLinea { get => precioLinea; set => precioLinea = value; }
    }
}
