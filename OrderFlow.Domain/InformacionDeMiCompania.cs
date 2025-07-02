using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderFlow.Domain
{
    [Table("InformacionDeMiCompania")]
    public class InformacionDeMiCompania
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int setupid { get; set; }

        public float impuestoVenta { get; set; }

        public string nombre { get; set; } = string.Empty;

        public string direccion { get; set; } = string.Empty;

        public string ciudad { get; set; } = string.Empty;

        public string estado_o_provincia { get; set; } = string.Empty;

        public string codigo_postal { get; set; } = string.Empty;

        public string pais { get; set; } = string.Empty;

        public string telefono { get; set; } = string.Empty;

        public string num_fax { get; set; } = string.Empty;

        public string terminos_pago { get; set; } = string.Empty;

        public string mensaje { get; set; } = string.Empty;
    }
}
