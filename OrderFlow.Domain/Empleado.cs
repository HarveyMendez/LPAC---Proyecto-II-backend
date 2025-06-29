using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderFlow.Domain
{
    [Table("Empleado")]
    public class Empleado
    {
        [Key]
        public int id_empleado { get; set; }
        [Required]
        public string nombre_empleado { get; set; } = string.Empty;
        [Required]
        public string apellidos_empleado { get; set; } = string.Empty;
        [Required]
        public string puesto { get; set; } = string.Empty;
        [Required]
        public string extension { get; set; } = string.Empty;
        [Required]
        public string telefono_trabajo { get; set; } = string.Empty;

        // Virtual Links
        [MaxLength(4)]
        public string? depto_cod { get; set; }

        [ForeignKey("depto_cod")]
        public virtual Departamento? Departamento { get; set; }

        [MaxLength(4)]
        public int id_rol { get; set; }

        [ForeignKey("id_rol")]
        public virtual Rol? Rol { get; set; }

    }
}
