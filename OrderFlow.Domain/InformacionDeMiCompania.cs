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
