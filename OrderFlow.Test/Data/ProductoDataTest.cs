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
    private const string TestCategoriaId = "TSTP";
    private const string TestCategoriaDescripcion = "Categoría CRUD Producto";
    private const string TestProductoNombre = "Producto CRUD Test";
    private const string TestProductoNombreMod = "Producto CRUD Test Modificado";

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
            var producto = context.Productos.FirstOrDefault(p => p.nombre_producto == TestProductoNombre || p.nombre_producto == TestProductoNombreMod);
            if (producto != null)
            {
                context.Productos.Remove(producto);
                context.SaveChanges();
            }

            var categoria = context.Categorias.FirstOrDefault(c => c.cod_categoria == TestCategoriaId);
            if (categoria != null)
            {
                context.Categorias.Remove(categoria);
                context.SaveChanges();
            }
        }
    }

    [Test]
    public void Producto_CRUD_WorksCorrectly()
    {
        using var context = new ContextoDbSQLServer(_dbContextOptions);
        var productoData = new ProductoData(context);

        // Ensure Categoria exists
        var categoria = context.Categorias.Find(TestCategoriaId);
        if (categoria == null)
        {
            categoria = new Categoria { cod_categoria = TestCategoriaId, descripcion = TestCategoriaDescripcion };
            context.Categorias.Add(categoria);
            context.SaveChanges();
        }

        // Limpieza previa
        var existente = context.Productos.FirstOrDefault(p => p.nombre_producto == TestProductoNombre || p.nombre_producto == TestProductoNombreMod);
        if (existente != null)
        {
            context.Productos.Remove(existente);
            context.SaveChanges();
        }

        // CREATE
        var productoToInsert = new Producto
        {
            nombre_producto = TestProductoNombre,
            precio = 99.99f,
            cantidad_existencias = 50,
            talla = "M",
            punto_reorden = 5,
            aplica_impuesto = true,
            cod_categoria = categoria.cod_categoria
        };
        Assert.DoesNotThrow(() => productoData.Crear(productoToInsert), "Crear un producto no debería generar una excepción.");
        Assert.That(productoToInsert.id_producto, Is.GreaterThan(0), "El ID del producto debe ser mayor que 0 después de la inserción.");

        // READ (por ID)
        var insertedProducto = productoData.VerProductoPorID(productoToInsert.id_producto);
        Assert.That(insertedProducto, Is.Not.Null, "El producto insertado debería existir en la base de datos.");
        Assert.That(insertedProducto.nombre_producto, Is.EqualTo(TestProductoNombre), "El nombre del producto no coincide.");

        // READ (todos)
        var allProductos = productoData.VerProductos();
        Assert.That(allProductos.Any(p => p.id_producto == insertedProducto.id_producto), "El producto debería estar en la lista de todos los productos.");

        // UPDATE
        insertedProducto.nombre_producto = TestProductoNombreMod;
        insertedProducto.precio = 149.99f;
        Assert.DoesNotThrow(() => productoData.Modificar(insertedProducto), "Modificar un producto no debería generar una excepción.");

        var updatedProducto = productoData.VerProductoPorID(insertedProducto.id_producto);
        Assert.That(updatedProducto.nombre_producto, Is.EqualTo(TestProductoNombreMod), "El nombre del producto no fue actualizado correctamente.");
        Assert.That(updatedProducto.precio, Is.EqualTo(149.99f).Within(0.001f), "El precio del producto no fue actualizado correctamente.");

        // DELETE
        Assert.DoesNotThrow(() => productoData.Eliminar(insertedProducto.id_producto), "Eliminar un producto no debería generar una excepción.");

        var deletedProducto = productoData.VerProductoPorID(insertedProducto.id_producto);
        Assert.That(deletedProducto, Is.Null, "El producto eliminado no debería existir en la base de datos.");
    }
}