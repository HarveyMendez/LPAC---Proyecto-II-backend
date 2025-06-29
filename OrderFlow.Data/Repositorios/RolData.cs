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
    public class RolData : IRolData
    {
        private readonly ContextoDbSQLServer _contexto;

        public RolData(ContextoDbSQLServer contexto)
        {
            _contexto = contexto;
        }

        public void Crear(Rol rol)
        {
            _contexto.Roles.Add(rol);

            _contexto.SaveChanges();
        }

        public void Eliminar(int id_rol)
        {
            var rol = ObtenerPorId(id_rol);

            if (rol != null)
            {
                _contexto.Roles.Remove(rol);
                _contexto.SaveChanges();
            }
        }

        public void Modificar(Rol rol)
        {
            _contexto.Roles.Update(rol);

            _contexto.SaveChanges();
        }

        public Rol ObtenerPorId(int id_rol)
        {
            var rol = _contexto.Roles
                .FirstOrDefault(r => r.id_rol == id_rol);

            return rol;

        }

        public List<Rol> ObtenerTodos()
        {
            var roles = _contexto.Roles
                .ToList();

            return roles;
        }
    }
}
