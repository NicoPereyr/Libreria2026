
using Libreria.DTOs.Ventas;
using Libreria.Entidades.Ventas;

namespace Libreria.Servicios.Interfaces
{
    public interface IVentaServicio
    {
        // Registrar una venta y devolver su identificador
        int RegistrarVenta(VentaCreateDto ventaDto);

        // Obtener todas las ventas registradas
        List<Venta> ObtenerTodos();

        // Consultar una venta por su identificador
        Venta? ObtenerPorId(int ventaId);

        // Anular una venta
        void AnularVenta(int ventaId);
    }
}
