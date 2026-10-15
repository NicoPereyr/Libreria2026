
using Libreria.Datos.DbContext;
using Libreria.Datos.Interfaces;
using Libreria.Entidades.Temas;

namespace Libreria.Datos.Repositorios
{
    public class TemaRepositorio
        : Repositorio<Tema>, ITemaRepositorio
    {
        public TemaRepositorio(LibreriaDbContext context)
            : base(context)
        {
        }
    }
}

