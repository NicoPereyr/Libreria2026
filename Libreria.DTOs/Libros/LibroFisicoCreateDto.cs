namespace Libreria.DTOs.Libros
{
    public class LibroFisicoCreateDto : LibroCreateDto
    {
        public string ISBN { get; set; } = string.Empty;

        public int Stock { get; set; }
    }
}