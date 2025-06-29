using OrderFlow.API.DTO;
using OrderFlow.Business.Interfaces;
using OrderFlow.Data.Interfaces;
using OrderFlow.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderFlow.Business.Servicios
{
    public class RolBusiness : IRolBusiness
    {
        private readonly IRolData _rolData;

        public RolBusiness(IRolData rolData)
        {
            _rolData = rolData;
        }

        public void Crear(RolDTO rolDTO)
        {
            var rol = new Rol
            {
                id_rol = rolDTO.idRol,
                nombre_rol = rolDTO.nombreRol,

            };

            _rolData.Crear(rol);
        }

        public void Eliminar(int id)
        {
            _rolData.Eliminar(id);
        }

        public void Modificar(RolDTO rolDTO)
        {
            var rol = _rolData.ObtenerPorId(rolDTO.idRol);

            rol.nombre_rol = rolDTO.nombreRol;

            _rolData.Modificar(rol);
        }

        public List<RolDTO> VerRoles()
        {
            var roles =  _rolData.ObtenerTodos();

            return roles.Select(r => new RolDTO
            {
                idRol = r.id_rol,
                nombreRol = r.nombre_rol
            }).ToList();
        }

        public RolDTO VerRolPorID(int id)
        {
            var rol = _rolData.ObtenerPorId(id);

            return new RolDTO
            {
                idRol = rol.id_rol,
                nombreRol = rol.nombre_rol
            };
        }
    }
}
