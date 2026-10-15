
using Libreria.Datos.Interfaces;
using Libreria.Entidades.Editoriales;
using Libreria.Servicios.Interfaces;

namespace Libreria.Servicios.Servicios
{
    public class EditorialServicio : IEditorialServicio
    {
        private readonly IUnitOfWork _unitOfWork;

        public EditorialServicio(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public List<Editorial> ObtenerTodas()
        {
            return _unitOfWork.Editoriales.ObtenerTodos();
        }

        public Editorial? ObtenerPorId(int id)
        {
            return _unitOfWork.Editoriales.ObtenerPorId(id);
        }

        public void Agregar(Editorial editorial)
        {
            _unitOfWork.Editoriales.Agregar(editorial);
            _unitOfWork.Guardar();
        }

        public void Editar(Editorial editorial)
        {
            _unitOfWork.Editoriales.Editar(editorial);
            _unitOfWork.Guardar();
        }

        public void Eliminar(int id)
        {
            var editorial = _unitOfWork.Editoriales.ObtenerPorId(id);

            if (editorial == null)
                throw new Exception("La editorial no existe.");

            _unitOfWork.Editoriales.Eliminar(editorial);
            _unitOfWork.Guardar();
        }
    }
}

