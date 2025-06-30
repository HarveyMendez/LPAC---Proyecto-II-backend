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
    public class ClienteBusiness : IClienteBusiness
    {
        private readonly IClienteData _clienteData;

        public ClienteBusiness(IClienteData clienteData)
        {
            _clienteData = clienteData;
        }

        public void Crear(ClienteDTO clienteDTO)
        {
            var cliente = new Cliente
            {
                provincia = clienteDTO.provincia,
                ciudad = clienteDTO.ciudad,
                direccion = clienteDTO.direccion,
                codigo_postal = clienteDTO.codigoPostal,
                eliminado = false,
                nombre_compania = clienteDTO.nombreCompania,
                nombre_contacto = clienteDTO.nombreContacto,
                telefono = clienteDTO.telefono,
                num_fax = clienteDTO.numFax,
                pais = clienteDTO.pais,
                puesto_contacto = clienteDTO.puestoContacto

            };
            _clienteData.Crear(cliente);
        }

        public void Modificar(ClienteDTO clienteDTO)
        {
            var cliente = _clienteData.ObtenerPorId(clienteDTO.IdCliente);

            cliente.provincia = clienteDTO.provincia;
            cliente.ciudad = clienteDTO.ciudad;
            cliente.direccion = clienteDTO.direccion;
            cliente.codigo_postal = clienteDTO.codigoPostal;
            cliente.eliminado = clienteDTO.eliminado;
            cliente.nombre_compania = clienteDTO.nombreCompania;
            cliente.nombre_contacto = clienteDTO.nombreContacto;
            cliente.telefono = clienteDTO.telefono;
            cliente.num_fax = clienteDTO.numFax;
            cliente.pais = clienteDTO.pais;
            cliente.puesto_contacto = clienteDTO.puestoContacto;

            _clienteData.Modificar(cliente);
        }

        public void Eliminar(int id_cliente)
        {
            _clienteData.Eliminar(id_cliente);
        }

        public ClienteDTO ObtenerPorId(int id_cliente)
        {
            var cliente = _clienteData.ObtenerPorId(id_cliente);   

            return ClienteMapper.ToDTO(cliente);
        }

        public List<ClienteDTO> ObtenerTodos()
        {
            var departamentos =  _clienteData.ObtenerTodos();

            return departamentos.Select(d => ClienteMapper.ToDTO(d)).ToList();
        }

    }
}
