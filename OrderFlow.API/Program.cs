using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using OrderFlow.API.Controllers;
using OrderFlow.Business.Interfaces;
using OrderFlow.Business.Servicios;
using OrderFlow.Business.Servicios.Autenticacion;
using OrderFlow.Data.Contexto;
using OrderFlow.Data.Interfaces;
using OrderFlow.Data.Repositorios;
using OrderFlow.Data.Seguridad;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Obtener la cadena de conexi?n del archivo appsettings.json
var connectionString = builder.Configuration.GetConnectionString("OrderFlowDB");

// Configurar Entity Framework Core con SQL Server
builder.Services.AddDbContext<ContextoDbSQLServer>(options => options.UseSqlServer(connectionString));

builder.Services.AddScoped<IProductoBusiness, ProductoBusiness>();
builder.Services.AddScoped<IProductoData, ProductoData>();
builder.Services.AddScoped<ICategoriaBusiness, CategoriaBusiness>();
builder.Services.AddScoped<ICategoriaData, CategoriaData>();
builder.Services.AddScoped<IClienteBusiness, ClienteBusiness>();
builder.Services.AddScoped<IClienteData, ClienteData>();
builder.Services.AddScoped<IDepartamentoBusiness, DepartamentoBusiness>();
builder.Services.AddScoped<IDepartamentoData, DepartamentoData>();
builder.Services.AddScoped<IRolBusiness, RolBusiness>();
builder.Services.AddScoped<IRolData, RolData>();
builder.Services.AddScoped<IEmpleadoBusiness, EmpleadoBusiness>();
builder.Services.AddScoped<IEmpleadoData, EmpleadoData>();

builder.Services.AddScoped<ITokenService, GeneracionDeTokens>();
builder.Services.AddScoped<IAuthService, AuthService>();

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"])),
            ValidateIssuer = false,
            ValidateAudience = false,
            ValidateLifetime = true,
            ClockSkew = TimeSpan.Zero
        };
    });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
