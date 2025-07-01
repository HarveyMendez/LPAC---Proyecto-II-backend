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

    [SetUp]
    public void Setup()
    {
        this._connectionString = "Data Source=163.178.173.130;Initial Catalog=LPAC_ProyectoII_DB;Persist Security Info=True;User ID=Lenguajes;Password=lenguajesparaiso2025;Encrypt=False";

        _dbContextOptions = new DbContextOptionsBuilder<ContextoDbSQLServer>()
            .UseSqlServer(this._connectionString)
            .Options;

        using (var context = new ContextoDbSQLServer(_dbContextOptions))
        {
            // Opcional: Asegurarse de que la DB exista. Para una DB de la U, esto ya debería estar.
            context.Database.EnsureCreated();
        }
    }

    [TearDown]
    public void Teardown()
    {
        using (var context = new ContextoDbSQLServer(_dbContextOptions))
        {
            // Eliminar el empleado creado por el test
            var empleadoRecienInsertado = context.Empleados
                .FirstOrDefault(e => e.nombre_empleado == "NombreTest" && e.apellidos_empleado == "ApellidoTest");

            if (empleadoRecienInsertado != null)
            {
                context.Empleados.Remove(empleadoRecienInsertado);
                context.SaveChanges();
            }

            // Eliminar el departamento de prueba si fue creado por este test
            var departamentoRecienInsertado = context.Departamentos
                .FirstOrDefault(d => d.depto_cod == "TDE"); // Usar el ID de prueba de 3 caracteres

            if (departamentoRecienInsertado != null)
            {
                context.Departamentos.Remove(departamentoRecienInsertado);
                context.SaveChanges();
            }

            // Eliminar el rol de prueba si fue creado por este test
            var rolRecienInsertado = context.Roles
                .FirstOrDefault(r => r.nombre_rol == "Rol de Prueba para Test"); // Buscar por nombre para el rol que se insertó si es IDENTITY

            if (rolRecienInsertado != null)
            {
                context.Roles.Remove(rolRecienInsertado);
                context.SaveChanges();
            }
        }
    }

    [Test]
    public void Crear_ValidEmpleado_InsertsSuccessfully()
    {
        // Arrange
        using var context = new ContextoDbSQLServer(_dbContextOptions);
        var empleadoData = new EmpleadoData(context);

        // --- Manejo del Departamento de Prueba ---
        // Usar un cod_depto de 3 caracteres si la columna en DB es VARCHAR(3) o NVARCHAR(3)
        string testDeptoCod = "TDE";
        var departamento = new Departamento { depto_cod = testDeptoCod, nombre_departament = "Departamento de Prueba Test" };

        var existingDepartamento = context.Departamentos.Find(testDeptoCod);
        if (existingDepartamento == null)
        {
            context.Departamentos.Add(departamento);
            context.SaveChanges();
        }
        else
        {
            departamento = existingDepartamento;
        }

        // --- Manejo del Rol de Prueba ---
        // Si id_rol es IDENTITY en DB, NO asignes el ID, deja que la DB lo genere.
        // Si no es IDENTITY, usa un ID que sepas que no existe (ej. 99, 100).
        // Para este ejemplo, asumiremos que id_rol es IDENTITY y solo asignamos el nombre.
        // Si no es IDENTITY, tendrías que asignar 'id_rol = 99' o similar aquí.
        var rol = new Rol { nombre_rol = "Rol de Prueba para Test" };

        // Buscar si un rol con este nombre ya existe, para no duplicarlo en la prueba
        var existingRol = context.Roles.FirstOrDefault(r => r.nombre_rol == rol.nombre_rol);
        if (existingRol == null)
        {
            context.Roles.Add(rol);
            context.SaveChanges();
        }
        else
        {
            rol = existingRol;
        }

        var empleadoToInsert = new Empleado
        {
            nombre_empleado = "NombreTest",
            apellidos_empleado = "ApellidoTest",
            puesto = "Desarrollador Jr.",
            extension = "1234",
            telefono_trabajo = "8888-7777",
            depto_cod = departamento.depto_cod,
            id_rol = rol.id_rol, // Ahora 'rol.id_rol' tendrá el ID generado o el existente
            nombre_usuario = "usuario.test",
            contrasena_hash = "hashseguro123_test",
            email = "usuario.test@example.com"
        };

        // Act
        Assert.DoesNotThrow(() => empleadoData.Crear(empleadoToInsert),
            "Crear un empleado no debería generar una excepción.");

        // Assert
        Assert.That(empleadoToInsert.id_empleado, Is.GreaterThan(0), "El ID del empleado debe ser mayor que 0 después de la inserción.");

        var insertedEmpleado = context.Empleados
            .Include(e => e.Departamento)
            .Include(e => e.Rol)
            .FirstOrDefault(e => e.nombre_empleado == "NombreTest" && e.apellidos_empleado == "ApellidoTest");

        Assert.That(insertedEmpleado, Is.Not.Null, "El empleado insertado debería existir en la base de datos.");
        Assert.That(insertedEmpleado.nombre_empleado, Is.EqualTo("NombreTest"), "El nombre del empleado no coincide.");
        Assert.That(insertedEmpleado.apellidos_empleado, Is.EqualTo("ApellidoTest"), "Los apellidos del empleado no coinciden.");
        Assert.That(insertedEmpleado.puesto, Is.EqualTo("Desarrollador Jr."), "El puesto del empleado no coincide.");
        Assert.That(insertedEmpleado.extension, Is.EqualTo("1234"), "La extensión del empleado no coincide.");
        Assert.That(insertedEmpleado.telefono_trabajo, Is.EqualTo("8888-7777"), "El teléfono de trabajo del empleado no coincide.");
        Assert.That(insertedEmpleado.depto_cod, Is.EqualTo(departamento.depto_cod), "El código de departamento no coincide.");
        Assert.That(insertedEmpleado.id_rol, Is.EqualTo(rol.id_rol), "El ID de rol no coincide.");
        Assert.That(insertedEmpleado.nombre_usuario, Is.EqualTo("usuario.test"), "El nombre de usuario no coincide.");
        Assert.That(insertedEmpleado.contrasena_hash, Is.EqualTo("hashseguro123_test"), "El hash de la contraseña no coincide.");
        Assert.That(insertedEmpleado.email, Is.EqualTo("usuario.test@example.com"), "El email no coincide.");

        Assert.That(insertedEmpleado.Departamento, Is.Not.Null, "El departamento del empleado no debería ser nulo.");
        Assert.That(insertedEmpleado.Departamento.nombre_departament, Is.EqualTo("Departamento de Prueba Test"), "El nombre del departamento no coincide.");

        Assert.That(insertedEmpleado.Rol, Is.Not.Null, "El rol del empleado no debería ser nulo.");
        Assert.That(insertedEmpleado.Rol.nombre_rol, Is.EqualTo("Rol de Prueba para Test"), "El nombre del rol no coincide.");
    }
}