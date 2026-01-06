using api.service.factura.application.commons.dtos;
using api.service.factura.application.ifeatures;
using Microsoft.AspNetCore.Http.HttpResults;

namespace api.service.factura.presentation.endpoints;

public static class ProductoEndpoints
{
    public static RouteGroupBuilder MapProducto(this RouteGroupBuilder builder)
    {
        builder.MapGet("/", GetAll);
        return builder;
    }

    private static async Task<Results<Ok<List<ProductoResponseDto>>, ProblemHttpResult>> GetAll(IProductoHandler productoHandler)
    {
        return TypedResults.Ok(await productoHandler.GetAll());
    }
}