using Libreria.Entidades.Temas;

namespace Libreria.Servicios.Interfaces
{
    public interface ITemaServicio
    {
        List<Tema> ObtenerTodos();
        Tema? ObtenerPorId(int id);
        void Agregar(Tema tema);
        void Editar(Tema tema);
        void Eliminar(int id);
    }
}
