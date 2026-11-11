
using Libreria.Entidades.Clientes;

namespace Libreria.Entidades.Ventas
{
    public class Venta
    {
        public int VentaId { get; set; }

        public DateTime FechaVenta { get; set; } = DateTime.Now;

        public int ClienteId { get; set; }

        public Cliente Cliente { get; set; } = null!;

        public decimal Total { get; set; }

        public bool Anulada { get; set; } = false;

        public ICollection<DetalleVenta> Detalles { get; set; }
            = new List<DetalleVenta>();
    }
}
