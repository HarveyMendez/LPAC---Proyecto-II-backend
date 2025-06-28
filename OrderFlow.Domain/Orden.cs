namespace OrderFlow.Domain
{
    public class Orden
    {
        public int IdOrden { get; set; }
        public int ClienteId { get; set; }
        public int IdEmpleado { get; set; }
        public DateTime FechaOrden { get; set; }
        public string DireccionViaje { get; set; }
        public string CiudadViaje { get; set; }
        public string ProvinciaViaje { get; set; }
        public string PaisViaje { get; set; }
        public string TelefonoViaje { get; set; }
        public DateTime FechaViaje { get; set; }

        public Orden() { }

        public Orden(int idOrden, int clienteId, int idEmpleado, DateTime fechaOrden, string direccionViaje,
            string ciudadViaje, string provinciaViaje, string paisViaje, string telefonoViaje, DateTime fechaViaje)
        {
            IdOrden = idOrden;
            ClienteId = clienteId;
            IdEmpleado = idEmpleado;
            FechaOrden = fechaOrden;
            DireccionViaje = direccionViaje;
            CiudadViaje = ciudadViaje;
            ProvinciaViaje = provinciaViaje;
            PaisViaje = paisViaje;
            TelefonoViaje = telefonoViaje;
            FechaViaje = fechaViaje;
        }
    }
}