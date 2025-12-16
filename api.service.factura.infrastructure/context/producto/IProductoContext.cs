using api.service.factura.domain.clases;

namespace api.service.factura.infrastructure.context.producto;

public interface IProductoContext
{
    Task<List<Producto>> GetAllAsync();
}