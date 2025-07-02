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
    internal class ClienteDataTest
    {
        private DbContextOptions<ContextoDbSQLServer> _dbContextOptions;
        private string _connectionString;
        private const string TestNombreCompania = "Compañía CRUD Test";
        private const string TestNombreContacto = "Contacto CRUD Test";
        private const string TestNombreContactoMod = "Contacto CRUD Test Modificado";
        private const string TestPuestoContacto = "Gerente";
        private const string TestDireccion = "Calle Falsa 123";
        private const string TestCiudad = "San José";
        private const string TestProvincia = "San José";
        private const string TestCodigoPostal = "10101";
        private const string TestPais = "Costa Rica";
        private const string TestTelefono = "2222-3333";
        private const string TestNumFax = "2222-4444";

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
                var cliente = context.Clientes
                    .FirstOrDefault(c => c.nombre_compania == TestNombreCompania);

                if (cliente != null)
                {
                    context.Clientes.Remove(cliente);
                    context.SaveChanges();
                }
            }
        }

        [Test]
        public void Cliente_CRUD_WorksCorrectly()
        {
            using var context = new ContextoDbSQLServer(_dbContextOptions);
            var clienteData = new ClienteData(context);

            // Limpieza previa
            var existente = context.Clientes.FirstOrDefault(c => c.nombre_compania == TestNombreCompania);
            if (existente != null)
            {
                context.Clientes.Remove(existente);
                context.SaveChanges();
            }

            // CREATE
            var clienteToInsert = new Cliente
            {
                nombre_compania = TestNombreCompania,
                nombre_contacto = TestNombreContacto,
                puesto_contacto = TestPuestoContacto,
                direccion = TestDireccion,
                ciudad = TestCiudad,
                provincia = TestProvincia,
                codigo_postal = TestCodigoPostal,
                pais = TestPais,
                telefono = TestTelefono,
                num_fax = TestNumFax,
                eliminado = false
            };
            Assert.DoesNotThrow(() => clienteData.Crear(clienteToInsert), "Crear un cliente no debería generar una excepción.");
            Assert.That(clienteToInsert.cliente_id, Is.GreaterThan(0), "El ID del cliente debe ser mayor que 0 después de la inserción.");

            // READ (por ID)
            var insertedCliente = clienteData.ObtenerPorId(clienteToInsert.cliente_id);
            Assert.That(insertedCliente, Is.Not.Null, "El cliente insertado debería existir en la base de datos.");
            Assert.That(insertedCliente.nombre_compania, Is.EqualTo(TestNombreCompania), "El nombre de la compañía no coincide.");
            Assert.That(insertedCliente.nombre_contacto, Is.EqualTo(TestNombreContacto), "El nombre del contacto no coincide.");

            // READ (todos)
            var allClientes = clienteData.ObtenerTodos();
            Assert.That(allClientes.Any(c => c.cliente_id == insertedCliente.cliente_id), "El cliente debería estar en la lista de todos los clientes.");

            // UPDATE
            insertedCliente.nombre_contacto = TestNombreContactoMod;
            Assert.DoesNotThrow(() => clienteData.Modificar(insertedCliente), "Modificar un cliente no debería generar una excepción.");

            var updatedCliente = clienteData.ObtenerPorId(insertedCliente.cliente_id);
            Assert.That(updatedCliente.nombre_contacto, Is.EqualTo(TestNombreContactoMod), "El nombre del contacto no fue actualizado correctamente.");

            // DELETE
            Assert.DoesNotThrow(() => clienteData.Eliminar(insertedCliente.cliente_id), "Eliminar un cliente no debería generar una excepción.");

            var deletedCliente = clienteData.ObtenerPorId(insertedCliente.cliente_id);
            Assert.That(deletedCliente, Is.Null, "El cliente eliminado no debería existir en la base de datos.");
        }
    }
}
