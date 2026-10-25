
using Libreria.Entidades.Autores;
using Libreria.Entidades.Editoriales;
using Libreria.Entidades.Temas;

namespace Libreria.Entidades.Libros
{
    public abstract class Libro
    {
        public int LibroId { get; set; }

        public string Titulo { get; set; } = string.Empty;

        public string Descripcion { get; set; } = string.Empty;

        public int AnioPublicacion { get; set; }

        public decimal Precio { get; set; }

        public bool Activo { get; set; } = true;

        // Relación con Editorial
        public int EditorialId { get; set; }

        public Editorial Editorial { get; set; } = null!;

        // Relaciones con Autores y Temas
        public ICollection<Autor> Autores { get; set; }
            = new List<Autor>();

        public ICollection<Tema> Temas { get; set; }
            = new List<Tema>();
    }
}

