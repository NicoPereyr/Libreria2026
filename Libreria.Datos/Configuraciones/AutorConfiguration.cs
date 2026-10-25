using Libreria.Entidades.Autores;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Libreria.Datos.Configuraciones
{
    public class AutorConfiguration : IEntityTypeConfiguration<Autor>
    {
        public void Configure(EntityTypeBuilder<Autor> builder)
        {
            builder.ToTable("Autores");

            builder.HasKey(a => a.AutorId);

            builder.Property(a => a.Nombre)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(a => a.Apellido)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(a => a.FechaNacimiento)
                .IsRequired()
                .HasColumnType("date");

            builder.Property(a => a.Nacionalidad)
                .IsRequired()
                .HasMaxLength(50);
        }
    }
}
