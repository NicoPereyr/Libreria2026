
using Libreria.Entidades.Libros;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Libreria.Datos.Configuraciones
{
    public class LibroDigitalConfiguration
        : IEntityTypeConfiguration<LibroDigital>
    {
        public void Configure(EntityTypeBuilder<LibroDigital> builder)
        {
            builder.Property(l => l.IdentificadorDigital)
                .IsRequired()
                .HasMaxLength(50);

            builder.HasIndex(l => l.IdentificadorDigital)
                .IsUnique();

            builder.Property(l => l.Formato)
                .IsRequired()
                .HasMaxLength(20);

            builder.Property(l => l.TamanioMB)
                .HasPrecision(18, 2)
                .IsRequired();

            builder.Property(l => l.UrlDescarga)
                .IsRequired()
                .HasMaxLength(500);
        }
    }
}

