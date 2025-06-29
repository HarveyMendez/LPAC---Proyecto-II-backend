using OrderFlow.API.DTO;
using OrderFlow.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderFlow.Business.Interfaces
{
    public interface IRolBusiness
    {
        public void Crear(RolDTO rol);
        public void Modificar(RolDTO rol);
        public void Eliminar(int id);
        public RolDTO VerRolPorID(int id);
        public List<RolDTO> VerRoles();

    }
}
