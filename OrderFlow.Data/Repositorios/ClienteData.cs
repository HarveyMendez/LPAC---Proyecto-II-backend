using OrderFlow.Data.Contexto;
using OrderFlow.Data.Interfaces;
using OrderFlow.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderFlow.Data.Repositorios
{
    public class ClienteData : IClienteData
    {
        private readonly ContextoDbSQLServer _contexto;

        public ClienteData(ContextoDbSQLServer contexto)
        {
            _contexto = contexto;
        }

        public void Crear(Cliente cliente)
        {
            _contexto.Clientes.Add(cliente);

            _contexto.SaveChanges();
        }

        public void Eliminar(int id_cliente)
        {
            var cliente = _contexto.Clientes.Find(id_cliente);

            if(cliente != null)
            {
                _contexto.Clientes.Remove(cliente);

                _contexto.SaveChanges();
            }
        }

        public void Modificar(Cliente cliente)
        {
            _contexto.Clientes.Update(cliente);

            _contexto.SaveChanges();
        }

        public Cliente ObtenerPorId(int id_cliente)
        {
            var cliente = _contexto.Clientes.Find(id_cliente);

            return cliente;
        }

        public List<Cliente> ObtenerTodos()
        {
            var clientes = _contexto.Clientes.ToList();

            return clientes;
        }
    }
}
