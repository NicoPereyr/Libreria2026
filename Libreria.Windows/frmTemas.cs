using Libreria.Servicios.Interfaces;

namespace Libreria.Windows
{
    public partial class frmTemas : Form
    {
        private readonly ITemaServicio _temaServicio;

        public frmTemas(ITemaServicio temaServicio)
        {
            InitializeComponent();
            // Cargar imágenes
            tsbNuevo.Image = Image.FromFile("Imagenes/new_file_48px.png");
            tsbEditar.Image = Image.FromFile("Imagenes/edit_file_48px.png");
            tsbBorrar.Image = Image.FromFile("Imagenes/delete_file_48px.png");
            tsbActualizar.Image = Image.FromFile("Imagenes/restart_48px.png");
            tsbCerrar.Image = Image.FromFile("Imagenes/close_pane_48px.png");
            tsbBuscar.Image = Image.FromFile("Imagenes/search_property_48px.png");

            // Configurar tamaño y posición de los iconos
            foreach (ToolStripButton boton in new[]
            {
               tsbNuevo, tsbEditar, tsbBorrar,
               tsbActualizar, tsbCerrar, tsbBuscar
})
            {
                boton.ImageScaling = ToolStripItemImageScaling.None;
                boton.TextImageRelation = TextImageRelation.ImageAboveText;
                boton.DisplayStyle = ToolStripItemDisplayStyle.ImageAndText;
                boton.AutoSize = true;
            }


            _temaServicio = temaServicio;

            Load += frmTemas_Load;
            btnGuardar.Click += btnGuardar_Click;
            tsbNuevo.Click += tsbNuevo_Click;
            btnCancelar.Click += btnCancelar_Click;
            tsbEditar.Click += tsbEditar_Click;
            dgvTemas.SelectionChanged += dgvTemas_SelectionChanged;
            tsbBorrar.Click += tsbBorrar_Click;
            tsbBuscar.Click += tsbBuscar_Click;
            txtBuscar.KeyDown += txtBuscar_KeyDown;
            tsbActualizar.Click += tsbActualizar_Click;
            tsbCerrar.Click += (sender, e) => Close();
        }

        private void frmTemas_Load(object? sender, EventArgs e)
        {
            CargarTemas();
        }

