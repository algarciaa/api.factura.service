using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace api.service.factura.domain.clases;

[Table("pedidos", Schema = "poo")]
public partial class Pedido
{
    [Key]
    [Column("pedido_id")]
    public int PedidoId { get; set; }

    [Column("cliente_id")]
    public int ClienteId { get; set; }

    [Column("fecha", TypeName = "timestamp with time zone")]
    public DateTime? Fecha { get; set; }

    [Column("total")]
    public decimal? Total { get; set; }

    [Column("estado")]
    public bool? Estado { get; set; }

    [Column("fecha_insert", TypeName = "timestamp without time zone")]
    public DateTime? FechaInsert { get; set; }

    [Column("fecha_update", TypeName = "timestamp without time zone")]
    public DateTime? FechaUpdate { get; set; }

    [ForeignKey("ClienteId")]
    [InverseProperty("Pedidos")]
    public virtual Cliente Cliente { get; set; } = null!;

    [InverseProperty("Pedido")]
    public virtual ICollection<PedidoDetalle> PedidoDetalles { get; set; } = new List<PedidoDetalle>();
}
