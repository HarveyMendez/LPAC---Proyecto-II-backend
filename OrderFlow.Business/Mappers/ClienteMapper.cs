using OrderFlow.API.DTO;
using OrderFlow.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderFlow.Business.Mappers
{
    public static class ClienteMapper
    {
        public static ClienteDTO ToDTO(Cliente cliente)
        {
            if (cliente == null)
            {
                return null;
            }
            return new ClienteDTO
            {
                IdCliente = cliente.cliente_id,
                nombreCompania = cliente.nombre_compania,
                ciudad = cliente.ciudad,
                codigoPostal = cliente.codigo_postal,
                direccion = cliente.direccion,
                nombreContacto = cliente.nombre_contacto,
                telefono = cliente.telefono,
                numFax = cliente.num_fax,
                pais = cliente.pais,
                provincia = cliente.provincia,
                puestoContacto = cliente.puesto_contacto,
            };
        }
    }
}
