
using Libreria.Datos.DbContext;
using Libreria.Datos.Interfaces;
using Libreria.Entidades.Clientes;

namespace Libreria.Datos.Repositorios
{
    public class ClienteRepositorio
        : Repositorio<Cliente>, IClienteRepositorio
    {
        public ClienteRepositorio(LibreriaDbContext context)
            : base(context)
        {
        }
    }
}
