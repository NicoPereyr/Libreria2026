
using Libreria.Datos.DbContext;
using Libreria.Datos.Interfaces;
using Libreria.Entidades.Ventas;

namespace Libreria.Datos.Repositorios
{
    public class VentaRepositorio
        : Repositorio<Venta>, IVentaRepositorio
    {
        public VentaRepositorio(LibreriaDbContext context)
            : base(context)
        {
        }
    }
}
