using api.service.factura.application.ifeatures;

namespace api.service.factura.presentation.endpoints;

public static class ProductoEndpoints
{
    public static RouteGroupBuilder MapProducto(this RouteGroupBuilder builder)
    {
        builder.MapGet("/", GetAll);
        return builder;
    }

    private static async Task<IResult> GetAll(IProductoHandler productoHandler)
    {
        return TypedResults.Ok(await productoHandler.GetAll());
    }
}