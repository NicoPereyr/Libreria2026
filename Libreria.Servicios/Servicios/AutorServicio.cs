
using Libreria.Datos.Interfaces;
using Libreria.Entidades.Autores;
using Libreria.Servicios.Interfaces;

namespace Libreria.Servicios.Servicios
{
    public class AutorServicio : IAutorServicio
    {
        private readonly IUnitOfWork _unitOfWork;

        public AutorServicio(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public List<Autor> ObtenerTodos()
        {
            return _unitOfWork.Autores.ObtenerTodos();
        }

        public Autor? ObtenerPorId(int id)
        {
            return _unitOfWork.Autores.ObtenerPorId(id);
        }

        public void Agregar(Autor autor)
        {
            _unitOfWork.Autores.Agregar(autor);
            _unitOfWork.Guardar();
        }

        public void Editar(Autor autor)
        {
            _unitOfWork.Autores.Editar(autor);
            _unitOfWork.Guardar();
        }

        public void Eliminar(int id)
        {
            var autor = _unitOfWork.Autores.ObtenerPorId(id);

            if (autor == null)
                throw new Exception("El autor no existe.");

            _unitOfWork.Autores.Eliminar(autor);
            _unitOfWork.Guardar();
        }
    }
}

