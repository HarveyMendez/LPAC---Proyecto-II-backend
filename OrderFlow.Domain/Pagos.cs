namespace OrderFlow.Domain
{
    public class Pagos
    {
        public int IdPago { get; set; }
        public int IdOrden { get; set; }
        public double CantidadPago { get; set; }
        public DateTime FechaPago { get; set; }
        public string NumTarjetaCredito { get; set; }
        public string NomUsuarioTarjeta { get; set; }
        public int IdMetodoPago { get; set; }

        public Pagos() { }

        public Pagos(int idPago, int idOrden, double cantidadPago, DateTime fechaPago, string numTarjetaCredito,
            string nomUsuarioTarjeta, int idMetodoPago)
        {
            IdPago = idPago;
            IdOrden = idOrden;
            CantidadPago = cantidadPago;
            FechaPago = fechaPago;
            NumTarjetaCredito = numTarjetaCredito;
            NomUsuarioTarjeta = nomUsuarioTarjeta;
            IdMetodoPago = idMetodoPago;
        }
    }
}