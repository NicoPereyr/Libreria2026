
using Libreria.Entidades.Libros;

namespace Libreria.Entidades.Ventas
{
    public class DetalleVenta
    {
        public int DetalleVentaId { get; set; }

        public int VentaId { get; set; }

        public Venta Venta { get; set; } = null!;

        public int LibroId { get; set; }

        public Libro Libro { get; set; } = null!;

        public int Cantidad { get; set; }

        public decimal PrecioUnitario { get; set; }

        public decimal Subtotal { get; set; }
    }
}
