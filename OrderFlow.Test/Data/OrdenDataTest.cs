using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OrderFlow.Data.Contexto;
using OrderFlow.Data.Repositorios;
using OrderFlow.Domain;
using Microsoft.EntityFrameworkCore;

namespace OrderFlow.Test.Data
{
    [TestFixture]
    internal class OrdenDataTest
    {
        private DbContextOptions<ContextoDbSQLServer> _dbContextOptions;
        private string _connectionString;

        [SetUp]
        public void Setup()
        {
            this._connectionString = "Data Source=163.178.173.130;Initial Catalog=LPAC_ProyectoII_DB;Persist Security Info=True;User ID=Lenguajes;Password=lenguajesparaiso2025;Encrypt=False";

            _dbContextOptions = new DbContextOptionsBuilder<ContextoDbSQLServer>()
                .UseSqlServer(this._connectionString)
                .Options;

            using (var context = new ContextoDbSQLServer(_dbContextOptions))
            {
                context.Database.EnsureCreated();
            }
        }

        [TearDown]
        public void Teardown()
        {
            using (var context = new ContextoDbSQLServer(_dbContextOptions))
            {
                // Eliminar la orden de prueba y sus detalles
                var orden = context.Ordenes
                    .Include(o => o.Detalles)
                    .FirstOrDefault(o => o.direccion_viaje == "Dirección Test Orden");

                if (orden != null)
                {
                    context.DetalleOrdenes.RemoveRange(orden.Detalles);
                    context.Ordenes.Remove(orden);
                    context.SaveChanges();
                }

                // Eliminar cliente de prueba
                var cliente = context.Clientes.FirstOrDefault(c => c.nombre_compania == "Compañía Test Orden");
                if (cliente != null)
                {
                    context.Clientes.Remove(cliente);
                    context.SaveChanges();
                }

                // Eliminar empleado de prueba
                var empleado = context.Empleados.FirstOrDefault(e => e.nombre_empleado == "EmpleadoTestOrden" && e.apellidos_empleado == "ApellidoTestOrden");
                if (empleado != null)
                {
                    context.Empleados.Remove(empleado);
                    context.SaveChanges();
                }

                // Eliminar producto y categoría de prueba
                var producto = context.Productos.FirstOrDefault(p => p.nombre_producto == "Producto Test Orden");
                if (producto != null)
                {
                    context.Productos.Remove(producto);
                    context.SaveChanges();
                }
                var categoria = context.Categorias.FirstOrDefault(c => c.cod_categoria == "TST");
                if (categoria != null)
                {
                    context.Categorias.Remove(categoria);
                    context.SaveChanges();
                }

                // Eliminar departamento y rol de prueba
                var departamento = context.Departamentos.FirstOrDefault(d => d.depto_cod == "TST");
                if (departamento != null)
                {
                    context.Departamentos.Remove(departamento);
                    context.SaveChanges();
                }
                var rol = context.Roles.FirstOrDefault(r => r.nombre_rol == "Rol Test Orden");
                if (rol != null)
                {
                    context.Roles.Remove(rol);
                    context.SaveChanges();
                }
            }
        }

