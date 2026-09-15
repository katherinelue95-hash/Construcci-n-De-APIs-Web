using StyleBookBarberBD.Services;
using StyleBookBarberBD.DTOs;

namespace StyleBookBarberBD.EndPoints
{
    public static class UsuariosEndpoints
    {
        public static void MapUsuariosEndpoints(this IEndpointRouteBuilder routes)
        {
            routes.MapGet("/api/usuarios", async (UsuariosServices service) =>
            {
                var usuarios = await service.GetUsuariosAsync();
                return Results.Ok(usuarios);
            });

            routes.MapGet("/api/usuarios/{id}", async (int id, UsuariosServices service) =>
            {
                var usuario = await service.GetUsuarioByIdAsync(id);
                return usuario != null ? Results.Ok(usuario) : Results.NotFound();
            });

            routes.MapPost("/api/usuarios", async (RegistroDTO dto, UsuariosServices service) =>
            {
                var nuevoUsuario = await service.CrearUsuarioAsync(dto);
                return Results.Created($"/api/usuarios/{nuevoUsuario.Correo}", nuevoUsuario);
            });
        }
    }
}

