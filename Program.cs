using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using SOneWeb.Api.Utils;
using SOneWeb.Domain.Entities;
using SOneWeb.Infrastructure.Persistence;
using DotNetEnv;
using SOneWeb.Infrastructure.Persistence.Repositorios;
using SOneWeb.Application.Interfaces;
using SOneWeb.Application.Services;

var builder = WebApplication.CreateBuilder(args);

// -----------------------------------------------------------------------------
// 1️⃣ Cargar variables de entorno
// -----------------------------------------------------------------------------
Env.Load();
var connectionString = Environment.GetEnvironmentVariable("URL_CONNECT_BD");

// -----------------------------------------------------------------------------
// 2️⃣ Configurar DbContext con PostgreSQL
// -----------------------------------------------------------------------------
builder.Services.AddDbContext<DBConexion>(options =>
    options.UseNpgsql(connectionString));

// -----------------------------------------------------------------------------
// 3️⃣ Configurar Identity
// -----------------------------------------------------------------------------
builder.Services.AddIdentity<UserEntity, IdentityRole<int>>(options =>
{
    // Puedes personalizar reglas de contraseña, bloqueo, etc.
    options.Password.RequireDigit = false;
    options.Password.RequireUppercase = false;
    options.Password.RequiredLength = 6;
})
.AddEntityFrameworkStores<DBConexion>()
.AddDefaultTokenProviders();

// -----------------------------------------------------------------------------
// 4️⃣ Agregar AutoMapper
// -----------------------------------------------------------------------------
builder.Services.AddAutoMapper(typeof(MappingProfile));

// -----------------------------------------------------------------------------
// 5️⃣ Agregar controladores y Swagger
// -----------------------------------------------------------------------------
builder.Services.AddControllers();


// Repositorio genérico
builder.Services.AddScoped(typeof(BaseRepository<>));
// Servicio genérico
builder.Services.AddScoped(typeof(IBaseService<,>), typeof(BaseService<,>));


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "SOneWeb API",
        Version = "v1",
        Description = "API del proyecto SOneWeb"
    });
});

// -----------------------------------------------------------------------------
// 6️⃣ Construir la aplicación
// -----------------------------------------------------------------------------
var app = builder.Build();

// -----------------------------------------------------------------------------
// 7️⃣ Configuración del pipeline HTTP
// -----------------------------------------------------------------------------
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "SOneWeb API v1");
    });
}

app.UseHttpsRedirection();

app.UseAuthentication(); // 🔹 Necesario para Identity
app.UseAuthorization();

app.MapControllers();

app.Run();
