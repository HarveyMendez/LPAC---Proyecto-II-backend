namespace OrderFlow.Domain
{
    public class MetodoPago
    {
        public int IdMetodoPago { get; set; }
        public string MedotoPago { get; set; }
        public bool TarjetaCredito { get; set; }

        public MetodoPago() { }

        public MetodoPago(int idMetodoPago, string medotoPago, bool tarjetaCredito)
        {
            IdMetodoPago = idMetodoPago;
            MedotoPago = medotoPago;
            TarjetaCredito = tarjetaCredito;
        }
    }
}