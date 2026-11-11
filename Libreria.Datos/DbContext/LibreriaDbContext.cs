
using Libreria.Entidades.Autores;
using Libreria.Entidades.Editoriales;
using Libreria.Entidades.Temas;
using Microsoft.EntityFrameworkCore;
using Libreria.Entidades.Libros;
using Libreria.Entidades.Clientes;
using Libreria.Entidades.Ventas;

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
        public DbSet<Venta> Ventas { get; set; }
        public DbSet<DetalleVenta> DetalleVentas { get; set; }


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

            modelBuilder.Entity<Venta>(entity =>
            {
                entity.ToTable("Ventas");

                entity.HasKey(v => v.VentaId);

                entity.Property(v => v.FechaVenta)
                    .IsRequired();

                entity.Property(v => v.Total)
                    .HasColumnType("decimal(18,2)");

                entity.Property(v => v.Anulada)
                    .HasDefaultValue(false);

                // Relación Venta -> Cliente
                entity.HasOne(v => v.Cliente)
                    .WithMany()
                    .HasForeignKey(v => v.ClienteId)
                    .OnDelete(DeleteBehavior.Restrict);

                // Relación Venta -> DetalleVentas
                entity.HasMany(v => v.Detalles)
                    .WithOne(d => d.Venta)
                    .HasForeignKey(d => d.VentaId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<DetalleVenta>(entity =>
            {
                entity.ToTable("DetalleVentas");

                entity.HasKey(d => d.DetalleVentaId);

                entity.Property(d => d.Cantidad)
                    .IsRequired();

                entity.Property(d => d.PrecioUnitario)
                    .HasColumnType("decimal(18,2)");

                entity.Property(d => d.Subtotal)
                    .HasColumnType("decimal(18,2)");

                // Relación DetalleVenta -> Libro
                entity.HasOne(d => d.Libro)
                    .WithMany()
                    .HasForeignKey(d => d.LibroId)
                    .OnDelete(DeleteBehavior.Restrict);
            });


        }
    }
}


