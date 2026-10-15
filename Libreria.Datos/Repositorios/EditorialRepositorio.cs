
using Libreria.Datos.DbContext;
using Libreria.Datos.Interfaces;
using Libreria.Entidades.Editoriales;

namespace Libreria.Datos.Repositorios
{
    public class EditorialRepositorio
        : Repositorio<Editorial>, IEditorialRepositorio
    {
        public EditorialRepositorio(LibreriaDbContext context)
            : base(context)
        {
        }
    }
}

