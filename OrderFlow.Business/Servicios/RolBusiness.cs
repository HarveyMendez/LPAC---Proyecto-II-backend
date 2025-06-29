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

        public void Crear(Rol rol)
        {
            _rolData.Crear(rol);
        }

        public void Eliminar(int id)
        {
            _rolData.Eliminar(id);
        }

        public void Modificar(Rol rol)
        {
            _rolData.Modificar(rol);
        }

        public List<Rol> VerRoles()
        {
            return _rolData.ObtenerTodos();
        }

        public Rol VerRolPorID(int id)
        {
            return _rolData.ObtenerPorId(id);
        }
    }
}
