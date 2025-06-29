using OrderFlow.API.DTO;
using OrderFlow.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderFlow.Business.Interfaces
{
    public interface ICategoriaBusiness
    {
        public void Crear(CategoriaDTO categoria);
        public void Modificar(CategoriaDTO categoria);
        public CategoriaDTO VerCategoriaPorID(string id);
        public List<CategoriaDTO> VerCategorias();
        public void Eliminar(string id);
    }
}
