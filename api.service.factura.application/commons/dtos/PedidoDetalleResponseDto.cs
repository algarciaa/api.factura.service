namespace api.service.factura.application.commons.dtos;

public sealed record PedidoDetalleResponseDto(
    int DetalleId,
    int ProductoId,
    int Cantidad,
    decimal PrecioUnitario,
    decimal? Subtotal
);