using OrderFlow.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderFlow.Data.Interfaces
{
    public interface IDepartamentoData
    {
        public void Crear(Departamento departamento);
        public void Modificar(Departamento departamento);
        public void Eliminar(string id_departamento);
        public Departamento ObtenerPorId(string id_departamento);
        public List<Departamento> ObtenerTodos();
    }
}
