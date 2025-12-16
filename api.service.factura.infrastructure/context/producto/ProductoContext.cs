using api.service.factura.domain.clases;

namespace api.service.factura.infrastructure.context.producto;

public class ProductoContext : IProductoContext
{
    private readonly IContextGeneral<Producto> _context;

    public ProductoContext(IContextGeneral<Producto> context)
    {
        _context = context;
    }

    public async Task<List<Producto>> GetAllAsync()
    {
        return await _context.GetAll();
    }
}