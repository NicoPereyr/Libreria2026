
using Libreria.Datos.Interfaces;
using Libreria.Entidades.Temas;
using Libreria.Servicios.Interfaces;

namespace Libreria.Servicios.Servicios
{
    public class TemaServicio : ITemaServicio
    {
        private readonly IUnitOfWork _unitOfWork;

        public TemaServicio(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public List<Tema> ObtenerTodos()
        {
            return _unitOfWork.Temas.ObtenerTodos();
        }

        public Tema? ObtenerPorId(int id)
        {
            return _unitOfWork.Temas.ObtenerPorId(id);
        }

        public void Agregar(Tema tema)
        {
            _unitOfWork.Temas.Agregar(tema);
            _unitOfWork.Guardar();
        }

        public void Editar(Tema tema)
        {
            _unitOfWork.Temas.Editar(tema);
            _unitOfWork.Guardar();
        }

        public void Eliminar(int id)
        {
            var tema = _unitOfWork.Temas.ObtenerPorId(id);

            if (tema == null)
                throw new Exception("El tema no existe.");

            _unitOfWork.Temas.Eliminar(tema);
            _unitOfWork.Guardar();
        }
    }
}
