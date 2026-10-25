
using Libreria.Entidades.Libros;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Libreria.Datos.Configuraciones
{
    public class LibroConfiguration : IEntityTypeConfiguration<Libro>
    {
        public void Configure(EntityTypeBuilder<Libro> builder)
        {
            builder.ToTable("Libros");

            builder.HasKey(l => l.LibroId);

            builder.Property(l => l.Titulo)
                .IsRequired()
                .HasMaxLength(150);

            builder.Property(l => l.Descripcion)
                .IsRequired()
                .HasMaxLength(500);

            builder.Property(l => l.AnioPublicacion)
                .IsRequired();

            builder.Property(l => l.Precio)
                .HasPrecision(18, 2)
                .IsRequired();

            builder.Property(l => l.Activo)
                .IsRequired()
                .HasDefaultValue(true);

            // Cada libro pertenece a una editorial
            builder.HasOne(l => l.Editorial)
                .WithMany()
                .HasForeignKey(l => l.EditorialId)
                .OnDelete(DeleteBehavior.Restrict);

            // Relación muchos a muchos: Libros y Autores
            builder.HasMany(l => l.Autores)
                .WithMany()
                .UsingEntity(j => j.ToTable("LibrosAutores"));

            // Relación muchos a muchos: Libros y Temas
            builder.HasMany(l => l.Temas)
                .WithMany()
                .UsingEntity(j => j.ToTable("LibrosTemas"));

            // Herencia: una tabla para todos los tipos de libros
            builder.HasDiscriminator<string>("TipoLibro")
                .HasValue<LibroFisico>("Fisico")
                .HasValue<LibroDigital>("Digital");
        }
    }
}

