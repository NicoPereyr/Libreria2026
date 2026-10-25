
using Libreria.DTOs.Libros;

namespace Libreria.Servicios.Interfaces
{
    public interface ILibroServicio
    {
        List<LibroListDto> ObtenerTodos();

        LibroFisicoUpdateDto? ObtenerFisicoParaEditar(int id);

        LibroDigitalUpdateDto? ObtenerDigitalParaEditar(int id);

        void AgregarFisico(LibroFisicoCreateDto dto);

        void AgregarDigital(LibroDigitalCreateDto dto);

        void EditarFisico(LibroFisicoUpdateDto dto);

        void EditarDigital(LibroDigitalUpdateDto dto);

        void Eliminar(int id);
    }
}

