namespace Libreria.DTOs.Libros
{
    public class LibroFisicoUpdateDto : LibroUpdateDto
    {
        public string ISBN { get; set; } = string.Empty;

        public int Stock { get; set; }
    }
}
