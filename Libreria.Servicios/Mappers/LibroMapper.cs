using Libreria.DTOs.Libros;
using Libreria.Entidades.Libros;

namespace Libreria.Servicios.Mappers
{
    public static class LibroMapper
    {
        public static LibroFisico ToEntity(
            this LibroFisicoCreateDto dto)
        {
            return new LibroFisico
            {
                Titulo = dto.Titulo.Trim(),
                Descripcion = dto.Descripcion.Trim(),
                AnioPublicacion = dto.AnioPublicacion,
                Precio = dto.Precio,
                Activo = dto.Activo,
                EditorialId = dto.EditorialId,

                ISBN = dto.ISBN.Trim(),
                Stock = dto.Stock
            };
        }

        public static LibroDigital ToEntity(
            this LibroDigitalCreateDto dto)
        {
            return new LibroDigital
            {
                Titulo = dto.Titulo.Trim(),
                Descripcion = dto.Descripcion.Trim(),
                AnioPublicacion = dto.AnioPublicacion,
                Precio = dto.Precio,
                Activo = dto.Activo,
                EditorialId = dto.EditorialId,

                IdentificadorDigital = dto.IdentificadorDigital.Trim(),
                Formato = dto.Formato.Trim(),
                TamanioMB = dto.TamanioMB,
                UrlDescarga = dto.UrlDescarga.Trim()
            };
        }

        public static void ToEntity(
            this LibroFisicoUpdateDto dto,
            LibroFisico libro)
        {
            libro.Titulo = dto.Titulo.Trim();
            libro.Descripcion = dto.Descripcion.Trim();
            libro.AnioPublicacion = dto.AnioPublicacion;
            libro.Precio = dto.Precio;
            libro.Activo = dto.Activo;
            libro.EditorialId = dto.EditorialId;

            libro.ISBN = dto.ISBN.Trim();
            libro.Stock = dto.Stock;
        }

        public static void ToEntity(
            this LibroDigitalUpdateDto dto,
            LibroDigital libro)
        {
            libro.Titulo = dto.Titulo.Trim();
            libro.Descripcion = dto.Descripcion.Trim();
            libro.AnioPublicacion = dto.AnioPublicacion;
            libro.Precio = dto.Precio;
            libro.Activo = dto.Activo;
            libro.EditorialId = dto.EditorialId;

            // Propiedades específicas del libro digital
            libro.IdentificadorDigital = dto.IdentificadorDigital.Trim();
            libro.Formato = dto.Formato.Trim();
            libro.TamanioMB = dto.TamanioMB;
            libro.UrlDescarga = dto.UrlDescarga.Trim();
        }


        public static LibroListDto ToListDto(this Libro libro)
        {
            return new LibroListDto
            {
                LibroId = libro.LibroId,
                Titulo = libro.Titulo,

                TipoLibro = libro switch
                {
                    LibroFisico => "Físico",
                    LibroDigital => "Digital",
                    _ => "Desconocido"
                },

                Editorial = libro.Editorial?.Nombre ?? "",


                AnioPublicacion = libro.AnioPublicacion,
                Precio = libro.Precio,

                Stock = libro is LibroFisico libroFisico
                      ? libroFisico.Stock
                      : null,

                Activo = libro.Activo,


                Autores = string.Join(", ",
                    libro.Autores.Select(a =>
                        $"{a.Nombre} {a.Apellido}")),

                Temas = string.Join(", ",
                    libro.Temas.Select(t => t.Nombre))
            };
        }
    }
}
