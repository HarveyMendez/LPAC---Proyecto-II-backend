using NUnit.Framework;
using OrderFlow.Data.Contexto;
using OrderFlow.Data.Repositorios;
using OrderFlow.Domain;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace OrderFlow.Test;

[TestFixture]
public class EmpleadoDataTest
{
    private DbContextOptions<ContextoDbSQLServer> _dbContextOptions;
    private string _connectionString;
    private const string TestDeptoCod = "TS"; // Changed from "TSTX" to "TS" (2 characters)
    private const string TestDeptoNombre = "Departamento CRUD Test";
    private const string TestRolNombre = "Rol CRUD Test";
    private const string TestEmpleadoNombre = "EmpleadoCRUD";
    private const string TestEmpleadoApellido = "ApellidoCRUD";
    private const string TestEmpleadoPuesto = "Tester";
    private const string TestEmpleadoPuestoMod = "Tester Modificado";

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
            var empleado = context.Empleados.FirstOrDefault(e => e.nombre_empleado == TestEmpleadoNombre && e.apellidos_empleado == TestEmpleadoApellido);
            if (empleado != null)
            {
                context.Empleados.Remove(empleado);
                context.SaveChanges();
            }

            var rol = context.Roles.FirstOrDefault(r => r.nombre_rol == TestRolNombre);
            if (rol != null)
            {
                context.Roles.Remove(rol);
                context.SaveChanges();
            }

            var depto = context.Departamentos.FirstOrDefault(d => d.depto_cod == TestDeptoCod);
            if (depto != null)
            {
                context.Departamentos.Remove(depto);
                context.SaveChanges();
            }
        }
    }

    [Test]
    public void Empleado_CRUD_WorksCorrectly()
    {
        using var context = new ContextoDbSQLServer(_dbContextOptions);
        var empleadoData = new EmpleadoData(context);

        // Ensure Departamento exists
        var departamento = context.Departamentos.Find(TestDeptoCod);
        if (departamento == null)
        {
            departamento = new Departamento { depto_cod = TestDeptoCod, nombre_departament = TestDeptoNombre };
            context.Departamentos.Add(departamento);
            context.SaveChanges();
        }

        // Ensure Rol exists
        var rol = context.Roles.FirstOrDefault(r => r.nombre_rol == TestRolNombre);
        if (rol == null)
        {
            rol = new Rol { nombre_rol = TestRolNombre };
            context.Roles.Add(rol);
            context.SaveChanges();
        }

        // Limpieza previa
        var existente = context.Empleados.FirstOrDefault(e => e.nombre_empleado == TestEmpleadoNombre && e.apellidos_empleado == TestEmpleadoApellido);
        if (existente != null)
        {
            context.Empleados.Remove(existente);
            context.SaveChanges();
        }

        // CREATE
        var empleadoToInsert = new Empleado
        {
            nombre_empleado = TestEmpleadoNombre,
            apellidos_empleado = TestEmpleadoApellido,
            puesto = TestEmpleadoPuesto,
            extension = "9999",
            telefono_trabajo = "5555-5555",
            depto_cod = departamento.depto_cod,
            id_rol = rol.id_rol,
            nombre_usuario = "usuario.crud",
            contrasena_hash = "hash_crud",
            email = "crud@example.com"
        };
        Assert.DoesNotThrow(() => empleadoData.Crear(empleadoToInsert), "Crear un empleado no debería generar una excepción.");

        // READ (por ID)
        var insertedEmpleado = empleadoData.ObtenerPorId(empleadoToInsert.id_empleado);
        Assert.That(insertedEmpleado, Is.Not.Null, "El empleado insertado debería existir en la base de datos.");
        Assert.That(insertedEmpleado.nombre_empleado, Is.EqualTo(TestEmpleadoNombre), "El nombre no coincide.");
        Assert.That(insertedEmpleado.apellidos_empleado, Is.EqualTo(TestEmpleadoApellido), "El apellido no coincide.");
        Assert.That(insertedEmpleado.puesto, Is.EqualTo(TestEmpleadoPuesto), "El puesto no coincide.");

        // READ (todos)
        var allEmpleados = empleadoData.ObtenerTodos();
        Assert.That(allEmpleados.Any(e => e.id_empleado == insertedEmpleado.id_empleado), "El empleado debería estar en la lista de todos los empleados.");

        // UPDATE
        insertedEmpleado.puesto = TestEmpleadoPuestoMod;
        Assert.DoesNotThrow(() => empleadoData.Modificar(insertedEmpleado), "Modificar un empleado no debería generar una excepción.");

        var updatedEmpleado = empleadoData.ObtenerPorId(insertedEmpleado.id_empleado);
        Assert.That(updatedEmpleado.puesto, Is.EqualTo(TestEmpleadoPuestoMod), "El puesto no fue actualizado correctamente.");

        // DELETE
        Assert.DoesNotThrow(() => empleadoData.Eliminar(insertedEmpleado.id_empleado), "Eliminar un empleado no debería generar una excepción.");

        var deletedEmpleado = empleadoData.ObtenerPorId(insertedEmpleado.id_empleado);
        Assert.That(deletedEmpleado, Is.Null, "El empleado eliminado no debería existir en la base de datos.");
    }
}