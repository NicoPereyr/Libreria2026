
using Libreria.Datos.DbContext;
using Libreria.Datos.Interfaces;
using Libreria.Datos.Repositorios;
using Libreria.Servicios.Interfaces;
using Libreria.Servicios.Servicios;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Libreria.Windows
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            IConfiguration configuracion = new ConfigurationBuilder()
                .SetBasePath(AppContext.BaseDirectory)
                .AddJsonFile("appsettings.json", optional: false)
                .Build();

            var servicios = new ServiceCollection();

            // Configuración de base de datos
            servicios.AddDbContext<LibreriaDbContext>(opciones =>
                opciones.UseSqlServer(
                    configuracion.GetConnectionString("LibreriaConnection")));

            // Repositorios
            servicios.AddScoped<IAutorRepositorio, AutorRepositorio>();
            servicios.AddScoped<IEditorialRepositorio, EditorialRepositorio>();
            servicios.AddScoped<ITemaRepositorio, TemaRepositorio>();

            // Unit of Work
            servicios.AddScoped<IUnitOfWork, UnitOfWork>();

            // Servicios
            servicios.AddScoped<IEditorialServicio, EditorialServicio>();
            servicios.AddScoped<IAutorServicio, AutorServicio>();

            // Formularios
            servicios.AddTransient<frmPrincipal>();
            servicios.AddTransient<frmEditoriales>();
            servicios.AddTransient<frmAutores>();

            using var proveedor = servicios.BuildServiceProvider();
            using var alcance = proveedor.CreateScope();

            // Abrir el menú principal
            var formulario = alcance.ServiceProvider
                .GetRequiredService<frmPrincipal>();

            Application.Run(formulario);
        }
    }
}


