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
    public class DepartamentoData : IDepartamentoData
    {
        private readonly ContextoDbSQLServer _contexto;

        public DepartamentoData(ContextoDbSQLServer contexto)
        {
            _contexto = contexto;
        }

        public void Crear(Departamento departamento)
        {
            _contexto.Departamentos.Add(departamento);

            _contexto.SaveChanges();
        }

        public void Eliminar(string id_departamento)
        {
            var departamento = this.ObtenerPorId(id_departamento);

            if(departamento != null)
            {
                _contexto.Departamentos.Remove(departamento);

                _contexto.SaveChanges();
            }
        }

        public void Modificar(Departamento departamento)
        {
            _contexto.Departamentos.Update(departamento);

            _contexto.SaveChanges();
        }

        public Departamento ObtenerPorId(string id_departamento)
        {
            var departamento = _contexto.Departamentos.FirstOrDefault(d => d.depto_cod == id_departamento);

            return departamento;
        }

        public List<Departamento> ObtenerTodos()
        {
            var departamentos = _contexto.Departamentos.ToList();

            return departamentos;
        }
    }
}
