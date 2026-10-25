
using Libreria.Datos.DbContext;
using Libreria.Datos.Interfaces;
using Libreria.Entidades.Libros;
using Microsoft.EntityFrameworkCore;

namespace Libreria.Datos.Repositorios
{
    public class LibroRepositorio : Repositorio<Libro>, ILibroRepositorio
    {
        private readonly LibreriaDbContext _context;

        public LibroRepositorio(LibreriaDbContext context)
            : base(context)
        {
            _context = context;
        }

        public List<Libro> ObtenerTodosConRelaciones()
        {
            return _context.Libros
                .Include(l => l.Editorial)
                .Include(l => l.Autores)
                .Include(l => l.Temas)
                .AsNoTracking()
                .ToList();
        }

        public Libro? ObtenerPorIdConRelaciones(int id)
        {
            return _context.Libros
                .Include(l => l.Editorial)
                .Include(l => l.Autores)
                .Include(l => l.Temas)
                .FirstOrDefault(l => l.LibroId == id);
        }

        public bool ExisteISBN(string isbn, int? libroId = null)
        {
            return _context.LibrosFisicos
                .Any(l => l.ISBN == isbn &&
                    (!libroId.HasValue || l.LibroId != libroId.Value));
        }

        public bool ExisteIdentificadorDigital(
            string identificador, int? libroId = null)
        {
            return _context.LibrosDigitales
                .Any(l => l.IdentificadorDigital == identificador &&
                    (!libroId.HasValue || l.LibroId != libroId.Value));
        }
    }
}

