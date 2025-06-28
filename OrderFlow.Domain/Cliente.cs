namespace OrderFlow.Domain
{
    public class Cliente
    {
        public int ClienteId { get; set; }
        public string NombreCompania { get; set; }
        public string NombreContacto { get; set; }
        public string ApellidoContacto { get; set; }
        public string PuestoContacto { get; set; }
        public string Direccion { get; set; }
        public string Ciudad { get; set; }
        public string Provincia { get; set; }
        public string CodigoPostal { get; set; }
        public string Pais { get; set; }
        public string Telefono { get; set; }
        public string NumFax { get; set; }
        public bool Eliminado { get; set; }

        public Cliente() { }

        public Cliente(int clienteId, string nombreCompania, string nombreContacto, string apellidoContacto,  string puestoContacto,
            string direccion, string ciudad, string provincia, string codigoPostal, string pais, string telefono, string numFax, bool eliminado)
        {
            ClienteId = clienteId;
            NombreCompania = nombreCompania;
            NombreContacto = nombreContacto;
            ApellidoContacto = apellidoContacto;
            PuestoContacto = puestoContacto;
            Direccion = direccion;
            Ciudad = ciudad;
            Provincia = provincia;
            CodigoPostal = codigoPostal;
            Pais = pais;
            Telefono = telefono;
            NumFax = numFax;
            Eliminado = eliminado;
        }
    }
}