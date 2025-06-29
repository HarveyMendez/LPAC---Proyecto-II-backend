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
        public void Crear(Rol rol);
        public void Modificar(Rol rol);
        public void Eliminar(int id);
        public Rol VerRolPorID(int id);
        public List<Rol> VerRoles();

    }
}
