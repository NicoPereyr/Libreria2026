
using Libreria.Servicios.Interfaces;

namespace Libreria.Windows
{
    public partial class frmEditoriales : Form
    {
        private readonly IEditorialServicio _editorialServicio;


        public frmEditoriales(IEditorialServicio editorialServicio)
        {
            InitializeComponent();

            // Cargar imágenes
            tsbNuevo.Image = Image.FromFile("Imagenes/new_file_48px.png");
            tsbEditar.Image = Image.FromFile("Imagenes/edit_file_48px.png");
            tsbBorrar.Image = Image.FromFile("Imagenes/delete_file_48px.png");
            tsbActualizar.Image = Image.FromFile("Imagenes/restart_48px.png");
            tsbCerrar.Image = Image.FromFile("Imagenes/close_pane_48px.png");

            tsbBuscar.Image = Image.FromFile("Imagenes/search_property_48px.png");
            tsbBuscar.ImageScaling = ToolStripItemImageScaling.None;
            tsbBuscar.TextImageRelation = TextImageRelation.ImageAboveText;
            tsbBuscar.DisplayStyle = ToolStripItemDisplayStyle.ImageAndText;
            tsbBuscar.AutoSize = true;
            // Mostrar imagen arriba y texto abajo
            tsbNuevo.TextImageRelation = TextImageRelation.ImageAboveText;
            tsbEditar.TextImageRelation = TextImageRelation.ImageAboveText;
            tsbBorrar.TextImageRelation = TextImageRelation.ImageAboveText;
            tsbActualizar.TextImageRelation = TextImageRelation.ImageAboveText;
            tsbCerrar.TextImageRelation = TextImageRelation.ImageAboveText;

            tsbNuevo.DisplayStyle = ToolStripItemDisplayStyle.ImageAndText;
            tsbEditar.DisplayStyle = ToolStripItemDisplayStyle.ImageAndText;
            tsbBorrar.DisplayStyle = ToolStripItemDisplayStyle.ImageAndText;
            tsbActualizar.DisplayStyle = ToolStripItemDisplayStyle.ImageAndText;
            tsbCerrar.DisplayStyle = ToolStripItemDisplayStyle.ImageAndText;

            // NUEVO: mostrar imágenes en tamaño original
            tsbNuevo.ImageScaling = ToolStripItemImageScaling.None;
            tsbEditar.ImageScaling = ToolStripItemImageScaling.None;
            tsbBorrar.ImageScaling = ToolStripItemImageScaling.None;
            tsbActualizar.ImageScaling = ToolStripItemImageScaling.None;
            tsbCerrar.ImageScaling = ToolStripItemImageScaling.None;

            // NUEVO: ajustar tamaño de los botones
            tsbNuevo.AutoSize = true;
            tsbEditar.AutoSize = true;
            tsbBorrar.AutoSize = true;
            tsbActualizar.AutoSize = true;
            tsbCerrar.AutoSize = true;

            _editorialServicio = editorialServicio;



            Load += frmEditoriales_Load;

            // Barra superior
            tsbNuevo.Click += btnNuevo_Click;
            tsbEditar.Click += btnEditar_Click;
            tsbBorrar.Click += btnEliminar_Click;

            tsbActualizar.Click += (sender, e) =>
            {
                txtBuscar.Clear();
                CargarEditoriales();
                LimpiarCampos();
                dgvEditoriales.ClearSelection();
            };

            tsbCerrar.Click += (sender, e) => Close();

            // Botones de carga
            btnGuardar.Click += btnGuardar_Click;
            btnCancelar.Click += btnCancelar_Click;

            // Grilla
            dgvEditoriales.SelectionChanged +=
                dgvEditoriales_SelectionChanged;

            tsbBuscar.Click += tsbBuscar_Click;
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

            if (dgvEditoriales.Columns["EditorialId"] != null)
            {
                dgvEditoriales.Columns["EditorialId"].Visible = false;
            }

            lblCantidad.Text =
                $"Cantidad de registros: {dgvEditoriales.Rows.Count}";

            dgvEditoriales.ClearSelection();
            dgvEditoriales.CurrentCell = null;
        }
        private void tsbBuscar_Click(object? sender, EventArgs e)
        {
            string texto = txtBuscar.Text.Trim();

            var editoriales = _editorialServicio.ObtenerTodas();

            if (!string.IsNullOrWhiteSpace(texto))
            {
                editoriales = editoriales
                    .Where(e => e.Nombre.Contains(
                        texto, StringComparison.OrdinalIgnoreCase))
                    .ToList();
            }

            dgvEditoriales.DataSource = null;
            dgvEditoriales.DataSource = editoriales;

            dgvEditoriales.Columns["EditorialId"].Visible = false;

            lblCantidad.Text =
                $"Cantidad de registros: {dgvEditoriales.Rows.Count}";
            dgvEditoriales.ClearSelection();
            dgvEditoriales.CurrentCell = null;
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
            if (dgvEditoriales.SelectedRows.Count == 0 ||
                 dgvEditoriales.SelectedRows[0].DataBoundItem
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
            if (dgvEditoriales.SelectedRows.Count == 0 ||
                 dgvEditoriales.SelectedRows[0].DataBoundItem
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


