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
    internal class CategoriaDataTest
    {
        private DbContextOptions<ContextoDbSQLServer> _dbContextOptions;
        private string _connectionString;
        private const string TestCategoriaId = "TST1";
        private const string TestDescripcion = "Categoría de Prueba para Test";
        private const string TestDescripcionModificada = "Categoría Modificada para Test";

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
                var categoriaRecienInsertada = context.Categorias
                    .FirstOrDefault(c => c.cod_categoria == TestCategoriaId);

                if (categoriaRecienInsertada != null)
                {
                    context.Categorias.Remove(categoriaRecienInsertada);
                    context.SaveChanges();
                }
            }
        }

        [Test]
        public void Categoria_CRUD_WorksCorrectly()
        {
            using var context = new ContextoDbSQLServer(_dbContextOptions);
            var categoriaData = new CategoriaData(context);

            // Limpieza previa
            var existente = context.Categorias.FirstOrDefault(c => c.cod_categoria == TestCategoriaId);
            if (existente != null)
            {
                context.Categorias.Remove(existente);   
                context.SaveChanges();
            }

            // CREATE
            var categoriaToInsert = new Categoria
            {
                cod_categoria = TestCategoriaId,
                descripcion = TestDescripcion
            };
            Assert.DoesNotThrow(() => categoriaData.Crear(categoriaToInsert), "Crear una categoría no debería generar una excepción.");

            // READ (por ID)
            var insertedCategoria = categoriaData.VerCategoriaPorID(TestCategoriaId);
            Assert.That(insertedCategoria, Is.Not.Null, "La categoría insertada debería existir en la base de datos.");
            Assert.That(insertedCategoria.cod_categoria, Is.EqualTo(TestCategoriaId), "El código de la categoría no coincide.");
            Assert.That(insertedCategoria.descripcion, Is.EqualTo(TestDescripcion), "La descripción de la categoría no coincide.");

            // READ (todas)
            var allCategorias = categoriaData.VerCategorias();
            Assert.That(allCategorias.Any(c => c.cod_categoria == TestCategoriaId), "La categoría debería estar en la lista de todas las categorías.");

            // UPDATE
            insertedCategoria.descripcion = TestDescripcionModificada;
            Assert.DoesNotThrow(() => categoriaData.Modificar(insertedCategoria), "Modificar una categoría no debería generar una excepción.");

            var updatedCategoria = categoriaData.VerCategoriaPorID(TestCategoriaId);
            Assert.That(updatedCategoria.descripcion, Is.EqualTo(TestDescripcionModificada), "La descripción de la categoría no fue actualizada correctamente.");

            // DELETE
            Assert.DoesNotThrow(() => categoriaData.Eliminar(TestCategoriaId), "Eliminar una categoría no debería generar una excepción.");

            var deletedCategoria = categoriaData.VerCategoriaPorID(TestCategoriaId);
            Assert.That(deletedCategoria, Is.Null, "La categoría eliminada no debería existir en la base de datos.");
        }
    }
}
