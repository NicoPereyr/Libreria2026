
using Libreria.Servicios.Interfaces;

namespace Libreria.Windows
{
    public partial class frmEditoriales : Form
    {
        private readonly IEditorialServicio _editorialServicio;

        public frmEditoriales(IEditorialServicio editorialServicio)
        {
            InitializeComponent();
            _editorialServicio = editorialServicio;

            Load += frmEditoriales_Load;

            btnNuevo.Click += btnNuevo_Click;
            btnCancelar.Click += btnCancelar_Click;
            btnGuardar.Click += btnGuardar_Click;
            dgvEditoriales.SelectionChanged += dgvEditoriales_SelectionChanged;
            btnEditar.Click += btnEditar_Click;
            btnEliminar.Click += btnEliminar_Click;
        }

        private void frmEditoriales_Load(object? sender, EventArgs e)
        {
            CargarEditoriales();
            LimpiarCampos();
        }

        private void CargarEditoriales()
        {
            dgvEditoriales.DataSource = null;
            dgvEditoriales.DataSource =
                _editorialServicio.ObtenerTodas();
        }

        private void LimpiarCampos()
        {
            txtNombre.Clear();
            txtPaisOrigen.Clear();
            txtNombre.Focus();
        }

        private void btnNuevo_Click(object? sender, EventArgs e)
        {
            LimpiarCampos();
            dgvEditoriales.ClearSelection();
        }

        private void btnCancelar_Click(object? sender, EventArgs e)
        {
            LimpiarCampos();
            dgvEditoriales.ClearSelection();
        }

        private void btnGuardar_Click(object? sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                MessageBox.Show(
                    "Debe ingresar el nombre de la editorial.",
                    "Validación",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtNombre.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtPaisOrigen.Text))
            {
                MessageBox.Show(
                    "Debe ingresar el país de origen.",
                    "Validación",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtPaisOrigen.Focus();
                return;
            }

            try
            {
                var editorial = new Libreria.Entidades.Editoriales.Editorial
                {
                    Nombre = txtNombre.Text.Trim(),
                    PaisOrigen = txtPaisOrigen.Text.Trim()
                };

                _editorialServicio.Agregar(editorial);

                CargarEditoriales();
                LimpiarCampos();

                MessageBox.Show(
                    "Editorial guardada correctamente.",
                    "Éxito",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Error al guardar la editorial: {ex.Message}",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void dgvEditoriales_SelectionChanged(object? sender, EventArgs e)
        {
            if (dgvEditoriales.CurrentRow?.DataBoundItem
                is Libreria.Entidades.Editoriales.Editorial editorial)
            {
                txtNombre.Text = editorial.Nombre;
                txtPaisOrigen.Text = editorial.PaisOrigen;
            }
        }


        private void btnEditar_Click(object? sender, EventArgs e)
        {
            if (dgvEditoriales.CurrentRow?.DataBoundItem
                is not Libreria.Entidades.Editoriales.Editorial editorial)
            {
                MessageBox.Show(
                    "Debe seleccionar una editorial para editar.",
                    "Atención",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            if (string.IsNullOrWhiteSpace(txtNombre.Text) ||
                string.IsNullOrWhiteSpace(txtPaisOrigen.Text))
            {
                MessageBox.Show(
                    "Debe completar el nombre y el país de origen.",
                    "Validación",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            try
            {
                editorial.Nombre = txtNombre.Text.Trim();
                editorial.PaisOrigen = txtPaisOrigen.Text.Trim();

                _editorialServicio.Editar(editorial);

                CargarEditoriales();
                LimpiarCampos();

                MessageBox.Show(
                    "Editorial modificada correctamente.",
                    "Éxito",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Error al editar la editorial: {ex.Message}",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void btnEliminar_Click(object? sender, EventArgs e)
        {
            if (dgvEditoriales.CurrentRow?.DataBoundItem
                is not Libreria.Entidades.Editoriales.Editorial editorial)
            {
                MessageBox.Show(
                    "Debe seleccionar una editorial para eliminar.",
                    "Atención",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            var respuesta = MessageBox.Show(
                $"¿Está seguro de eliminar la editorial '{editorial.Nombre}'?",
                "Confirmar eliminación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (respuesta != DialogResult.Yes)
                return;

            try
            {
                _editorialServicio.Eliminar(editorial.EditorialId);

                CargarEditoriales();
                LimpiarCampos();

                MessageBox.Show(
                    "Editorial eliminada correctamente.",
                    "Éxito",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Error al eliminar la editorial: {ex.Message}",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }


    }
}


