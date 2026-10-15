using System;
using System.Collections.Generic;
using System.Text;

namespace Libreria.Entidades.Temas
{
    public class Tema
    {
        public int TemaId { get; set; }

        public string Nombre { get; set; } = string.Empty;

        public string? Descripcion { get; set; }
    }
}
