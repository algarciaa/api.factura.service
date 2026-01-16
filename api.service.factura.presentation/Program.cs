using api.service.factura.infrastructure;
using api.service.factura.application;
using api.service.factura.presentation.endpoints;


var builder = WebApplication.CreateBuilder(args);

var port = Environment.GetEnvironmentVariable("PORT") ?? "3000";
var url = $"http://0.0.0.0:{port}";

#region servicios
// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddPersistence(builder.Configuration);
builder.Services.AddApplicationServices();

#endregion servicios

var app = builder.Build();

#region middleware

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapGroup("/v1/cliente").MapCliente();
app.MapGroup("/v1/producto").MapProducto();
app.MapGroup("/v1/pedido").MapPedido();

#endregion middleware

app.Run(url);
