
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
        public ILibroRepositorio Libros { get; }
        public IClienteRepositorio Clientes { get; }

        public UnitOfWork(
            LibreriaDbContext context,
            IAutorRepositorio autores,
            IEditorialRepositorio editoriales,
            ITemaRepositorio temas,
            ILibroRepositorio libroRepositorio,
            IClienteRepositorio clienteRepositorio)
        {
            _context = context;
            Autores = autores;
            Editoriales = editoriales;
            Temas = temas;
            Libros = libroRepositorio;
            Clientes = clienteRepositorio;
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
