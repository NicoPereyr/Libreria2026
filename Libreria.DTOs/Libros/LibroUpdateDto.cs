namespace Libreria.DTOs.Libros
{
    public abstract class LibroUpdateDto : LibroCreateDto
    {
        public int LibroId { get; set; }
    }
}
