
namespace Libreria.Windows.Modelos
{
    public class DetalleCarrito
    {
        public int LibroId { get; set; }

        public string Titulo { get; set; } = string.Empty;

        public int Cantidad { get; set; }

        public decimal PrecioUnitario { get; set; }

        public decimal Subtotal => Cantidad * PrecioUnitario;
    }
}
