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
    internal class DepartamentoDataTest 
    {
        private DbContextOptions<ContextoDbSQLServer> _dbContextOptions;
        private string _connectionString;
        private const string TestDeptoCod = "TS";
        private const string TestDeptoNombre = "Departamento CRUD Test";
        private const string TestDeptoNombreMod = "Departamento CRUD Test Modificado";

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
                var departamento = context.Departamentos
                    .FirstOrDefault(d => d.depto_cod == TestDeptoCod);

                if (departamento != null)
                {
                    context.Departamentos.Remove(departamento);
                    context.SaveChanges();
                }
            }
        }

        [Test]
        public void Departamento_CRUD_WorksCorrectly()
        {
            using var context = new ContextoDbSQLServer(_dbContextOptions);
            var departamentoData = new DepartamentoData(context);

            // Limpieza previa
            var existente = context.Departamentos.FirstOrDefault(d => d.depto_cod == TestDeptoCod);
            if (existente != null)
            {
                context.Departamentos.Remove(existente);
                context.SaveChanges();
            }

            // CREATE
            var departamentoToInsert = new Departamento
            {
                depto_cod = TestDeptoCod,
                nombre_departament = TestDeptoNombre
            };
            Assert.DoesNotThrow(() => departamentoData.Crear(departamentoToInsert), "Crear un departamento no debería generar una excepción.");

            // READ (por ID)
            var insertedDepartamento = departamentoData.ObtenerPorId(TestDeptoCod);
            Assert.That(insertedDepartamento, Is.Not.Null, "El departamento insertado debería existir en la base de datos.");
            Assert.That(insertedDepartamento.depto_cod, Is.EqualTo(TestDeptoCod), "El código del departamento no coincide.");
            Assert.That(insertedDepartamento.nombre_departament, Is.EqualTo(TestDeptoNombre), "El nombre del departamento no coincide.");

            // READ (todos)
            var allDepartamentos = departamentoData.ObtenerTodos();
            Assert.That(allDepartamentos.Any(d => d.depto_cod == TestDeptoCod), "El departamento debería estar en la lista de todos los departamentos.");

            // UPDATE
            insertedDepartamento.nombre_departament = TestDeptoNombreMod;
            Assert.DoesNotThrow(() => departamentoData.Modificar(insertedDepartamento), "Modificar un departamento no debería generar una excepción.");

            var updatedDepartamento = departamentoData.ObtenerPorId(TestDeptoCod);
            Assert.That(updatedDepartamento.nombre_departament, Is.EqualTo(TestDeptoNombreMod), "El nombre del departamento no fue actualizado correctamente.");

            // DELETE
            Assert.DoesNotThrow(() => departamentoData.Eliminar(TestDeptoCod), "Eliminar un departamento no debería generar una excepción.");

            var deletedDepartamento = departamentoData.ObtenerPorId(TestDeptoCod);
            Assert.That(deletedDepartamento, Is.Null, "El departamento eliminado no debería existir en la base de datos.");
        }
    }
}
