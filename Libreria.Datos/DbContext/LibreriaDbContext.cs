
using Libreria.Entidades.Autores;
using Libreria.Entidades.Editoriales;
using Libreria.Entidades.Temas;
using Microsoft.EntityFrameworkCore;

namespace Libreria.Datos.DbContext
{
    public class LibreriaDbContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public LibreriaDbContext(
            DbContextOptions<LibreriaDbContext> options)
            : base(options)
        {
        }

        public DbSet<Autor> Autores { get; set; } = null!;

        public DbSet<Editorial> Editoriales { get; set; } = null!;

        public DbSet<Tema> Temas { get; set; } = null!;
    }
}


