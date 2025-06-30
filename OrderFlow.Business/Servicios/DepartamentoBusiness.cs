using OrderFlow.API.DTO;
using OrderFlow.Business.Interfaces;
using OrderFlow.Business.Mappers;
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

        public void Crear(DepartamentoDTO departamentoDTO)
        {
            var departamento = new Departamento
            {
                depto_cod = departamentoDTO.codDepartamento,
                nombre_departament = departamentoDTO.nombreDepartamento,
            };

            _departamentoData.Crear(departamento);
        }

        public void Eliminar(string id_departamento)
        {
            _departamentoData.Eliminar(id_departamento);
        }

        public void Modificar(DepartamentoDTO departamento)
        {
            var departamentoExistente = _departamentoData.ObtenerPorId(departamento.codDepartamento);

            departamentoExistente.nombre_departament = departamento.nombreDepartamento;

            _departamentoData.Modificar(departamentoExistente);
        }

        public DepartamentoDTO ObtenerPorId(string id_departamento)
        {
            var departamento =  _departamentoData.ObtenerPorId(id_departamento);

            return DepartamentoMapper.ToDTO(departamento);
        }

        public List<DepartamentoDTO> ObtenerTodos()
        {
            var departamentos = _departamentoData.ObtenerTodos();

            return departamentos.Select(d => DepartamentoMapper.ToDTO(d)).ToList();
        }
    }
}
