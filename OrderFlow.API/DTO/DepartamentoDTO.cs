using System.ComponentModel.DataAnnotations;

namespace OrderFlow.API.DTO
{
    public class DepartamentoDTO
    {
        public string codDepartamento { get; set; } = string.Empty;
        public string nombreDepartamento { get; set; } = string.Empty;
    }
}
