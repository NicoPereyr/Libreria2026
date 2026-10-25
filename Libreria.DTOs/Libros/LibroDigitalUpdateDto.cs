namespace Libreria.DTOs.Libros
{
    public class LibroDigitalUpdateDto : LibroUpdateDto
    {
        public string IdentificadorDigital { get; set; } = string.Empty;

        public string Formato { get; set; } = string.Empty;

        public decimal TamanioMB { get; set; }

        public string UrlDescarga { get; set; } = string.Empty;
    }
}
