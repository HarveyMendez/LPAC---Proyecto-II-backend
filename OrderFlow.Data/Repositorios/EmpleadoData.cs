using Microsoft.EntityFrameworkCore;
using OrderFlow.Data.Contexto;
using OrderFlow.Data.Interfaces;
using OrderFlow.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderFlow.Data.Repositorios
{
    public class EmpleadoData : IEmpleadoData
    {
        private readonly ContextoDbSQLServer _contexto;

        public EmpleadoData(ContextoDbSQLServer contexto)
        {
            _contexto = contexto;
        }

        public void Crear(Empleado empleado)
        {
            _contexto.Empleados.Add(empleado);

            _contexto.SaveChanges();
        }

        public void Eliminar(int id_empleado)
        {
            var empleado = ObtenerPorId(id_empleado);

            if(empleado != null)
            {
                _contexto.Empleados.Remove(empleado);

                _contexto.SaveChanges();
            }
        }

        public void Modificar(Empleado empleado)
        {
            _contexto.Empleados.Update(empleado);

            _contexto.SaveChanges();
        }

        public Empleado ObtenerPorId(int id_empleado)
        {
            var empleado = _contexto.Empleados
                .Include(e => e.Departamento)
                .Include(e => e.Rol)
                .FirstOrDefault(e => e.id_empleado == id_empleado);

            return empleado;
        }

        public List<Empleado> ObtenerTodos()
        {
            var empleados = _contexto.Empleados
                .Include(e => e.Departamento)
                .Include(e => e.Rol)
                .ToList();

            return empleados;
        }
    }
}
