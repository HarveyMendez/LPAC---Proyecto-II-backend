using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderFlow.Domain
{
    public class Orden
    {
        private int idOrden;
        private int clienteId;
        private int idEmpleado;
        private DateTime fechaOrden;
        private string direccionViaje;
        private string ciudadViaje;
        private string provinciaViaje;
        private string paisViaje;
        private string telefonoViaje;
        private DateTime fechaViaje;

        public Orden()
        {
            // Constructor vacío
        }

        public Orden(int idOrden, int clienteId, int idEmpleado, DateTime fechaOrden, string direccionViaje, string ciudadViaje, string provinciaViaje, string paisViaje, string telefonoViaje, DateTime fechaViaje)
        {
            this.idOrden = idOrden;
            this.clienteId = clienteId;
            this.idEmpleado = idEmpleado;
            this.fechaOrden = fechaOrden;
            this.direccionViaje = direccionViaje;
            this.ciudadViaje = ciudadViaje;
            this.provinciaViaje = provinciaViaje;
            this.paisViaje = paisViaje;
            this.telefonoViaje = telefonoViaje;
            this.fechaViaje = fechaViaje;
        }

        public int IdOrden { get => idOrden; set => idOrden = value; }
        public int ClienteId { get => clienteId; set => clienteId = value; }
        public int IdEmpleado { get => idEmpleado; set => idEmpleado = value; }
        public DateTime FechaOrden { get => fechaOrden; set => fechaOrden = value; }
        public string DireccionViaje { get => direccionViaje; set => direccionViaje = value; }
        public string CiudadViaje { get => ciudadViaje; set => ciudadViaje = value; }
        public string ProvinciaViaje { get => provinciaViaje; set => provinciaViaje = value; }
        public string PaisViaje { get => paisViaje; set => paisViaje = value; }
        public string TelefonoViaje { get => telefonoViaje; set => telefonoViaje = value; }
        public DateTime FechaViaje { get => fechaViaje; set => fechaViaje = value; }
    }
}
