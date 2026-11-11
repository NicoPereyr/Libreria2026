namespace Libreria.Datos.Interfaces
{
    public interface IUnitOfWork
    {
        IAutorRepositorio Autores { get; }
        IEditorialRepositorio Editoriales { get; }
        ITemaRepositorio Temas { get; }
        ILibroRepositorio Libros { get; }
        IClienteRepositorio Clientes { get; }
        IVentaRepositorio Ventas { get; }
        IDetalleVentaRepositorio DetalleVentas { get; }

        void Guardar();

        void Dispose();
    }
}