        private void CargarTemas()
        {
            dgvTemas.DataSource = null;
            dgvTemas.DataSource = _temaServicio.ObtenerTodos();

            // Ocultar el identificador
            if (dgvTemas.Columns["TemaId"] != null)
            {
                dgvTemas.Columns["TemaId"].Visible = false;
            }

            // Configurar encabezados
            if (dgvTemas.Columns["Nombre"] != null)
            {
                dgvTemas.Columns["Nombre"].HeaderText = "Tema";
            }

            if (dgvTemas.Columns["Descripcion"] != null)
            {
                dgvTemas.Columns["Descripcion"].HeaderText = "Descripción";
            }

            // Mostrar cantidad de registros
            lblCantidad.Text =
                $"Cantidad de registros: {dgvTemas.Rows.Count}";

            // Evitar selección automática
            dgvTemas.ClearSelection();
            dgvTemas.CurrentCell = null;
        }
        private void btnGuardar_Click(object? sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                MessageBox.Show(
                    "Debe ingresar el nombre del tema.",
                    "Validación",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtNombre.Focus();
                return;
            }

            try
            {
                var tema = new Libreria.Entidades.Temas.Tema
                {
                    Nombre = txtNombre.Text.Trim(),
                    Descripcion = string.IsNullOrWhiteSpace(txtDescripcion.Text)
                        ? null
                        : txtDescripcion.Text.Trim()
                };

                _temaServicio.Agregar(tema);

                CargarTemas();
                LimpiarCampos();

                MessageBox.Show(
                    "Tema guardado correctamente.",
                    "Éxito",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Error al guardar el tema: {ex.Message}",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
        private void LimpiarCampos()
        {
            txtNombre.Clear();
            txtDescripcion.Clear();

            dgvTemas.ClearSelection();
            dgvTemas.CurrentCell = null;

            txtNombre.Focus();
        }
        private void dgvTemas_SelectionChanged(object? sender, EventArgs e)
        {
            if (dgvTemas.SelectedRows.Count == 0)
                return;

            if (dgvTemas.SelectedRows[0].DataBoundItem
                is Libreria.Entidades.Temas.Tema tema)
            {
                txtNombre.Text = tema.Nombre;
                txtDescripcion.Text = tema.Descripcion ?? "";
            }
        }
        private void tsbEditar_Click(object? sender, EventArgs e)
        {
            if (dgvTemas.SelectedRows.Count == 0 ||
                dgvTemas.SelectedRows[0].DataBoundItem
                is not Libreria.Entidades.Temas.Tema tema)
            {
                MessageBox.Show(
                    "Debe seleccionar un tema para editar.",
                    "Atención",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                MessageBox.Show(
                    "Debe ingresar el nombre del tema.",
                    "Validación",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtNombre.Focus();
                return;
            }

            try
            {
                tema.Nombre = txtNombre.Text.Trim();

                tema.Descripcion = string.IsNullOrWhiteSpace(txtDescripcion.Text)
                    ? null
                    : txtDescripcion.Text.Trim();

                _temaServicio.Editar(tema);

                CargarTemas();
                LimpiarCampos();

                MessageBox.Show(
                    "Tema modificado correctamente.",
                    "Éxito",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Error al editar el tema: {ex.Message}",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
        private void tsbBorrar_Click(object? sender, EventArgs e)
        {
            if (dgvTemas.SelectedRows.Count == 0 ||
                dgvTemas.SelectedRows[0].DataBoundItem
                is not Libreria.Entidades.Temas.Tema tema)
            {
                MessageBox.Show(
                    "Debe seleccionar un tema para eliminar.",
                    "Atención",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            var respuesta = MessageBox.Show(
                $"¿Está seguro de eliminar el tema '{tema.Nombre}'?",
                "Confirmar eliminación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (respuesta != DialogResult.Yes)
                return;

            try
            {
                _temaServicio.Eliminar(tema.TemaId);

                CargarTemas();
                LimpiarCampos();

                MessageBox.Show(
                    "Tema eliminado correctamente.",
                    "Éxito",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Error al eliminar el tema: {ex.Message}",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
        private void tsbBuscar_Click(object? sender, EventArgs e)
        {
            string texto = txtBuscar.Text.Trim();

            var temas = _temaServicio.ObtenerTodos();

            if (!string.IsNullOrWhiteSpace(texto))
            {
                temas = temas
                    .Where(t =>
                        t.Nombre.Contains(
                            texto, StringComparison.OrdinalIgnoreCase) ||
                        (t.Descripcion != null &&
                         t.Descripcion.Contains(
                            texto, StringComparison.OrdinalIgnoreCase)))
                    .ToList();
            }

            dgvTemas.DataSource = null;
            dgvTemas.DataSource = temas;

            if (dgvTemas.Columns["TemaId"] != null)
            {
                dgvTemas.Columns["TemaId"].Visible = false;
            }

            lblCantidad.Text =
                $"Cantidad de registros: {dgvTemas.Rows.Count}";

            dgvTemas.ClearSelection();
            dgvTemas.CurrentCell = null;
        }
        private void tsbActualizar_Click(object? sender, EventArgs e)
        {
            // Limpiar el buscador
            txtBuscar.Clear();

            // Mostrar nuevamente todos los temas
            CargarTemas();

            // Limpiar los campos
            LimpiarCampos();
        }
        private void txtBuscar_KeyDown(object? sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                tsbBuscar_Click(sender, EventArgs.Empty);
            }
        }
        private void tsbNuevo_Click(object? sender, EventArgs e)
        {
            LimpiarCampos();
        }
        private void btnCancelar_Click(object? sender, EventArgs e)
        {
            LimpiarCampos();
        }
    }
}
