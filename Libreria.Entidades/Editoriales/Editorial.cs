namespace Libreria.Entidades.Editoriales
{
    public class Editorial
    {
        public int EditorialId { get; set; }

        public string Nombre { get; set; } = string.Empty;

        public string PaisOrigen { get; set; } = string.Empty;

        public bool Activa { get; set; } = true;
    }
}
