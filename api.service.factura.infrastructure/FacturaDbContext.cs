using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using api.service.factura.domain.clases;

namespace api.service.factura.infrastructure;

public partial class FacturaDbContext : DbContext
{
    public FacturaDbContext(DbContextOptions<FacturaDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Cliente> Clientes { get; set; }

    public virtual DbSet<Pedido> Pedidos { get; set; }

    public virtual DbSet<PedidoDetalle> PedidoDetalles { get; set; }

    public virtual DbSet<Producto> Productos { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .HasPostgresEnum("auth", "aal_level", new[] { "aal1", "aal2", "aal3" })
            .HasPostgresEnum("auth", "code_challenge_method", new[] { "s256", "plain" })
            .HasPostgresEnum("auth", "factor_status", new[] { "unverified", "verified" })
            .HasPostgresEnum("auth", "factor_type", new[] { "totp", "webauthn", "phone" })
            .HasPostgresEnum("auth", "oauth_authorization_status", new[] { "pending", "approved", "denied", "expired" })
            .HasPostgresEnum("auth", "oauth_client_type", new[] { "public", "confidential" })
            .HasPostgresEnum("auth", "oauth_registration_type", new[] { "dynamic", "manual" })
            .HasPostgresEnum("auth", "oauth_response_type", new[] { "code" })
            .HasPostgresEnum("auth", "one_time_token_type", new[] { "confirmation_token", "reauthentication_token", "recovery_token", "email_change_token_new", "email_change_token_current", "phone_change_token" })
            .HasPostgresEnum("realtime", "action", new[] { "INSERT", "UPDATE", "DELETE", "TRUNCATE", "ERROR" })
            .HasPostgresEnum("realtime", "equality_op", new[] { "eq", "neq", "lt", "lte", "gt", "gte", "in" })
            .HasPostgresEnum("storage", "buckettype", new[] { "STANDARD", "ANALYTICS", "VECTOR" })
            .HasPostgresExtension("extensions", "pg_stat_statements")
            .HasPostgresExtension("extensions", "pgcrypto")
            .HasPostgresExtension("extensions", "uuid-ossp")
            .HasPostgresExtension("graphql", "pg_graphql")
            .HasPostgresExtension("vault", "supabase_vault");

        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.HasKey(e => e.ClienteId).HasName("clientes_pkey");

            entity.Property(e => e.Estado).HasDefaultValue(true);
            entity.Property(e => e.FechaInsert).HasDefaultValueSql("now()");
        });

        modelBuilder.Entity<Pedido>(entity =>
        {
            entity.HasKey(e => e.PedidoId).HasName("pedidos_pkey");

            entity.Property(e => e.Estado).HasDefaultValue(true);
            entity.Property(e => e.Fecha).HasDefaultValueSql("now()");
            entity.Property(e => e.FechaInsert).HasDefaultValueSql("now()");
            entity.Property(e => e.Total).HasDefaultValueSql("0");

            entity.HasOne(d => d.Cliente).WithMany(p => p.Pedidos)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_pedido_cliente");
        });

        modelBuilder.Entity<PedidoDetalle>(entity =>
        {
            entity.HasKey(e => e.DetalleId).HasName("pedido_detalle_pkey");

            entity.Property(e => e.Estado).HasDefaultValue(true);
            entity.Property(e => e.FechaInsert).HasDefaultValueSql("now()");
            entity.Property(e => e.Subtotal).HasComputedColumnSql("((cantidad)::numeric * precio_unitario)", true);

            entity.HasOne(d => d.Pedido).WithMany(p => p.PedidoDetalles).HasConstraintName("fk_detalle_pedido");

            entity.HasOne(d => d.Producto).WithMany(p => p.PedidoDetalles)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_detalle_producto");
        });

        modelBuilder.Entity<Producto>(entity =>
        {
            entity.HasKey(e => e.ProductoId).HasName("productos_pkey");

            entity.Property(e => e.Estado).HasDefaultValue(true);
            entity.Property(e => e.FechaInsert).HasDefaultValueSql("now()");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
