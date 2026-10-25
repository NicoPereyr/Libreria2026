
using Libreria.Entidades.Editoriales;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Libreria.Datos.Configuraciones
{
    public class EditorialConfiguration
        : IEntityTypeConfiguration<Editorial>
    {
        public void Configure(EntityTypeBuilder<Editorial> builder)
        {
            builder.ToTable("Editoriales");

            builder.HasKey(e => e.EditorialId);

            builder.Property(e => e.Nombre)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(e => e.PaisOrigen)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(e => e.Activa)
                .IsRequired()
                .HasDefaultValue(true);
        }
    }
}

