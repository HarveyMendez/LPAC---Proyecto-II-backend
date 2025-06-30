using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderFlow.Domain
{
    [Table("Orden")]
    public class Orden
    {
        [Key]
        public int id_orden { get; set; }
        [Required]
        public DateTime fecha_orden { get; set; }
        [Required]
        public string direccion_viaje { get; set; }
        [Required]
        public string ciudad_viaje { get; set; }
        [Required]
        public string provincia_viaje { get; set; }
        [Required]
        public string pais_viaje { get; set; }
        [Required]
        public string telefono_viaje { get; set; }
        [Required]
        public DateTime fecha_viaje { get; set; }

        // Virtual links
        public virtual List<DetalleOrden> Detalles { get; set; } = new List<DetalleOrden>();
        public int cliente_id { get; set; }
        [ForeignKey("cliente_id")]
        public virtual Cliente? Cliente { get; set; }   
        public int id_empleado { get; set; }
        [ForeignKey("id_empleado")]
        public virtual Empleado? Empleado { get; set; }


    }
}
