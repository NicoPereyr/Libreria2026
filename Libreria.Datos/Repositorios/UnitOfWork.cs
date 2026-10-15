
using Libreria.Datos.DbContext;
using Libreria.Datos.Interfaces;

namespace Libreria.Datos.Repositorios
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly LibreriaDbContext _context;

        public IAutorRepositorio Autores { get; }
        public IEditorialRepositorio Editoriales { get; }
        public ITemaRepositorio Temas { get; }

        public UnitOfWork(
            LibreriaDbContext context,
            IAutorRepositorio autores,
            IEditorialRepositorio editoriales,
            ITemaRepositorio temas)
        {
            _context = context;
            Autores = autores;
            Editoriales = editoriales;
            Temas = temas;
        }

        public void Guardar()
        {
            _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
