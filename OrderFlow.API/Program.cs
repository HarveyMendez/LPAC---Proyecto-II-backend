using Microsoft.EntityFrameworkCore;
using OrderFlow.API.Controllers;
using OrderFlow.Business.Interfaces;
using OrderFlow.Business.Servicios;
using OrderFlow.Data.Contexto;
using OrderFlow.Data.Interfaces;
using OrderFlow.Data.Repositorios;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Obtener la cadena de conexi?n del archivo appsettings.json
var connectionString = builder.Configuration.GetConnectionString("OrderFlowDB");

// Configurar Entity Framework Core con SQL Server
builder.Services.AddDbContext<ContextoDbSQLServer>(options => options.UseSqlServer(connectionString));

builder.Services.AddScoped<IProductoBusiness, ProductoBusiness>();
builder.Services.AddScoped<IProductoData, ProductoData>();

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
