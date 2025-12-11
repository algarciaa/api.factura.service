using api.service.factura.application.commons.dtos;
using api.service.factura.application.commons.mappings;
using api.service.factura.application.ifeatures;
using api.service.factura.infrastructure.context.cliente;

namespace api.service.factura.application.features;

class ClienteHandler : IClienteHandler
{
    private readonly Mappings _mapper;
    private readonly IClienteContext _context;

    public ClienteHandler(IClienteContext context)
    {
        _mapper = new Mappings();
        _context = context;
    }

    public async Task<List<ClienteResponseDto>> GetAll()
    {
        var clientes = await _context.GetAllAsync();
        return _mapper.ToResponseDto(clientes);
    }
}