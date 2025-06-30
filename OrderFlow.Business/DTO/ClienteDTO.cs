using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace OrderFlow.API.DTO
{
    public class ClienteDTO
    {
        public int IdCliente { get; set; }
        public string nombreCompania { get; set; } = string.Empty;
        public string nombreContacto { get; set; } = string.Empty;
        public string puestoContacto { get; set; } = string.Empty;
        public string direccion { get; set; } = string.Empty;
        public string ciudad { get; set; } = string.Empty;
        public string provincia { get; set; } = string.Empty;
        public string codigoPostal { get; set; } = string.Empty;
        public string pais { get; set; } = string.Empty;
        public string telefono { get; set; } = string.Empty;
        public string numFax { get; set; } = string.Empty;
        public bool eliminado { get; set; } = false;
    }
}
