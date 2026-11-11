
namespace Libreria.DTOs.Ventas
{
    public class VentaCreateDto
    {
        public int ClienteId { get; set; }

        public List<DetalleVentaDto> Detalles { get; set; }
            = new List<DetalleVentaDto>();
    }
}
