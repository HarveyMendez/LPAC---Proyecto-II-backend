using Microsoft.EntityFrameworkCore;
using OrderFlow.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderFlow.Data.Contexto
{
    public class ContextoDbSQLServer : DbContext
    {
        public ContextoDbSQLServer(DbContextOptions<ContextoDbSQLServer> options) : base(options)
        {
        }

        public DbSet<Producto> Productos { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        //public DbSet<Orden> Ordenes { get; set; }
        public DbSet<Empleado> Empleados { get; set; }
        //public DbSet<DetalleOrden> DetalleOrdenes { get; set; }
        public DbSet<Rol> Roles { get; set; }
        //public DbSet<InformacionDeMiCompania> InformacionDeMiCompania { get; set; }
        //public DbSet<Pagos> Pagos { get; set; }
        public DbSet<Departamento> Departamentos { get; set; }
        //public DbSet<MetodoPago> MetodoPagos { get; set; }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Categoria>().HasKey(c => c.cod_categoria);
        //}

    }
}
