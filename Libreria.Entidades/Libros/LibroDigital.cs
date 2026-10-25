namespace Libreria.Entidades.Libros
{
    public class LibroDigital : Libro
    {
        public string IdentificadorDigital { get; set; } = string.Empty;

        public string Formato { get; set; } = string.Empty;

        public decimal TamanioMB { get; set; }

        public string UrlDescarga { get; set; } = string.Empty;
    }
}
