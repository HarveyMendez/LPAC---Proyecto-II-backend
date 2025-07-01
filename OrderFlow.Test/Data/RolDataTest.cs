using System;
using System.Linq;
using NUnit.Framework;
using OrderFlow.Data.Contexto;
using OrderFlow.Data.Repositorios;
using OrderFlow.Domain;
using Microsoft.EntityFrameworkCore;

namespace OrderFlow.Test.Data
{
    [TestFixture]
    internal class RolDataTest
    {
        private DbContextOptions<ContextoDbSQLServer> _dbContextOptions;
        private string _connectionString;
        private const string TestRolNombre = "Rol CRUD Test";
        private const string TestRolNombreMod = "Rol CRUD Test Modificado";

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
                var rol = context.Roles.FirstOrDefault(r => r.nombre_rol == TestRolNombre || r.nombre_rol == TestRolNombreMod);
                if (rol != null)
                {
                    context.Roles.Remove(rol);
                    context.SaveChanges();
                }
            }
        }

        [Test]
        public void Rol_CRUD_WorksCorrectly()
        {
            using var context = new ContextoDbSQLServer(_dbContextOptions);
            var rolData = new RolData(context);

            // Limpieza previa
            var existente = context.Roles.FirstOrDefault(r => r.nombre_rol == TestRolNombre || r.nombre_rol == TestRolNombreMod);
            if (existente != null)
            {
                context.Roles.Remove(existente);
                context.SaveChanges();
            }

            // CREATE
            var rolToInsert = new Rol
            {
                nombre_rol = TestRolNombre
            };
            Assert.DoesNotThrow(() => rolData.Crear(rolToInsert), "Crear un rol no debería generar una excepción.");
            Assert.That(rolToInsert.id_rol, Is.GreaterThan(0), "El ID del rol debe ser mayor que 0 después de la inserción.");

            // READ (por ID)
            var insertedRol = rolData.ObtenerPorId(rolToInsert.id_rol);
            Assert.That(insertedRol, Is.Not.Null, "El rol insertado debería existir en la base de datos.");
            Assert.That(insertedRol.nombre_rol, Is.EqualTo(TestRolNombre), "El nombre del rol no coincide.");

            // READ (todos)
            var allRoles = rolData.ObtenerTodos();
            Assert.That(allRoles.Any(r => r.id_rol == insertedRol.id_rol), "El rol debería estar en la lista de todos los roles.");

            // UPDATE
            insertedRol.nombre_rol = TestRolNombreMod;
            Assert.DoesNotThrow(() => rolData.Modificar(insertedRol), "Modificar un rol no debería generar una excepción.");

            var updatedRol = rolData.ObtenerPorId(insertedRol.id_rol);
            Assert.That(updatedRol.nombre_rol, Is.EqualTo(TestRolNombreMod), "El nombre del rol no fue actualizado correctamente.");

            // DELETE
            Assert.DoesNotThrow(() => rolData.Eliminar(insertedRol.id_rol), "Eliminar un rol no debería generar una excepción.");

            var deletedRol = rolData.ObtenerPorId(insertedRol.id_rol);
            Assert.That(deletedRol, Is.Null, "El rol eliminado no debería existir en la base de datos.");
        }
    }
}
