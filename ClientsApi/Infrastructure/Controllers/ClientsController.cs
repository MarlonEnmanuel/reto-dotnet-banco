using ClientsApi.Application.Dtos;
using ClientsApi.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace ClientsApi.Infrastructure.Controllers
{
    public static class ClientsController
    {
        public static void MapClientRoutes(this IEndpointRouteBuilder routeBuilder)
        {
            var clients = routeBuilder.MapGroup("/clients").WithOpenApi();

            clients.MapGet("", async ([FromServices] IClientsService service) =>
            {
                return Results.Ok(await service.GetClients());
            });

            clients.MapGet("{id:int}", async (int id, [FromServices] IClientsService service) =>
            {
                return Results.Ok(await service.GetClient(id));
            });

            clients.MapPost("", async ([FromBody] CreateClientDto dto, [FromServices] IClientsService service) =>
            {
                var result = await service.CreateClient(dto);
                return Results.Created($"/clients/{result.Id}", result);
            });

            clients.MapPut("{id:int}", async (int id, [FromBody] UpdateClientDto dto, [FromServices] IClientsService service) =>
            {
                var result = await service.UpdateClient(id, dto);
                return Results.Accepted($"/clients/{result.Id}", result);
            });

            clients.MapDelete("{id:int}", async (int id, [FromServices] IClientsService service) =>
            {
                await service.DeleteClient(id);
                return Results.NoContent();
            });
        }
    }
}
