using api.service.factura.domain.clases;

namespace api.service.factura.infrastructure.context.cliente;


public interface IClienteContext
{
    Task<List<Cliente>> GetAllAsync();
    Task<Cliente?> GetByIdAsync(int id);
}