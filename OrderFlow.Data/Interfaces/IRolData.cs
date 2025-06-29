using OrderFlow.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderFlow.Data.Interfaces
{
    public interface IRolData
    {
        public void Crear(Rol rol);
        public void Modificar(Rol rol);
        public void Eliminar(int id_rol);
        public Rol ObtenerPorId(int id_rol);
        public List<Rol> ObtenerTodos();
    }
}
