using System;
using System.Collections.Generic;


using Libreria.Servicios.Interfaces;

namespace Libreria.Windows
{
    public partial class frmLibros : Form
    {
        private readonly ILibroServicio _libroServicio;
        private readonly IEditorialServicio _editorialServicio;
        private readonly IAutorServicio _autorServicio;

        public frmLibros(
            ILibroServicio libroServicio,
            IEditorialServicio editorialServicio,
            IAutorServicio autorServicio)
        {
            InitializeComponent();

            _libroServicio = libroServicio;
            _editorialServicio = editorialServicio;
            _autorServicio = autorServicio;

            Load += frmLibros_Load;
        }

        private void frmLibros_Load(object? sender, EventArgs e)
        {
            CargarEditoriales();
            CargarLibros();
        }

        private void CargarLibros()
        {
            try
            {
                var libros = _libroServicio.ObtenerTodos();

                dgvLibros.DataSource = null;
                dgvLibros.DataSource = libros;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Error al cargar los libros: {ex.Message}",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }


        private void CargarEditoriales()
        {
            try
            {
                var editoriales = _editorialServicio.ObtenerTodas();

                cboEditorial.DataSource = null;
                cboEditorial.DisplayMember = "Nombre";
                cboEditorial.ValueMember = "EditorialId";
                cboEditorial.DataSource = editoriales.ToList();

                cboEditorial.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Error al cargar las editoriales: {ex.Message}",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

    }
}


