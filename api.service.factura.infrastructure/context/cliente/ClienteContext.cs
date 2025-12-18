using api.service.factura.domain.clases;

namespace api.service.factura.infrastructure.context.cliente;

public class ClienteContext : IClienteContext
{
    private readonly IContextGeneral<Cliente> _context;

    public ClienteContext(IContextGeneral<Cliente> context)
    {
        _context = context;
    }

    public async Task<List<Cliente>> GetAllAsync()
    {
        return await _context.GetAll();
    }

    public async Task<Cliente> GetByIdAsync(int id)
    { 
        Cliente cliente = await _context.GetById(id) ?? new Cliente();
        return cliente;
    }
}