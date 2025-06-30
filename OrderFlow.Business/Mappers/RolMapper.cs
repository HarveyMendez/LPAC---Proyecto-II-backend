using OrderFlow.API.DTO;
using OrderFlow.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderFlow.Business.Mappers
{
    public static class RolMapper
    {
        public static RolDTO ToDTO(Rol rol)
        {
            if (rol == null)
            {
                return null;
            }
            return new RolDTO
            {
                idRol = rol.id_rol,
                nombreRol = rol.nombre_rol
            };
        }
    }
}
