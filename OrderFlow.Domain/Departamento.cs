using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderFlow.Domain
{
    [Table("Departamento")]
    public class Departamento
    {
        [Key]
        public string depto_cod { get; set; } = string.Empty;
        [Required]
        public string nombre_departament { get; set; } = string.Empty;
    }
}
