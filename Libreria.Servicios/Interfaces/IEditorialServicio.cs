
using Libreria.Entidades.Editoriales;

namespace Libreria.Servicios.Interfaces
{
    public interface IEditorialServicio
    {
        List<Editorial> ObtenerTodas();
        Editorial? ObtenerPorId(int id);
        void Agregar(Editorial editorial);
        void Editar(Editorial editorial);
        void Eliminar(int id);
    }
}

