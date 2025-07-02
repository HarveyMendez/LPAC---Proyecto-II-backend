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
        public DbSet<Orden> Ordenes { get; set; }
        public DbSet<Empleado> Empleados { get; set; }
        public DbSet<DetalleOrden> DetalleOrdenes { get; set; }
        public DbSet<Rol> Roles { get; set; }
        public DbSet<InformacionDeMiCompania> InformacionDeMiCompania { get; set; }
        public DbSet<Departamento> Departamentos { get; set; }

        //public DbSet<MetodoPago> MetodoPagos { get; set; }
        //public DbSet<Pagos> Pagos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DetalleOrden>()
                .HasKey(d => new { d.id_orden, d.id_producto });


            modelBuilder.Entity<DetalleOrden>()
                .HasOne(d => d.Producto)
                .WithMany()
                .HasForeignKey(d => d.id_producto)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Orden>()
                .HasMany(o => o.Detalles)
                .WithOne(d => d.Orden)
                .HasForeignKey(d => d.id_orden)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Cliente>()
                .HasMany(c => c.ordenes)
                .WithOne(o => o.Cliente)
                .HasForeignKey(o => o.cliente_id)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Empleado>()
                .HasOne(e => e.Departamento)
                .WithMany()
                .HasForeignKey(e => e.depto_cod)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Producto>()
                .HasOne(p => p.Categoria)
                .WithMany()
                .HasForeignKey(p => p.cod_categoria)
                .OnDelete(DeleteBehavior.SetNull);






        }

    }
}
