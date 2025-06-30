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
    public class CategoriaBusiness : ICategoriaBusiness
    {
        private readonly ICategoriaData _categoriaData;

        public CategoriaBusiness(ICategoriaData categoriaData)
        {
            _categoriaData = categoriaData;
        }

        public void Crear(CategoriaDTO categoriaDTO)
        {
            var categoria = new Categoria
            {
                cod_categoria = categoriaDTO.codCategoria,
                descripcion = categoriaDTO.descripcion
            };

            _categoriaData.Crear(categoria);
        }

        public void Eliminar(string id)
        {
            _categoriaData.Eliminar(id);
        }

        public void Modificar(CategoriaDTO categoria)
        {
            var categoriaExistente = _categoriaData.VerCategoriaPorID(categoria.codCategoria);

            categoriaExistente.descripcion = categoria.descripcion;

            _categoriaData.Modificar(categoriaExistente);
        }

        public CategoriaDTO VerCategoriaPorID(string id)
        {
            var categoria = _categoriaData.VerCategoriaPorID(id);

            return CategoriaMapper.ToDTO(categoria);
        }

        public List<CategoriaDTO> VerCategorias()
        {
            var categorias = _categoriaData.VerCategorias();

            return categorias.Select(c => CategoriaMapper.ToDTO(c)).ToList();
        }
    }
}
