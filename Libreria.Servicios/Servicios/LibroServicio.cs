
using Libreria.Datos.Interfaces;
using Libreria.DTOs.Libros;
using Libreria.Entidades.Libros;
using Libreria.Servicios.Interfaces;
using Libreria.Servicios.Mappers;

namespace Libreria.Servicios.Servicios
{
    public class LibroServicio : ILibroServicio
    {
        private readonly IUnitOfWork _unitOfWork;

        public LibroServicio(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        public List<LibroListDto> ObtenerTodos()
        {
            var libros = _unitOfWork.Libros.ObtenerTodosConRelaciones();

            return libros
                .Select(libro => libro.ToListDto())
                .ToList();
        }



        public LibroFisicoUpdateDto? ObtenerFisicoParaEditar(int id)
        {
            // Obtener el libro con sus relaciones
            var libro = _unitOfWork.Libros.ObtenerPorIdConRelaciones(id);

            // Comprobar que exista y sea un libro físico
            if (libro is not LibroFisico libroFisico)
            {
                return null;
            }

            // Convertir la entidad en un DTO de edición
            return new LibroFisicoUpdateDto
            {
                LibroId = libroFisico.LibroId,
                Titulo = libroFisico.Titulo,
                Descripcion = libroFisico.Descripcion,
                AnioPublicacion = libroFisico.AnioPublicacion,
                Precio = libroFisico.Precio,
                Activo = libroFisico.Activo,
                EditorialId = libroFisico.EditorialId,

                ISBN = libroFisico.ISBN,
                Stock = libroFisico.Stock,

                AutoresIds = libroFisico.Autores
                    .Select(a => a.AutorId)
                    .ToList(),

                TemasIds = libroFisico.Temas
                    .Select(t => t.TemaId)
                    .ToList()
            };
        }



        public LibroDigitalUpdateDto? ObtenerDigitalParaEditar(int id)
        {
            // Obtener el libro con sus relaciones
            var libro = _unitOfWork.Libros.ObtenerPorIdConRelaciones(id);

            // Comprobar que exista y sea un libro digital
            if (libro is not LibroDigital libroDigital)
            {
                return null;
            }

            // Convertir la entidad en un DTO de edición
            return new LibroDigitalUpdateDto
            {
                LibroId = libroDigital.LibroId,
                Titulo = libroDigital.Titulo,
                Descripcion = libroDigital.Descripcion,
                AnioPublicacion = libroDigital.AnioPublicacion,
                Precio = libroDigital.Precio,
                Activo = libroDigital.Activo,
                EditorialId = libroDigital.EditorialId,

                IdentificadorDigital = libroDigital.IdentificadorDigital,
                Formato = libroDigital.Formato,
                TamanioMB = libroDigital.TamanioMB,
                UrlDescarga = libroDigital.UrlDescarga,

                AutoresIds = libroDigital.Autores
                    .Select(a => a.AutorId)
                    .ToList(),

                TemasIds = libroDigital.Temas
                    .Select(t => t.TemaId)
                    .ToList()
            };
        }



        public void AgregarFisico(LibroFisicoCreateDto dto)
        {
            // Comprobar que el ISBN no esté repetido
            if (_unitOfWork.Libros.ExisteISBN(dto.ISBN.Trim()))
            {
                throw new Exception("Ya existe un libro con ese ISBN.");
            }

            // Comprobar que exista la editorial
            var editorial = _unitOfWork.Editoriales.ObtenerPorId(dto.EditorialId);

            if (editorial == null)
            {
                throw new Exception("La editorial seleccionada no existe.");
            }

            // Convertir el DTO en una entidad
            var libro = dto.ToEntity();

            // Asignar los autores seleccionados
            foreach (var autorId in dto.AutoresIds.Distinct())
            {
                var autor = _unitOfWork.Autores.ObtenerPorId(autorId);

                if (autor == null)
                {
                    throw new Exception($"No existe el autor con ID {autorId}.");
                }

                libro.Autores.Add(autor);
            }

            // Asignar los temas seleccionados
            foreach (var temaId in dto.TemasIds.Distinct())
            {
                var tema = _unitOfWork.Temas.ObtenerPorId(temaId);

                if (tema == null)
                {
                    throw new Exception($"No existe el tema con ID {temaId}.");
                }

                libro.Temas.Add(tema);
            }

            // Agregar el libro
            _unitOfWork.Libros.Agregar(libro);

            // Guardar los cambios
            _unitOfWork.Guardar();
        }



        public void AgregarDigital(LibroDigitalCreateDto dto)
        {
            // Comprobar que el identificador digital no esté repetido
            if (_unitOfWork.Libros.ExisteIdentificadorDigital(
                dto.IdentificadorDigital.Trim()))
            {
                throw new Exception(
                    "Ya existe un libro con ese identificador digital.");
            }

            // Comprobar que exista la editorial
            var editorial = _unitOfWork.Editoriales.ObtenerPorId(dto.EditorialId);

            if (editorial == null)
            {
                throw new Exception("La editorial seleccionada no existe.");
            }

            // Convertir el DTO en una entidad
            var libro = dto.ToEntity();

            // Asignar los autores seleccionados
            foreach (var autorId in dto.AutoresIds.Distinct())
            {
                var autor = _unitOfWork.Autores.ObtenerPorId(autorId);

                if (autor == null)
                {
                    throw new Exception($"No existe el autor con ID {autorId}.");
                }

                libro.Autores.Add(autor);
            }

            // Asignar los temas seleccionados
            foreach (var temaId in dto.TemasIds.Distinct())
            {
                var tema = _unitOfWork.Temas.ObtenerPorId(temaId);

                if (tema == null)
                {
                    throw new Exception($"No existe el tema con ID {temaId}.");
                }

                libro.Temas.Add(tema);
            }

            // Agregar el libro digital
            _unitOfWork.Libros.Agregar(libro);

            // Guardar los cambios
            _unitOfWork.Guardar();
        }



        public void EditarFisico(LibroFisicoUpdateDto dto)
        {
            // Buscar el libro existente con sus relaciones
            var libro = _unitOfWork.Libros
                .ObtenerPorIdConRelaciones(dto.LibroId);

            // Comprobar que exista y sea físico
            if (libro is not LibroFisico libroFisico)
            {
                throw new Exception("El libro físico no existe.");
            }

            // Comprobar que el ISBN no pertenezca a otro libro
            if (_unitOfWork.Libros.ExisteISBN(
                dto.ISBN.Trim(), dto.LibroId))
            {
                throw new Exception("Ya existe otro libro con ese ISBN.");
            }

            // Comprobar que exista la editorial
            var editorial = _unitOfWork.Editoriales
                .ObtenerPorId(dto.EditorialId);

            if (editorial == null)
            {
                throw new Exception("La editorial seleccionada no existe.");
            }

            // Buscar los autores antes de modificar las relaciones
            var autores = dto.AutoresIds.Distinct()
                .Select(id => _unitOfWork.Autores.ObtenerPorId(id))
                .ToList();

            if (autores.Any(a => a == null))
            {
                throw new Exception("Uno o más autores no existen.");
            }

            // Buscar los temas antes de modificar las relaciones
            var temas = dto.TemasIds.Distinct()
                .Select(id => _unitOfWork.Temas.ObtenerPorId(id))
                .ToList();

            if (temas.Any(t => t == null))
            {
                throw new Exception("Uno o más temas no existen.");
            }

            // Actualizar las propiedades del libro
            dto.ToEntity(libroFisico);

            // Actualizar sus autores
            libroFisico.Autores.Clear();

            foreach (var autor in autores)
            {
                libroFisico.Autores.Add(autor!);
            }

            // Actualizar sus temas
            libroFisico.Temas.Clear();

            foreach (var tema in temas)
            {
                libroFisico.Temas.Add(tema!);
            }

            // Guardar los cambios
            _unitOfWork.Guardar();
        }



        public void EditarDigital(LibroDigitalUpdateDto dto)
        {
            // Buscar el libro existente con sus relaciones
            var libro = _unitOfWork.Libros
                .ObtenerPorIdConRelaciones(dto.LibroId);

            // Comprobar que exista y sea digital
            if (libro is not LibroDigital libroDigital)
            {
                throw new Exception("El libro digital no existe.");
            }

            // Comprobar que el identificador no pertenezca a otro libro
            if (_unitOfWork.Libros.ExisteIdentificadorDigital(
                dto.IdentificadorDigital.Trim(), dto.LibroId))
            {
                throw new Exception(
                    "Ya existe otro libro con ese identificador digital.");
            }

            // Comprobar que exista la editorial
            var editorial = _unitOfWork.Editoriales
                .ObtenerPorId(dto.EditorialId);

            if (editorial == null)
            {
                throw new Exception("La editorial seleccionada no existe.");
            }

            // Buscar los autores antes de modificar las relaciones
            var autores = dto.AutoresIds.Distinct()
                .Select(id => _unitOfWork.Autores.ObtenerPorId(id))
                .ToList();

            if (autores.Any(a => a == null))
            {
                throw new Exception("Uno o más autores no existen.");
            }

            // Buscar los temas antes de modificar las relaciones
            var temas = dto.TemasIds.Distinct()
                .Select(id => _unitOfWork.Temas.ObtenerPorId(id))
                .ToList();

            if (temas.Any(t => t == null))
            {
                throw new Exception("Uno o más temas no existen.");
            }

            // Actualizar las propiedades del libro digital
            dto.ToEntity(libroDigital);

            // Actualizar los autores
            libroDigital.Autores.Clear();

            foreach (var autor in autores)
            {
                libroDigital.Autores.Add(autor!);
            }

            // Actualizar los temas
            libroDigital.Temas.Clear();

            foreach (var tema in temas)
            {
                libroDigital.Temas.Add(tema!);
            }

            // Guardar los cambios
            _unitOfWork.Guardar();
        }



        public void Eliminar(int id)
        {
            // Buscar el libro existente
            var libro = _unitOfWork.Libros
                .ObtenerPorIdConRelaciones(id);

            // Comprobar que exista
            if (libro == null)
            {
                throw new Exception("El libro seleccionado no existe.");
            }

            // Eliminar las relaciones con autores y temas
            libro.Autores.Clear();
            libro.Temas.Clear();

            // Eliminar el libro
            _unitOfWork.Libros.Eliminar(libro);

            // Guardar los cambios
            _unitOfWork.Guardar();
        }

    }
}

