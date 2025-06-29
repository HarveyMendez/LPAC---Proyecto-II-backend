using OrderFlow.API.DTO;
using OrderFlow.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderFlow.Business.Interfaces
{
    public interface IClienteBusiness
    {
        public void Crear(ClienteDTO cliente);
        public void Modificar(ClienteDTO cliente);
        public void Eliminar(int id_cliente);
        public ClienteDTO ObtenerPorId(int id_cliente);
        public List<ClienteDTO> ObtenerTodos();
    }
}
