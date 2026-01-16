namespace api.service.factura.application.commons.dtos;

public sealed record PedidoResponseDto(
    int PedidoId,
    int ClienteId,
    DateTime? Fecha,
    decimal? Total,
    List<PedidoDetalleResponseDto> PedidoDetalles
);

/*
Microsoft.EntityFrameworkCore.DbUpdateException: An error occurred while saving the entity changes. See the inner exception for details.
 ---> System.ArgumentException: Cannot write DateTime with Kind=UTC to PostgreSQL type 'timestamp without time zone', consider using 'timestamp with time zone'. Note that it's not possible to mix DateTimes with different Kinds in an array, range, or multirange. (Parameter 'value')
   at Npgsql.Internal.Converters.DateTimeConverterResolver`1.Get(DateTime value, Nullable`1 expectedPgTypeId, Boolean validateOnly)
   at Npgsql.Internal.Converters.DateTimeConverterResolver.<>c.<CreateResolver>b__0_0(DateTimeConverterResolver`1 resolver, DateTime value, Nullable`1 expectedPgTypeId)
   at Npgsql.Internal.Converters.DateTimeConverterResolver`1.Get(T value, Nullable`1 expectedPgTypeId)
   at Npgsql.Internal.PgConverterResolver`1.GetAsObjectInternal(PgTypeInfo typeInfo, Object value, Nullable`1 expectedPgTypeId)
   at Npgsql.Internal.PgResolverTypeInfo.GetResolutionAsObject(Object value, Nullable`1 expectedPgTypeId)
   at Npgsql.Internal.PgTypeInfo.GetObjectResolution(Object value)
   at Npgsql.NpgsqlParameter.ResolveConverter(PgTypeInfo typeInfo)
   at Npgsql.NpgsqlParameter.ResolveTypeInfo(PgSerializerOptions options)
   at Npgsql.NpgsqlParameterCollection.ProcessParameters(PgSerializerOptions options, Boolean validateValues, CommandType commandType)
   at Npgsql.NpgsqlCommand.ExecuteReader(Boolean async, CommandBehavior behavior, CancellationToken cancellationToken)
   at Npgsql.NpgsqlCommand.ExecuteReader(Boolean async, CommandBehavior behavior, CancellationToken cancellationToken)
   at Npgsql.NpgsqlCommand.ExecuteDbDataReaderAsync(CommandBehavior behavior, CancellationToken cancellationToken)
   at Microsoft.EntityFrameworkCore.Storage.RelationalCommand.ExecuteReaderAsync(RelationalCommandParameterObject parameterObject, CancellationToken cancellationToken)
   at Microsoft.EntityFrameworkCore.Storage.RelationalCommand.ExecuteReaderAsync(RelationalCommandParameterObject parameterObject, CancellationToken cancellationToken)
   at Microsoft.EntityFrameworkCore.Update.ReaderModificationCommandBatch.ExecuteAsync(IRelationalConnection connection, CancellationToken cancellationToken)
   --- End of inner exception stack trace ---
   at Microsoft.EntityFrameworkCore.Update.ReaderModificationCommandBatch.ExecuteAsync(IRelationalConnection connection, CancellationToken cancellationToken)
   at Microsoft.EntityFrameworkCore.Update.Internal.BatchExecutor.ExecuteAsync(IEnumerable`1 commandBatches, IRelationalConnection connection, CancellationToken cancellationToken)
   at Microsoft.EntityFrameworkCore.Update.Internal.BatchExecutor.ExecuteAsync(IEnumerable`1 commandBatches, IRelationalConnection connection, CancellationToken cancellationToken)
   at Microsoft.EntityFrameworkCore.Update.Internal.BatchExecutor.ExecuteAsync(IEnumerable`1 commandBatches, IRelationalConnection connection, CancellationToken cancellationToken)
   at Microsoft.EntityFrameworkCore.Storage.RelationalDatabase.SaveChangesAsync(IList`1 entries, CancellationToken cancellationToken)
   at Microsoft.EntityFrameworkCore.ChangeTracking.Internal.StateManager.SaveChangesAsync(IList`1 entriesToSave, CancellationToken cancellationToken)
   at Microsoft.EntityFrameworkCore.ChangeTracking.Internal.StateManager.SaveChangesAsync(StateManager stateManager, Boolean acceptAllChangesOnSuccess, CancellationToken cancellationToken)
   at Microsoft.EntityFrameworkCore.Storage.ExecutionStrategy.<>c__DisplayClass30_0`2.<<ExecuteAsync>b__0>d.MoveNext()
--- End of stack trace from previous location ---
   at Microsoft.EntityFrameworkCore.Storage.ExecutionStrategy.ExecuteImplementationAsync[TState,TResult](Func`4 operation, Func`4 verifySucceeded, TState state, CancellationToken cancellationToken)
   at Microsoft.EntityFrameworkCore.Storage.ExecutionStrategy.ExecuteImplementationAsync[TState,TResult](Func`4 operation, Func`4 verifySucceeded, TState state, CancellationToken cancellationToken)
   at Microsoft.EntityFrameworkCore.Storage.ExecutionStrategy.ExecuteAsync[TState,TResult](TState state, Func`4 operation, Func`4 verifySucceeded, CancellationToken cancellationToken)
   at Microsoft.EntityFrameworkCore.DbContext.SaveChangesAsync(Boolean acceptAllChangesOnSuccess, CancellationToken cancellationToken)
   at Microsoft.EntityFrameworkCore.DbContext.SaveChangesAsync(Boolean acceptAllChangesOnSuccess, CancellationToken cancellationToken)
   at api.service.factura.infrastructure.context.ContextGeneral`1.Add(T entity) in /home/user/apifacturaservice/api.service.factura.infrastructure/context/ContextGeneral.cs:line 28
   at api.service.factura.infrastructure.context.pedido.PedidoContext.InsertAsync(Pedido pedido) in /home/user/apifacturaservice/api.service.factura.infrastructure/context/pedido/PedidoContext.cs:line 40
   at api.service.factura.application.features.PedidoHandler.Insert(PedidoRequestDto pedidoRequest) in /home/user/apifacturaservice/api.service.factura.application/features/PedidoHandler.cs:line 23
   at api.service.factura.presentation.endpoints.PedidoEndpoints.Insert(PedidoRequestDto pedidoRequest, IPedidoHandler pedidoHandler) in /home/user/apifacturaservice/api.service.factura.presentation/endpoints/PedidoEndpoints.cs:line 19
   at Microsoft.AspNetCore.Http.RequestDelegateFactory.ExecuteTaskResult[T](Task`1 task, HttpContext httpContext)
   at Microsoft.AspNetCore.Http.RequestDelegateFactory.<>c__DisplayClass101_2.<<HandleRequestBodyAndCompileRequestDelegateForJson>b__2>d.MoveNext()
--- End of stack trace from previous location ---
   at Swashbuckle.AspNetCore.SwaggerUI.SwaggerUIMiddleware.Invoke(HttpContext httpContext)
   at Swashbuckle.AspNetCore.Swagger.SwaggerMiddleware.Invoke(HttpContext httpContext, ISwaggerProvider swaggerProvider)
   at Microsoft.AspNetCore.Diagnostics.DeveloperExceptionPageMiddlewareImpl.Invoke(HttpContext context)

HEADERS
=======
Accept: application/json
Host: 127.0.0.1:3000
User-Agent: Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/143.0.0.0 Safari/537.36
Accept-Encoding: gzip, deflate, br, zstd
Accept-Language: es-ES,es;q=0.9
Content-Type: application/json
Origin: https://3000-firebase-apifacturaservice-1765066358956.cluster-lqzyk3r5hzdcaqv6zwm7wv6pwa.cloudworkstations.dev
Referer: https://3000-firebase-apifacturaservice-1765066358956.cluster-lqzyk3r5hzdcaqv6zwm7wv6pwa.cloudworkstations.dev/swagger/index.html
Content-Length: 169
Priority: u=1, i
Sec-Ch-Ua: "Google Chrome";v="143", "Chromium";v="143", "Not A(Brand";v="24"
Sec-Ch-Ua-Mobile: ?0
Sec-Ch-Ua-Platform: "Windows"
Sec-Fetch-Dest: empty
Sec-Fetch-Mode: cors
Sec-Fetch-Site: same-origin
Sec-User-Ip: 10.20.20.212
X-Forwarded-Host: 3000-firebase-apifacturaservice-1765066358956.cluster-lqzyk3r5hzdcaqv6zwm7wv6pwa.cloudworkstations.dev
X-Goog-Workstations-Endpoint: workstations-cff9fe9f-2abb-4414-9092-69fc0598d42e.us-central1-c.c.monospace-15.internal.:980
*/