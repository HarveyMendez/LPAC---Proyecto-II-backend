using OrderFlow.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderFlow.Data.Interfaces
{
    public interface IEmpleadoData
    {
        public void Crear(Empleado empleado);
        public void Modificar(Empleado empleado);
        public void Eliminar(int id_empleado);
        public Empleado ObtenerPorId(int id_empleado);
        public List<Empleado> ObtenerTodos();

        // para autenticacion

        Task<Empleado> ObtenerPorUsuarioAsync(string nombreUsuario);
        Task<Empleado> ObtenerPorIdAsync(int id);

    }
}
