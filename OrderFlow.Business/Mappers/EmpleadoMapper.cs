using OrderFlow.API.DTO;
using OrderFlow.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderFlow.Business.Mappers
{
    public static class EmpleadoMapper
    {
        public static EmpleadoDTO ToDTO(Empleado empleado)
        {
            if (empleado == null)
            {
                return null;
            }
            return new EmpleadoDTO
            {
                idEmpleado = empleado.id_empleado,
                nombreEmpleado = empleado.nombre_empleado,
                apellidosEmpleado = empleado.apellidos_empleado,
                telefonoTrabajo = empleado.telefono_trabajo,
                departamento = DepartamentoMapper.ToDTO(empleado.Departamento),
                extension = empleado.extension,
                puesto = empleado.puesto,
                rol = RolMapper.ToDTO(empleado.Rol),

            };
        }
    }
}
