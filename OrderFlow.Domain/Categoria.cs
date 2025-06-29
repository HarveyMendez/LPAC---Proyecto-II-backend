using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderFlow.Domain
{
    [Table("Categoria")]
    public class Categoria
    {
        [Key]
        public string cod_categoria { get; set; } = string.Empty;

        [Required]
        public string descripcion { get; set; } = string.Empty;

    }
}
