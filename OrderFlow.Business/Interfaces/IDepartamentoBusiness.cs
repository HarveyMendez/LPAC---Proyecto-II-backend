using OrderFlow.API.DTO;
using OrderFlow.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderFlow.Business.Interfaces
{
    public interface IDepartamentoBusiness
    {
        public void Crear(DepartamentoDTO departamento);
        public void Modificar(DepartamentoDTO departamento);
        public void Eliminar(string id_departamento);
        public DepartamentoDTO ObtenerPorId(string id_departamento);
        public List<DepartamentoDTO> ObtenerTodos();
    }
}
