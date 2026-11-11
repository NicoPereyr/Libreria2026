
using Libreria.Datos.DbContext;
using Libreria.Datos.Interfaces;
using Libreria.Entidades.Ventas;

namespace Libreria.Datos.Repositorios
{
    public class DetalleVentaRepositorio
        : Repositorio<DetalleVenta>, IDetalleVentaRepositorio
    {
        public DetalleVentaRepositorio(LibreriaDbContext context)
            : base(context)
        {
        }
    }
}