        [Test]
        public void Crear_ValidOrden_InsertsSuccessfully()
        {
            // Arrange
            using var context = new ContextoDbSQLServer(_dbContextOptions);

            // Crear datos dependientes
            var categoria = new Categoria { cod_categoria = "TST", descripcion = "Categoría Test Orden" };
            if (context.Categorias.Find("TST") == null)
            {
                context.Categorias.Add(categoria);
                context.SaveChanges();
            }
            else
            {
                categoria = context.Categorias.Find("TST");
            }

            var producto = new Producto
            {
                nombre_producto = "Producto Test Orden",
                precio = 10.5f,
                cantidad_existencias = 100,
                talla = "Única",
                punto_reorden = 5,
                aplica_impuesto = true,
                cod_categoria = categoria.cod_categoria
            };
            if (!context.Productos.Any(p => p.nombre_producto == "Producto Test Orden"))
            {
                context.Productos.Add(producto);
                context.SaveChanges();
            }
            else
            {
                producto = context.Productos.First(p => p.nombre_producto == "Producto Test Orden");
            }

            var cliente = new Cliente
            {
                nombre_compania = "Compañía Test Orden",
                nombre_contacto = "Contacto Test Orden",
                puesto_contacto = "Gerente",
                direccion = "Dirección Cliente Test",
                ciudad = "San José",
                provincia = "San José",
                codigo_postal = "10101",
                pais = "Costa Rica",
                telefono = "2222-3333",
                num_fax = "2222-4444"            };
            if (!context.Clientes.Any(c => c.nombre_compania == "Compañía Test Orden"))
            {
                context.Clientes.Add(cliente);
                context.SaveChanges();
            }
            else
            {
                cliente = context.Clientes.First(c => c.nombre_compania == "Compañía Test Orden");
            }

            var departamento = new Departamento { depto_cod = "TST", nombre_departament = "Departamento Test Orden" };
            if (context.Departamentos.Find("TST") == null)
            {
                context.Departamentos.Add(departamento);
                context.SaveChanges();
            }
            else
            {
                departamento = context.Departamentos.Find("TST");
            }

            var rol = new Rol { nombre_rol = "Rol Test Orden" };
            if (!context.Roles.Any(r => r.nombre_rol == "Rol Test Orden"))
            {
                context.Roles.Add(rol);
                context.SaveChanges();
            }
            else
            {
                rol = context.Roles.First(r => r.nombre_rol == "Rol Test Orden");
            }

            var empleado = new Empleado
            {
                nombre_empleado = "EmpleadoTestOrden",
                apellidos_empleado = "ApellidoTestOrden",
                puesto = "Vendedor",
                extension = "1234",
                telefono_trabajo = "8888-7777",
                depto_cod = "TST",
                id_rol = rol.id_rol,
                nombre_usuario = "usuario.orden",
                contrasena_hash = "hashorden",
                email = "usuario.orden@example.com"
            };
            if (!context.Empleados.Any(e => e.nombre_empleado == "EmpleadoTestOrden" && e.apellidos_empleado == "ApellidoTestOrden"))
            {
                context.Empleados.Add(empleado);
                context.SaveChanges();
            }
            else
            {
                empleado = context.Empleados.First(e => e.nombre_empleado == "EmpleadoTestOrden" && e.apellidos_empleado == "ApellidoTestOrden");
            }

            var orden = new Orden
            {
                fecha_orden = DateTime.UtcNow,
                direccion_viaje = "Dirección Test Orden",
                ciudad_viaje = "San José",
                provincia_viaje = "San José",
                pais_viaje = "Costa Rica",
                telefono_viaje = "8888-9999",
                fecha_viaje = DateTime.UtcNow.AddDays(1),
                cliente_id = cliente.cliente_id,
                id_empleado = empleado.id_empleado,
                Detalles = new System.Collections.Generic.List<DetalleOrden>
                {
                    new DetalleOrden
                    {
                        id_producto = producto.id_producto,
                        cantidad = 2,
                        precio_unitario = 10.5,
                        impuesto_aplicado = 13
                    }
                }
            };

            var ordenData = new OrdenData(context);

            // Act
            Assert.DoesNotThrow(() => ordenData.Crear(orden), "Crear una orden no debería generar una excepción.");

            // Assert
            Assert.That(orden.id_orden, Is.GreaterThan(0), "El ID de la orden debe ser mayor que 0 después de la inserción.");

            var insertedOrden = context.Ordenes
                .Include(o => o.Detalles)
                .FirstOrDefault(o => o.direccion_viaje == "Dirección Test Orden");

            Assert.That(insertedOrden, Is.Not.Null, "La orden insertada debería existir en la base de datos.");
            Assert.That(insertedOrden.Detalles, Is.Not.Empty, "La orden debe tener detalles asociados.");
            Assert.That(insertedOrden.cliente_id, Is.EqualTo(cliente.cliente_id), "El cliente de la orden no coincide.");
            Assert.That(insertedOrden.id_empleado, Is.EqualTo(empleado.id_empleado), "El empleado de la orden no coincide.");
        }
    }
}