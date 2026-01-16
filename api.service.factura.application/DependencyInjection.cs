using api.service.factura.application.features;
using api.service.factura.application.ifeatures;
using Microsoft.Extensions.DependencyInjection;

namespace api.service.factura.application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddScoped<IClienteHandler, ClienteHandler>();
        services.AddScoped<IProductoHandler, ProductoHandler>();
        services.AddScoped<IPedidoHandler, PedidoHandler>();

        return services;
    }
}