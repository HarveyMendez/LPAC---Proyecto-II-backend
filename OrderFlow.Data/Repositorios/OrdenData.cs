using Microsoft.EntityFrameworkCore;
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
    public class OrdenData : IOrdenData
    {
        private readonly ContextoDbSQLServer _contexto;

        public OrdenData(ContextoDbSQLServer contexto)
        {
            _contexto = contexto;
        }

        public Orden Crear(Orden orden)
        {
            _contexto.Ordenes.Add(orden);

            _contexto.SaveChanges();

            return orden;
        }

        public List<Orden> ObtenerOrdenes()
        {
            var ordenes = _contexto.Ordenes
                .Include(o => o.Cliente)
                .Include(o => o.Empleado)
                .Include(o => o.Detalles)
                    .ThenInclude(d => d.Producto)
                        .ThenInclude(p => p.Categoria)
                .ToList();

            return ordenes;
        }

        public Orden ObtenerPorId(int id)
        {
            var orden = _contexto.Ordenes
                .Include(o => o.Cliente)
                .Include(o => o.Empleado)
                .Include(o => o.Detalles)
                    .ThenInclude(d => d.Producto)
                        .ThenInclude(p => p.Categoria)
            .FirstOrDefault(o => o.id_orden == id);

            return orden;
        }
    }
}
