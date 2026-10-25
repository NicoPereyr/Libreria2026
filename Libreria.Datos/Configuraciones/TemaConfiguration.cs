using Libreria.Entidades.Temas;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Libreria.Datos.Configuraciones
{
    public class TemaConfiguration : IEntityTypeConfiguration<Tema>
    {
        public void Configure(EntityTypeBuilder<Tema> builder)
        {
            builder.ToTable("Temas");

            builder.HasKey(t => t.TemaId);

            builder.Property(t => t.Nombre)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(t => t.Descripcion)
                .IsRequired(false)
                .HasMaxLength(250);
        }
    }
}
