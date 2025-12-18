using api.service.factura.application.ifeatures;

namespace api.service.factura.presentation.endpoints;

public static class ClienteEndpoints
{
    public static RouteGroupBuilder MapCliente(this RouteGroupBuilder builder)
    {
        builder.MapGet("/", GetAll);
        builder.MapGet("/:id", GetById);
        return builder;
    }

    private static async Task<IResult> GetAll(IClienteHandler clienteHandler)
    {
        return TypedResults.Ok(await clienteHandler.GetAll());
    }

    private static async Task<IResult> GetById(int id, IClienteHandler clienteHandler)
    {
        var cliente = await clienteHandler.GetById(id);
        if (cliente.ClienteId == 0)
        {
            return TypedResults.NotFound();
        }
        return TypedResults.Ok(cliente);
    }
}