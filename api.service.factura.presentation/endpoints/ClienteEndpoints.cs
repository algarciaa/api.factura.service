using api.service.factura.application.ifeatures;

namespace api.service.factura.presentation.endpoints;

public static class ClienteEndpoints
{
    public static RouteGroupBuilder MapCliente(this RouteGroupBuilder builder)
    {
        builder.MapGet("/", GetAll);
        return builder;
    }

    private static async Task<IResult> GetAll(IClienteHandler clienteHandler)
    {
        return TypedResults.Ok(await clienteHandler.GetAll());
    }
}