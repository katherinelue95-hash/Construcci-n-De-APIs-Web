using StyleBookBarberBD.Services;
using StyleBookBarberBD.DTOs;
using StyleBookBarberBD.DTos;

namespace StyleBookBarberBD.EndPoints
{
    public static class CitasEndpoints
    {
        public static void MapCitasEndpoints(this IEndpointRouteBuilder routes)
        {
            routes.MapGet("/api/citas", async (CitasServices service) =>
            {
                var citas = await service.GetCitasAsync();
                return Results.Ok(citas);
            });

            routes.MapGet("/api/citas/{id}", async (int id, CitasServices service) =>
            {
                var cita = await service.GetCitaByIdAsync(id);
                return cita != null ? Results.Ok(cita) : Results.NotFound();
            });

            routes.MapPost("/api/citas", async (CitasDTos dto, CitasServices service) =>
            {
                var nuevaCita = await service.CrearCitaAsync(dto);
                return Results.Created($"/api/citas/{nuevaCita.ClienteId}", nuevaCita);
            });
        }
    }
}

