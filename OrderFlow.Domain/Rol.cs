using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderFlow.Domain
{
    [Table("Rol")]
    public class Rol
    {
        [Key]
        public int id_rol { get; set; }
        [Required]
        public string nombre_rol { get; set; } = string.Empty;

    }
}
