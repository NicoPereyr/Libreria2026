
namespace Libreria.DTOs.Libros
{
    public abstract class LibroCreateDto
    {
        public string Titulo { get; set; } = string.Empty;

        public string Descripcion { get; set; } = string.Empty;

        public int AnioPublicacion { get; set; }

        public decimal Precio { get; set; }

        public bool Activo { get; set; } = true;

        public int EditorialId { get; set; }

        public List<int> AutoresIds { get; set; } = new();

        public List<int> TemasIds { get; set; } = new();
    }
}

