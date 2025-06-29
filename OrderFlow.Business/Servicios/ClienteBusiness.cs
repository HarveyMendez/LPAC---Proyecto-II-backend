using OrderFlow.Business.Interfaces;
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

        public void Crear(Cliente cliente)
        {
            _clienteData.Crear(cliente);
        }

        public void Modificar(Cliente cliente)
        {
            _clienteData.Modificar(cliente);
        }

        public void Eliminar(int id_cliente)
        {
            _clienteData.Eliminar(id_cliente);
        }

        public Cliente ObtenerPorId(int id_cliente)
        {
            return _clienteData.ObtenerPorId(id_cliente);   
        }

        public List<Cliente> ObtenerTodos()
        {
            return _clienteData.ObtenerTodos();
        }

    }
}
