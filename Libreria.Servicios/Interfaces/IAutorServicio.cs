
using Libreria.Entidades.Autores;

namespace Libreria.Servicios.Interfaces
{
    public interface IAutorServicio
    {
        List<Autor> ObtenerTodos();
        Autor? ObtenerPorId(int id);
        void Agregar(Autor autor);
        void Editar(Autor autor);
        void Eliminar(int id);
    }

}

