using OrderFlow.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderFlow.Data.Interfaces
{
    public interface IClienteData
    {
        public void Crear(Cliente cliente);
        public void Modificar(Cliente cliente);
        public void Eliminar(int id_cliente);
        public Cliente ObtenerPorId(int id_cliente);
        public List<Cliente> ObtenerTodos();



    }
}
