namespace OrderFlow.Domain
{
    public class InformacionDeMiCompania
    {
        public int SetupId { get; set; }
        public double ImpuestoVenta { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public string Ciudad { get; set; }
        public string EstadoOProvincia { get; set; }
        public string CodigoPostal { get; set; }
        public string Pais { get; set; }
        public string Telefono { get; set; }
        public string NumFax { get; set; }
        public string TerminosPago { get; set; }
        public string Mensaje { get; set; }

        public InformacionDeMiCompania() { }

        public InformacionDeMiCompania(int setupId, double impuestoVenta, string nombre, string direccion, string ciudad,
            string estadoOProvincia, string codigoPostal, string pais, string telefono, string numFax, string terminosPago, string mensaje)
        {
            SetupId = setupId;
            ImpuestoVenta = impuestoVenta;
            Nombre = nombre;
            Direccion = direccion;
            Ciudad = ciudad;
            EstadoOProvincia = estadoOProvincia;
            CodigoPostal = codigoPostal;
            Pais = pais;
            Telefono = telefono;
            NumFax = numFax;
            TerminosPago = terminosPago;
            Mensaje = mensaje;
        }
    }
}