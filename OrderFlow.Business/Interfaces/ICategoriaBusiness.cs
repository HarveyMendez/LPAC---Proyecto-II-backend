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
        public void Crear(Categoria categoria);
        public void Modificar(Categoria categoria);
        public Categoria VerCategoriaPorID(string id);
        public List<Categoria> VerCategorias();
        public void Eliminar(string id);
    }
}
