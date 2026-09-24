using Microsoft.EntityFrameworkCore;
using StyleBookBarberBD.Data;
using StyleBookBarberBD.EndPoints;
using StyleBookBarberBD.Mappings;
using StyleBookBarberBD.Services;
using AutoMapper;


var builder = WebApplication.CreateBuilder(args);

// 🔹 Configuración de DbContext con SQL Server
builder.Services.AddDbContext<StyleBookBarberBDContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// 🔹 AutoMapper
builder.Services.AddAutoMapper(cfg => { }, typeof(AutoMapperProfile).Assembly);


// 🔹 Registro de Services

builder.Services.AddScoped<ServiciosServices>();
builder.Services.AddScoped<CitasServices>();
builder.Services.AddScoped<UsuariosServices>();
builder.Services.AddScoped<BarberosServices>();
builder.Services.AddScoped<CategoriasServices>();
builder.Services.AddScoped<HorariosBarberoServices>();
builder.Services.AddScoped<RolesServices>();
builder.Services.AddScoped<AuthServices>();
builder.Services.AddScoped<ResenasServices>();

// 🔹 Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// 🔹 Middleware
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// 🔹 Archivos estáticos (fotos subidas por el panel administrativo)
app.UseStaticFiles();

// 🔹 Endpoints (Minimal API)

app.MapServiciosEndpoints();
app.MapCitasEndpoints();
app.MapUsuariosEndpoints();
app.MapBarberosEndpoints();
app.MapCategoriasEndpoints();
app.MapHorariosBareroEndpoints();
app.MapRolesEndpoints();
app.MapAuthEndpoints();
app.MapResenasEndpoints();
app.MapArchivosEndpoints();

app.Run();

