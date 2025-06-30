using OrderFlow.API.DTO;
using OrderFlow.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderFlow.Business.Mappers
{
    public static class DepartamentoMapper
    {
        public static DepartamentoDTO ToDTO(Departamento departamento)
        {
            if (departamento == null)
            {
                return null;
            }
            return new DepartamentoDTO
            {
                codDepartamento = departamento.depto_cod,
                nombreDepartamento = departamento.nombre_departament
            };
        }
    }
}
