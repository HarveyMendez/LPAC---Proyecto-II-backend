using OrderFlow.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OrderFlow.API.DTO;

namespace OrderFlow.Business.DTO
{
    public class DetalleOrdenDTO
    {
        public int idOrden { get; set; }
        public float cantidad { get; set; }
        public float precioUnitario { get; set; }
        public int impuestoAplicado { get; set; }
        public ProductoDTO Producto { get; set; } = new ProductoDTO();
    }
}
