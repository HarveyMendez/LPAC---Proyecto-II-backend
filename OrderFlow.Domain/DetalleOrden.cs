using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderFlow.Domain
{
    [Table("DetalleOrden")]
    public class DetalleOrden
    {
        [Required]
        public int id_orden { get; set; }
        [Required]
        public int id_producto { get; set; }
        [Required]
        public double cantidad { get; set; }
        [Required]
        public double precio_unitario { get; set; }
        [Required]
        public int impuesto_aplicado { get; set; }

        // Virtual Links
        [ForeignKey("id_orden")]
        public virtual Orden? Orden { get; set; }

        [ForeignKey("id_producto")]
        public virtual Producto? Producto { get; set; }

    }
}
