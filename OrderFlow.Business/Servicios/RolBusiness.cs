using OrderFlow.API.DTO;
using OrderFlow.Business.Interfaces;
using OrderFlow.Business.Mappers;
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
            // el mapper hace un new, por lo tanto entity lo considerara como objeto nuevo
            var rol = RolMapper.ToModel(rolDTO); 

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

            return roles.Select(r => RolMapper.ToDTO(r)).ToList();
        }

        public RolDTO VerRolPorID(int id)
        {
            var rol = _rolData.ObtenerPorId(id);

            return RolMapper.ToDTO(rol);
        }
    }
}
