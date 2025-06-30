using System.ComponentModel.DataAnnotations;

namespace OrderFlow.API.DTO
{
    public class EmpleadoDTO
    {
        public int idEmpleado { get; set; }
        public string nombreEmpleado { get; set; } = string.Empty;
        public string apellidosEmpleado { get; set; } = string.Empty;
        public string puesto { get; set; } = string.Empty;
        public string extension { get; set; } = string.Empty;
        public string telefonoTrabajo { get; set; } = string.Empty;
        public DepartamentoDTO departamento { get; set; } = new DepartamentoDTO();
        public RolDTO rol { get; set; } = new RolDTO();

        // para la autenticacion
        public string? nombre_usuario { get; set; }
        public string? contrasena_hash { get; set; }
        public string? email { get; set; }
    }
}
