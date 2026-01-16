namespace api.service.factura.application.commons.dtos;

public sealed record PedidoDetalleRequestDto(
    int ProductoId,
    int Cantidad,
    decimal PrecioUnitario
);