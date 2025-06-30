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
            var empleado = EmpleadoMapper.ToModel(empleadoDTO);

            _empleadoData.Crear(empleado);
        }

        public void Eliminar(int id_empleado)
        {
            _empleadoData.Eliminar(id_empleado);
        }

        public void Modificar(EmpleadoDTO empleado)
        {
            var empleadoExistente = _empleadoData.ObtenerPorId(empleado.idEmpleado);

            empleadoExistente.nombre_empleado = empleado.nombreEmpleado;
            empleadoExistente.apellidos_empleado = empleado.apellidosEmpleado;
            empleadoExistente.puesto = empleado.puesto;
            empleadoExistente.extension = empleado.extension;
            empleadoExistente.telefono_trabajo = empleado.telefonoTrabajo;
            empleadoExistente.depto_cod = empleado.departamento.codDepartamento;
            empleadoExistente.id_rol = empleado.rol.idRol;
            empleadoExistente.nombre_usuario = empleado.nombre_usuario;
            empleadoExistente.contrasena_hash = empleado.contrasena_hash;
            empleadoExistente.email = empleado.email;


            _empleadoData.Modificar(empleadoExistente);
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
