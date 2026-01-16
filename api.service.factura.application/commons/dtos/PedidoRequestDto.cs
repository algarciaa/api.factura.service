namespace api.service.factura.application.commons.dtos;

public sealed record PedidoRequestDto(
    int ClienteId,
    DateTime? Fecha,
    List<PedidoDetalleRequestDto> PedidoDetalles
);