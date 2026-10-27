
namespace Libreria.DTOs.Libros
{
    public class LibroListDto
    {
        public int LibroId { get; set; }

        public string Titulo { get; set; } = string.Empty;

        public string TipoLibro { get; set; } = string.Empty;

        public string Editorial { get; set; } = string.Empty;

        public int AnioPublicacion { get; set; }

        public decimal Precio { get; set; }

        public int? Stock { get; set; }

        public bool Activo { get; set; }

        public string Autores { get; set; } = string.Empty;

        public string Temas { get; set; } = string.Empty;
    }
}
