using api.service.factura.application.commons.dtos;

namespace api.service.factura.application.ifeatures;

public interface IClienteHandler
{
    Task<List<ClienteResponseDto>> GetAll();
}