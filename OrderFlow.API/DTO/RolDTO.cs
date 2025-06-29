using Microsoft.AspNetCore.Identity;

namespace OrderFlow.API.DTO
{
    public class RolDTO
    {
        public int idRol { get; set; }

        public string nombreRol{ get; set; } = string.Empty;
    }
}
