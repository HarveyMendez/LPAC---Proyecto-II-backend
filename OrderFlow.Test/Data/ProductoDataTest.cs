using NUnit.Framework;
using OrderFlow.Data.Contexto;
using OrderFlow.Data.Repositorios;
using OrderFlow.Domain;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace OrderFlow.Test;

[TestFixture]
public class ProductoDataTest
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
            var productoRecienInsertado = context.Productos
                .FirstOrDefault(p => p.nombre_producto == "Producto de Prueba para Test");

            if (productoRecienInsertado != null)
            {
                context.Productos.Remove(productoRecienInsertado);
                context.SaveChanges();
            }

            var categoriaRecienInsertada = context.Categorias
                .FirstOrDefault(c => c.cod_categoria == "TEST");

            if (categoriaRecienInsertada != null)
            {
                context.Categorias.Remove(categoriaRecienInsertada);
                context.SaveChanges();
            }
        }
    }

    [Test]
    public void Crear_ValidProducto_InsertsSuccessfully()
    {
        // Arrange
        using var context = new ContextoDbSQLServer(_dbContextOptions);
        var productoData = new ProductoData(context);

        string testCategoriaId = "TEST";
        var categoria = new Categoria { cod_categoria = testCategoriaId, descripcion = "Categoría de Prueba" };

        var existingCategory = context.Categorias.Find(testCategoriaId);
        if (existingCategory == null)
        {
            context.Categorias.Add(categoria);
            context.SaveChanges();
        }
        else
        {
            categoria = existingCategory;
        }

        var productoToInsert = new Producto
        {
            precio = 123.45f,
            nombre_producto = "Producto de Prueba para Test",
            cantidad_existencias = 10,
            talla = "Única",
            punto_reorden = 2,
            aplica_impuesto = true,
            eliminado = false,
            cod_categoria = categoria.cod_categoria
        };

        // Act
        Assert.DoesNotThrow(() => productoData.Crear(productoToInsert),
            "Crear un producto no debería generar una excepción.");

        // Assert
        Assert.That(productoToInsert.id_producto, Is.GreaterThan(0), "El ID del producto debe ser mayor que 0 después de la inserción.");

        var insertedProducto = context.Productos
            .Include(p => p.Categoria)
            .FirstOrDefault(p => p.nombre_producto == "Producto de Prueba para Test");

        Assert.That(insertedProducto, Is.Not.Null, "El producto insertado debería existir en la base de datos.");
        Assert.That(insertedProducto.nombre_producto, Is.EqualTo("Producto de Prueba para Test"), "El nombre del producto no coincide.");
        Assert.That(insertedProducto.precio, Is.EqualTo(123.45f).Within(0.001f), "El precio del producto no coincide.");
        Assert.That(insertedProducto.cantidad_existencias, Is.EqualTo(10), "La cantidad de existencias no coincide.");
        Assert.That(insertedProducto.talla, Is.EqualTo("Única"), "La talla del producto no coincide.");
        Assert.That(insertedProducto.punto_reorden, Is.EqualTo(2), "El punto de reorden no coincide.");
        Assert.That(insertedProducto.aplica_impuesto, Is.True, "Aplica impuesto no coincide.");
        Assert.That(insertedProducto.eliminado, Is.False, "Eliminado no coincide.");
        Assert.That(insertedProducto.cod_categoria, Is.EqualTo(categoria.cod_categoria), "El código de categoría no coincide.");
        Assert.That(insertedProducto.Categoria, Is.Not.Null, "La categoría del producto no debería ser nula.");
        Assert.That(insertedProducto.Categoria.descripcion, Is.EqualTo("Categoría de Prueba"), "La descripción de la categoría no coincide.");
    }
}