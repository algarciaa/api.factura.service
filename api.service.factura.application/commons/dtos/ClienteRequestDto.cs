namespace api.service.factura.application.commons.dtos;

public sealed record ClienteRequestDto(
    string Nombre,
    string? Direccion,
    string? Telefono
);