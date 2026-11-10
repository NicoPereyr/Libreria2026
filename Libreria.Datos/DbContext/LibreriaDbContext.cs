
using Libreria.Entidades.Autores;
using Libreria.Entidades.Editoriales;
using Libreria.Entidades.Temas;
using Microsoft.EntityFrameworkCore;
using Libreria.Entidades.Libros;
using Libreria.Entidades.Clientes;

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

        public DbSet<Cliente> Clientes { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(
                typeof(LibreriaDbContext).Assembly);

            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.ToTable("Clientes");

                entity.HasKey(c => c.ClienteId);

                entity.Property(c => c.Nombre)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(c => c.Apellido)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(c => c.Documento)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(c => c.Email)
                    .HasMaxLength(100);

                entity.Property(c => c.Telefono)
                    .HasMaxLength(30);

                entity.Property(c => c.Activo)
                    .HasDefaultValue(true);

                // Evitar documentos duplicados
                entity.HasIndex(c => c.Documento)
                    .IsUnique();
            });

        }
    }
}


