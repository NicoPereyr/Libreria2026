using Libreria.Entidades.Libros;

namespace Libreria.Datos.Interfaces
{
    public interface ILibroRepositorio : IRepositorio<Libro>
    {
        List<Libro> ObtenerTodosConRelaciones();

        Libro? ObtenerPorIdConRelaciones(int id);

        bool ExisteISBN(string isbn, int? libroId = null);

        bool ExisteIdentificadorDigital(
            string identificador, int? libroId = null);
    }
}
