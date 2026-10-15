
using Libreria.Datos.DbContext;
using Libreria.Datos.Interfaces;
using Libreria.Entidades.Autores;

namespace Libreria.Datos.Repositorios
{
    public class AutorRepositorio
        : Repositorio<Autor>, IAutorRepositorio
    {
        public AutorRepositorio(LibreriaDbContext context)
            : base(context)
        {
        }
    }
}

