using OrderFlow.API.DTO;
using OrderFlow.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderFlow.Business.Interfaces
{
    public interface IEmpleadoBusiness
    {
        public void Crear(EmpleadoDTO empleado);
        public void Modificar(EmpleadoDTO empleado);
        public void Eliminar(int id_empleado);
        public EmpleadoDTO ObtenerPorId(int id_empleado);
        public List<EmpleadoDTO> ObtenerTodos();
    }
}
