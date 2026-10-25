using Libreria.Entidades.Libros;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Libreria.Datos.Configuraciones
{
    public class LibroFisicoConfiguration
        : IEntityTypeConfiguration<LibroFisico>
    {
        public void Configure(EntityTypeBuilder<LibroFisico> builder)
        {
            builder.Property(l => l.ISBN)
                .IsRequired()
                .HasMaxLength(13);

            builder.HasIndex(l => l.ISBN)
                .IsUnique();

            builder.Property(l => l.Stock)
                .IsRequired();
        }
    }
}
