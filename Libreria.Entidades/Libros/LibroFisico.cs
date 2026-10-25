namespace Libreria.Entidades.Libros
{
    public class LibroFisico : Libro
    {
        public string ISBN { get; set; } = string.Empty;

        public int Stock { get; set; }
    }
}
