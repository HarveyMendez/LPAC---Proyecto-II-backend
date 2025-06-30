using OrderFlow.API.DTO;
using OrderFlow.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderFlow.Business.DTO
{
    public class OrdenDTO
    {
        public int idOrden { get; set; }
        public DateTime fecha_orden { get; set; }
        public string direccion_viaje { get; set; } = string.Empty;
        public string cuidad_viaje { get; set; } = string.Empty;
        public string provincia_viaje { get; set; } = string.Empty;
        public string pais_viaje { get; set; } = string.Empty;
        public string telefono_viaje { get; set; } = string.Empty;
        public DateTime fecha_viaje { get; set; }
        public List<DetalleOrdenDTO> Detalles { get; set; } = new List<DetalleOrdenDTO>();
        public ClienteDTO Cliente { get; set; } = new ClienteDTO();
        public EmpleadoDTO Empleado { get; set; } = new EmpleadoDTO();

    }
}
