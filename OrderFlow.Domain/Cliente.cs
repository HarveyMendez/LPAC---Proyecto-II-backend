using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderFlow.Domain
{
    [Table("Cliente")]  
    public class Cliente
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int cliente_id { get; set; }
        [Required]
        public string nombre_compania { get; set; } = string.Empty;
        [Required]
        public string nombre_contacto { get; set; } = string.Empty;
        [Required]
        public string puesto_contacto { get; set; } = string.Empty;
        [Required]
        public string direccion { get; set; } = string.Empty;
        [Required]
        public string ciudad { get; set; } = string.Empty;
        [Required]
        public string provincia { get; set; } = string.Empty;
        [Required]
        public string codigo_postal { get; set; } = string.Empty;
        [Required]
        public string pais { get; set; } = string.Empty;
        [Required]
        public string telefono { get; set; } = string.Empty;
        [Required]
        public string num_fax { get; set; } = string.Empty;
        [Required]
        public bool eliminado { get; set; } = false;
    }
}
