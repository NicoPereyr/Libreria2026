using System;
using System.Collections.Generic;
using System.Text;


namespace Libreria.Datos.Interfaces
{
    public interface IUnitOfWork
    {
        IAutorRepositorio Autores { get; }

        IEditorialRepositorio Editoriales { get; }

        ITemaRepositorio Temas { get; }

        ILibroRepositorio Libros { get; }

        void Guardar();

        void Dispose();
    }
}

