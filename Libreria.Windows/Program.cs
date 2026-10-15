
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

            servicios.AddDbContext<LibreriaDbContext>(opciones =>
                opciones.UseSqlServer(
                    configuracion.GetConnectionString("LibreriaConnection")));

            servicios.AddScoped<IAutorRepositorio, AutorRepositorio>();
            servicios.AddScoped<IEditorialRepositorio, EditorialRepositorio>();
            servicios.AddScoped<ITemaRepositorio, TemaRepositorio>();

            servicios.AddScoped<IUnitOfWork, UnitOfWork>();

            servicios.AddScoped<IEditorialServicio, EditorialServicio>();
            servicios.AddTransient<frmEditoriales>();

            using var proveedor = servicios.BuildServiceProvider();
            using var alcance = proveedor.CreateScope();

            var formulario = alcance.ServiceProvider
                .GetRequiredService<frmEditoriales>();

            Application.Run(formulario);
        }
    }
}

