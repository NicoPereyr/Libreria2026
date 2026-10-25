
using Libreria.Entidades.Autores;
using Libreria.Entidades.Editoriales;
using Libreria.Entidades.Temas;
using Microsoft.EntityFrameworkCore;
using Libreria.Entidades.Libros;

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

        public DbSet<Libro> Libros { get; set; } = null!;

        public DbSet<LibroFisico> LibrosFisicos { get; set; } = null!;

        public DbSet<LibroDigital> LibrosDigitales { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(
                typeof(LibreriaDbContext).Assembly);
        }
    }
}


