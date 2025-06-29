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
    public class DepartamentoBusiness : IDepartamentoBusiness
    {
        private readonly IDepartamentoData _departamentoData;

        public DepartamentoBusiness(IDepartamentoData departamentoData)
        {
            _departamentoData = departamentoData;
        }

        public void Crear(Departamento departamento)
        {
            _departamentoData.Crear(departamento);
        }

        public void Eliminar(string id_departamento)
        {
            _departamentoData.Eliminar(id_departamento);
        }

        public void Modificar(Departamento departamento)
        {
            _departamentoData.Modificar(departamento);
        }

        public Departamento ObtenerPorId(string id_departamento)
        {
            return _departamentoData.ObtenerPorId(id_departamento);
        }

        public List<Departamento> ObtenerTodos()
        {
            return _departamentoData.ObtenerTodos();
        }
    }
}
