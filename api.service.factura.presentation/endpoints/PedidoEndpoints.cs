using api.service.factura.application.commons.dtos;
using api.service.factura.application.ifeatures;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace api.service.factura.presentation.endpoints;

public static class PedidoEndpoints
{
    public static RouteGroupBuilder MapPedido(this RouteGroupBuilder builder)
    {
        builder.MapPost("/", Insert);
        return builder;
    }

    static async Task<Results<Created<PedidoResponseDto>, BadRequest, ProblemHttpResult>> Insert([FromBody] PedidoRequestDto pedidoRequest,
                                                                                     IPedidoHandler pedidoHandler)
    { 
        var pedido = await pedidoHandler.Insert(pedidoRequest);

        if (pedido == null)
        {
            return TypedResults.BadRequest();
        }

        return TypedResults.Created($"/v1/pedido/{pedido.PedidoId}", pedido);
    }
}