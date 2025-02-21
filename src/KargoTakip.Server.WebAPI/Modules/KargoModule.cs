﻿using KargoTakip.Server.Application.Kargolar;
using KargoTakip.Server.Application.Kargolarim;
using MediatR;
using TS.Result;

namespace KargoTakip.Server.WebAPI.Modules;

public static class KargoModule
{
    public static void RegisterKargoRoutes(this IEndpointRouteBuilder app)
    {
        RouteGroupBuilder group = app.MapGroup("/kargolar").WithTags("Kargolar").RequireAuthorization();

        group.MapPost(string.Empty,
            async (ISender sender, KargoCreateCommand request, CancellationToken cancellatioNToken) =>
            {
                var response = await sender.Send(request, cancellatioNToken);
                return response.IsSuccessful ? Results.Ok(response) : Results.InternalServerError(response);
            })
            .Produces<Result<string>>()
            .WithName("KargoCreate");

        group.MapDelete("{id}",
            async (Guid id, ISender sender, CancellationToken cancellatioNToken) =>
            {
                var response = await sender.Send(new KargoDeleteCommand(id), cancellatioNToken);
                return response.IsSuccessful ? Results.Ok(response) : Results.InternalServerError(response);
            })
            .Produces<Result<string>>()
            .WithName("KargoDelete");
    }
}
