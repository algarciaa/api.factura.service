namespace api.service.factura.application.commons.dtos;

public sealed record ProductoRequestDto(
    string Nombre,
    decimal Precio
);