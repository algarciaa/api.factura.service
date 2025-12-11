using api.service.factura.infrastructure;
using api.service.factura.application;
using api.service.factura.presentation.endpoints;


var builder = WebApplication.CreateBuilder(args);

#region servicios
// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddPersistence(builder.Configuration);
builder.Services.AddApplicationServices();

#endregion servicios

var app = builder.Build();

#region middleware

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.MapGroup("/v1/cliente").MapCliente();

#endregion middleware

app.Run();
