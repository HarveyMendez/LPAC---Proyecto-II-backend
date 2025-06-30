using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderFlow.Domain
{
    [Table("Producto")]
    public class Producto
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id_producto { get; set; }
        [Required]
        public string nombre_producto { get; set; } = string.Empty;
        [Required]
        public float precio { get; set; }
        [Required]
        public int cantidad_existencias { get; set; }
        [Required]
        public int punto_reorden { get; set; }
        [Required]
        public bool aplica_impuesto { get; set; }
        public string talla { get; set; } = string.Empty;
        [Required]
        public bool eliminado { get; set; } = false;


        // Virtual Links

        [MaxLength(4)]
        public string? cod_categoria { get; set; } 

        [ForeignKey("cod_categoria")]
        public virtual Categoria? Categoria { get; set; } 



    }
}
