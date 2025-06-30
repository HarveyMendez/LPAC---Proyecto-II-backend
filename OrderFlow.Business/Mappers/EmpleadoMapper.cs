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
                nombre_usuario = empleado.nombre_usuario,
                contrasena_hash = empleado.contrasena_hash,
                email = empleado.email

            };
        }

        public static Empleado ToModel(EmpleadoDTO empleadoDTO)
        {
            return new Empleado
            {
                id_empleado = empleadoDTO.idEmpleado,
                nombre_empleado = empleadoDTO.nombreEmpleado,
                apellidos_empleado = empleadoDTO.apellidosEmpleado,
                telefono_trabajo = empleadoDTO.telefonoTrabajo,
                extension = empleadoDTO.extension,
                puesto = empleadoDTO.puesto,
                Departamento = DepartamentoMapper.ToModel(empleadoDTO.departamento),
                Rol = RolMapper.ToModel(empleadoDTO.rol),
                nombre_usuario = empleadoDTO.nombre_usuario,
                contrasena_hash = empleadoDTO.contrasena_hash,
                email = empleadoDTO.email
            };

        }
    }
}
