
namespace Libreria.Datos.Interfaces
{
    public interface IRepositorio<T> where T : class
    {
        List<T> ObtenerTodos();

        T? ObtenerPorId(int id);

        void Agregar(T entidad);

        void Editar(T entidad);

        void Eliminar(T entidad);

        void Guardar();
    }
}

