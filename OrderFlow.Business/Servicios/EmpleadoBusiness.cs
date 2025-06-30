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
    public class EmpleadoBusiness : IEmpleadoBusiness
    {
        private readonly IEmpleadoData _empleadoData;

        public EmpleadoBusiness(IEmpleadoData empleadoData)
        {
            _empleadoData = empleadoData;
        }

        public void Crear(EmpleadoDTO empleadoDTO)
        {
            var empleado = new Empleado
            {
                nombre_empleado = empleadoDTO.nombreEmpleado,
                apellidos_empleado = empleadoDTO.apellidosEmpleado,
                puesto = empleadoDTO.puesto,
                extension = empleadoDTO.extension,
                telefono_trabajo = empleadoDTO.telefonoTrabajo,
                depto_cod = empleadoDTO.departamento?.codDepartamento,
                id_rol = empleadoDTO.rol.idRol
            };

            _empleadoData.Crear(empleado);
        }

        public void Eliminar(int id_empleado)
        {
            _empleadoData.Eliminar(id_empleado);
        }

        public void Modificar(EmpleadoDTO empleado)
        {
            var empleadoData = new Empleado
            {
                id_empleado = empleado.idEmpleado,
                nombre_empleado = empleado.nombreEmpleado,
                apellidos_empleado = empleado.apellidosEmpleado,
                puesto = empleado.puesto,
                extension = empleado.extension,
                telefono_trabajo = empleado.telefonoTrabajo,
                depto_cod = empleado.departamento?.codDepartamento,
                id_rol = empleado.rol.idRol
            };

            _empleadoData.Modificar(empleadoData);
        }

        public EmpleadoDTO ObtenerPorId(int id_empleado)
        {
            var empleado =  _empleadoData.ObtenerPorId(id_empleado);

            return EmpleadoMapper.ToDTO(empleado);

        }

        public List<EmpleadoDTO> ObtenerTodos()
        {
            var empleados = _empleadoData.ObtenerTodos();

            return empleados.Select(e => EmpleadoMapper.ToDTO(e)).ToList();
        }
    }
}
