using Microsoft.EntityFrameworkCore;
using Northwind.Regions.Application.Contracts;
using Northwind.Regions.Application.Services;
using Northwind.Regions.Persistence.Context;
using Northwind.Regions.Persistence.Repository;
using Northwind.Region.IOC.Dependency;

var builder = WebApplication.CreateBuilder(args);

// Configurar la cadena de conexión
var connString = builder.Configuration.GetConnectionString("NorthwindContext");

// Registrar el contexto de EF Core
builder.Services.AddDbContext<NorthwindContext>(options =>
    options.UseSqlServer(connString));

// Registrar los servicios necesarios
builder.Services.AddScoped<IRegionService, RegionService>();
builder.Services.AddRegionDependency(); // Asumiendo que hay un método similar a AddProductDependency para regiones

// Agregar controladores y configuración de Swagger
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configurar el pipeline de solicitud HTTP
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Northwind API V1");
    });
}

app.UseAuthorization();
app.MapControllers();

app.Run();
