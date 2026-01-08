using api.service.factura.application.commons.dtos;
using api.service.factura.application.ifeatures;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace api.service.factura.presentation.endpoints;

public static class ProductoEndpoints
{
    public static RouteGroupBuilder MapProducto(this RouteGroupBuilder builder)
    {
        builder.MapGet("/", GetAll);
        builder.MapGet("/{id:int}", GetById);
        builder.MapPost("/", Insert);
        return builder;
    }

    static async Task<Results<Ok<List<ProductoResponseDto>>, 
                              ProblemHttpResult>> GetAll(IProductoHandler productoHandler)
    {
        return TypedResults.Ok(await productoHandler.GetAll());
    }

    static async Task<Results<Ok<ProductoResponseDto>, 
                              NotFound<string>,
                              ProblemHttpResult>> GetById([FromRoute] int id, 
                                                          IProductoHandler productoHandler)
    {
        var producto = await productoHandler.GetById(id);

        if (producto.ProductoId == 0)
        {
            return TypedResults.NotFound("No encontrado");
        }

        return TypedResults.Ok(producto);
    }

    static async Task<Results<Created<ProductoResponseDto>,
                              ProblemHttpResult>> Insert([FromBody] ProductoRequestDto productoRequest,
                                                         IProductoHandler productoHandler)
    {
        var producto = await productoHandler.Insert(productoRequest);
        return TypedResults.Created($"/v1/producto/{producto.ProductoId}", producto);
    }
}