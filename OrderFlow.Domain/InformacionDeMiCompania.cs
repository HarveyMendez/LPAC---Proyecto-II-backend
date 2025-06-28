namespace OrderFlow.Domain
{
    public class InformacionDeMiCompania
    {
        private int setupId;
        private decimal impuestoVenta;
        private string nombre;
        private string direccion;
        private string ciudad;
        private string estadoOProvincia;
        private string codigoPostal;
        private string pais;
        private string telefono;
        private string numFax;
        private string terminosPago;
        private string mensaje;

        public InformacionDeMiCompania()
        {
            // Constructor vacío
        }

        public InformacionDeMiCompania(int setupId, decimal impuestoVenta, string nombre, string direccion, string ciudad, string estadoOProvincia, string codigoPostal, string pais, string telefono, string numFax, string terminosPago, string mensaje)
        {
            this.setupId = setupId;
            this.impuestoVenta = impuestoVenta;
            this.nombre = nombre;
            this.direccion = direccion;
            this.ciudad = ciudad;
            this.estadoOProvincia = estadoOProvincia;
            this.codigoPostal = codigoPostal;
            this.pais = pais;
            this.telefono = telefono;
            this.numFax = numFax;
            this.terminosPago = terminosPago;
            this.mensaje = mensaje;
        }

        public int SetupId { get => setupId; set => setupId = value; }
        public decimal ImpuestoVenta { get => impuestoVenta; set => impuestoVenta = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Direccion { get => direccion; set => direccion = value; }
        public string Ciudad { get => ciudad; set => ciudad = value; }
        public string EstadoOProvincia { get => estadoOProvincia; set => estadoOProvincia = value; }
        public string CodigoPostal { get => codigoPostal; set => codigoPostal = value; }
        public string Pais { get => pais; set => pais = value; }
        public string Telefono { get => telefono; set => telefono = value; }
        public string NumFax { get => numFax; set => numFax = value; }
        public string TerminosPago { get => terminosPago; set => terminosPago = value; }
        public string Mensaje { get => mensaje; set => mensaje = value; }
    }
}
