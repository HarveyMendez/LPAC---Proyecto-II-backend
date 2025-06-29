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
    public class CategoriaData : ICategoriaData
    {
        private readonly ContextoDbSQLServer _contexto;

        public CategoriaData(ContextoDbSQLServer contexto)
        {
            _contexto = contexto;
        }

        public void Crear(Categoria categoria)
        {
            _contexto.Categorias.Add(categoria);

            _contexto.SaveChanges();
        }

        public void Eliminar(string id)
        {
            var categoria = VerCategoriaPorID(id);

            if (categoria != null)
            {
                _contexto.Categorias.Remove(categoria);
                _contexto.SaveChanges();
            }
        }

        public void Modificar(Categoria categoria)
        {
            _contexto.Categorias.Update(categoria);

            _contexto.SaveChanges();
        }

        public Categoria VerCategoriaPorID(string id)
        {
            var categoria = _contexto.Categorias
                .FirstOrDefault(c => c.cod_categoria == id);

            return categoria;
        }

        public List<Categoria> VerCategorias()
        {
            var categorias = _contexto.Categorias
                .ToList();

            return categorias;
        }
    }
}
