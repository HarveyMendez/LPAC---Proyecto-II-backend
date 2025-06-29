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
    public class CategoriaBusiness : ICategoriaBusiness
    {
        private readonly ICategoriaData _categoriaData;

        public CategoriaBusiness(ICategoriaData categoriaData)
        {
            _categoriaData = categoriaData;
        }

        public void Crear(Categoria categoria)
        {
            _categoriaData.Crear(categoria);
        }

        public void Eliminar(string id)
        {
            _categoriaData.Eliminar(id);
        }

        public void Modificar(Categoria categoria)
        {
            _categoriaData.Modificar(categoria);
        }

        public Categoria VerCategoriaPorID(string id)
        {
            return  _categoriaData.VerCategoriaPorID(id);
        }

        public List<Categoria> VerCategorias()
        {
            return _categoriaData.VerCategorias();
        }
    }
}
