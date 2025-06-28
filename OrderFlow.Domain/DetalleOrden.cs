namespace OrderFlow.Domain
{
    public class DetalleOrden
    {
        public int IdOrden { get; set; }
        public int IdProducto { get; set; }
        public double Cantidad { get; set; }
        public double PrecioUnitario { get; set; }
        public int ImpuestoAplicado { get; set; }

        public DetalleOrden() { }

        public DetalleOrden(int idOrden, int idProducto, double cantidad, double precioUnitario, int impuestoAplicado)
        {
            IdOrden = idOrden;
            IdProducto = idProducto;
            Cantidad = cantidad;
            PrecioUnitario = precioUnitario;
            ImpuestoAplicado = impuestoAplicado;
        }
    }
}