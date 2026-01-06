using api.service.factura.application.commons.dtos;
using api.service.factura.application.ifeatures;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace api.service.factura.presentation.endpoints;

public static class ClienteEndpoints
{
    public static RouteGroupBuilder MapCliente(this RouteGroupBuilder builder)
    {
        builder.MapGet("/", GetAll);
        builder.MapGet("/{id:int}", GetById);
        builder.MapPost("/", Insert);
        return builder;
    }

    static async Task<Results<Ok<List<ClienteResponseDto>>, 
                              ProblemHttpResult>> GetAll(IClienteHandler clienteHandler)
    {
        return TypedResults.Ok(await clienteHandler.GetAll());
    }

    static async Task<Results<Ok<ClienteResponseDto>, 
                              NotFound<string>>> GetById([FromRoute] int id, 
                                                         IClienteHandler clienteHandler)
    {
        var cliente = await clienteHandler.GetById(id);
        if (cliente.ClienteId == 0)
        {
            return TypedResults.NotFound("No encontrado");
        }
        return TypedResults.Ok(cliente);
    }

    static async Task<Results<Created<ClienteResponseDto>,
                              ProblemHttpResult>> Insert([FromBody] ClienteRequestDto clienteRequest,
                                                         IClienteHandler clienteHandler)
    {
        var cliente = await clienteHandler.Insert(clienteRequest);
        return TypedResults.Created($"/v1/cliente/{cliente.ClienteId}", cliente);
    }
}