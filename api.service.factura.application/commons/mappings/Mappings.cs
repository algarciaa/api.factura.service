using api.service.factura.application.commons.dtos;
using api.service.factura.domain.clases;
using Riok.Mapperly.Abstractions;

namespace api.service.factura.application.commons.mappings;

[Mapper]
public partial class Mappings
{
    public partial ClienteResponseDto ToResponseDto(Cliente cliente);
    public partial List<ClienteResponseDto> ToResponseDto(List<Cliente> clientes);
    public partial ProductoResponseDto ToResponseDto(Producto produto);
    public partial List<ProductoResponseDto> ToResponseDto(List<Producto> productos);

    public partial Cliente ToRequestDto(ClienteRequestDto clienteRequestDto);
    public partial Producto ToRequestDto(ProductoRequestDto productoRequestDto);
}