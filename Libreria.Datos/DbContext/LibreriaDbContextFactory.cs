
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Libreria.Datos.DbContext
{
    public class LibreriaDbContextFactory
        : IDesignTimeDbContextFactory<LibreriaDbContext>
    {
        public LibreriaDbContext CreateDbContext(string[] args)
        {
            var opciones = new DbContextOptionsBuilder<LibreriaDbContext>();

            opciones.UseSqlServer(
                @"Data Source=.\SQLEXPRESS;Initial Catalog=Libreria2026;Integrated Security=True;TrustServerCertificate=True");

            return new LibreriaDbContext(opciones.Options);
        }
    }
}

