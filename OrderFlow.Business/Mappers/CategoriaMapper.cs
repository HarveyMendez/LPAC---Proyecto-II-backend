using OrderFlow.API.DTO;
using OrderFlow.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderFlow.Business.Mappers
{
    public static class CategoriaMapper
    {
        public static CategoriaDTO ToDTO(Categoria categoria)
        {
            if (categoria == null)
            {
                return null;
            }
            return new CategoriaDTO
            {
                codCategoria = categoria.cod_categoria,
                descripcion = categoria.descripcion,
            };
        }
    }
}
