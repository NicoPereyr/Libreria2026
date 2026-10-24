using Libreria.Servicios.Interfaces;

namespace Libreria.Windows
{
    public partial class frmAutores : Form
    {
        private readonly IAutorServicio _autorServicio;

        public frmAutores(IAutorServicio autorServicio)
        {
            InitializeComponent();

            // Cargar imágenes
            tsbNuevo.Image = Image.FromFile("Imagenes/new_file_48px.png");
            tsbEditar.Image = Image.FromFile("Imagenes/edit_file_48px.png");
            tsbBorrar.Image = Image.FromFile("Imagenes/delete_file_48px.png");
            tsbActualizar.Image = Image.FromFile("Imagenes/restart_48px.png");
            tsbCerrar.Image = Image.FromFile("Imagenes/close_pane_48px.png");
            tsbBuscar.Image = Image.FromFile("Imagenes/search_property_48px.png");

            // Configurar los botones
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


            _autorServicio = autorServicio;
            Load += frmAutores_Load;
            btnGuardar.Click += btnGuardar_Click;
            tsbNuevo.Click += tsbNuevo_Click;
            btnCancelar.Click += btnCancelar_Click;
            tsbEditar.Click += tsbEditar_Click;
            dgvAutores.SelectionChanged += dgvAutores_SelectionChanged;
            tsbBorrar.Click += tsbBorrar_Click;
            tsbBuscar.Click += tsbBuscar_Click;
            txtBuscar.KeyDown += txtBuscar_KeyDown;
            tsbActualizar.Click += tsbActualizar_Click;
            tsbCerrar.Click += (sender, e) => Close();
        }
        private void frmAutores_Load(object? sender, EventArgs e)
        {
            CargarAutores();
        }
        private void CargarAutores()
        {
            dgvAutores.DataSource = null;
            dgvAutores.DataSource = _autorServicio.ObtenerTodos();

            // Ocultar el identificador
            if (dgvAutores.Columns["AutorId"] != null)
            {
                dgvAutores.Columns["AutorId"].Visible = false;
            }

            // Mostrar cantidad de registros
            lblCantidad.Text =
                $"Cantidad de registros: {dgvAutores.Rows.Count}";

            // Evitar selección automática
            dgvAutores.ClearSelection();
            dgvAutores.CurrentCell = null;
        }

        private void btnGuardar_Click(object? sender, EventArgs e)
        {
            // Validar nombre
            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                MessageBox.Show(
                    "Debe ingresar el nombre del autor.",
                    "Validación",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtNombre.Focus();
                return;
            }

            // Validar apellido
            if (string.IsNullOrWhiteSpace(txtApellido.Text))
            {
                MessageBox.Show(
                    "Debe ingresar el apellido del autor.",
                    "Validación",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtApellido.Focus();
                return;
            }

            // Validar nacionalidad
            if (string.IsNullOrWhiteSpace(txtNacionalidad.Text))
            {
                MessageBox.Show(
                    "Debe ingresar la nacionalidad del autor.",
                    "Validación",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtNacionalidad.Focus();
                return;
            }

            // Validar fecha de nacimiento
            if (dtpFechaNacimiento.Value.Date > DateTime.Today)
            {
                MessageBox.Show(
                    "La fecha de nacimiento no puede ser futura.",
                    "Validación",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            try
            {
                var autor = new Libreria.Entidades.Autores.Autor
                {
                    Nombre = txtNombre.Text.Trim(),
                    Apellido = txtApellido.Text.Trim(),
                    FechaNacimiento = dtpFechaNacimiento.Value.Date,
                    Nacionalidad = txtNacionalidad.Text.Trim()
                };

                _autorServicio.Agregar(autor);

                CargarAutores();
                LimpiarCampos();

                MessageBox.Show(
                    "Autor guardado correctamente.",
                    "Éxito",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Error al guardar el autor: {ex.Message}",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
        private void LimpiarCampos()
        {
            txtNombre.Clear();
            txtApellido.Clear();
            txtNacionalidad.Clear();

            dtpFechaNacimiento.Value = DateTime.Today;

            dgvAutores.ClearSelection();
            dgvAutores.CurrentCell = null;

            txtNombre.Focus();
        }
        private void dgvAutores_SelectionChanged(object? sender, EventArgs e)
        {
            if (dgvAutores.SelectedRows.Count == 0)
                return;

            if (dgvAutores.SelectedRows[0].DataBoundItem
                is Libreria.Entidades.Autores.Autor autor)
            {
                txtNombre.Text = autor.Nombre;
                txtApellido.Text = autor.Apellido;
                dtpFechaNacimiento.Value = autor.FechaNacimiento;
                txtNacionalidad.Text = autor.Nacionalidad;
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

        private void tsbEditar_Click(object? sender, EventArgs e)
        {
            if (dgvAutores.SelectedRows.Count == 0 ||
                dgvAutores.SelectedRows[0].DataBoundItem
                is not Libreria.Entidades.Autores.Autor autor)
            {
                MessageBox.Show(
                    "Debe seleccionar un autor para editar.",
                    "Atención",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtNombre.Text) ||
                string.IsNullOrWhiteSpace(txtApellido.Text) ||
                string.IsNullOrWhiteSpace(txtNacionalidad.Text))
            {
                MessageBox.Show(
                    "Debe completar todos los campos.",
                    "Validación",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            if (dtpFechaNacimiento.Value.Date > DateTime.Today)
            {
                MessageBox.Show(
                    "La fecha de nacimiento no puede ser futura.",
                    "Validación",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            try
            {
                autor.Nombre = txtNombre.Text.Trim();
                autor.Apellido = txtApellido.Text.Trim();
                autor.FechaNacimiento = dtpFechaNacimiento.Value.Date;
                autor.Nacionalidad = txtNacionalidad.Text.Trim();

                _autorServicio.Editar(autor);

                CargarAutores();
                LimpiarCampos();

                MessageBox.Show(
                    "Autor modificado correctamente.",
                    "Éxito",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Error al editar el autor: {ex.Message}",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void tsbBorrar_Click(object? sender, EventArgs e)
        {
            if (dgvAutores.SelectedRows.Count == 0 ||
                dgvAutores.SelectedRows[0].DataBoundItem
                is not Libreria.Entidades.Autores.Autor autor)
            {
                MessageBox.Show(
                    "Debe seleccionar un autor para eliminar.",
                    "Atención",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            var respuesta = MessageBox.Show(
                $"¿Está seguro de eliminar al autor '{autor.Nombre} {autor.Apellido}'?",
                "Confirmar eliminación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (respuesta != DialogResult.Yes)
                return;

            try
            {
                _autorServicio.Eliminar(autor.AutorId);

                CargarAutores();
                LimpiarCampos();

                MessageBox.Show(
                    "Autor eliminado correctamente.",
                    "Éxito",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Error al eliminar el autor: {ex.Message}",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
        private void tsbBuscar_Click(object? sender, EventArgs e)
        {
            string texto = txtBuscar.Text.Trim();

            var autores = _autorServicio.ObtenerTodos();

            if (!string.IsNullOrWhiteSpace(texto))
            {
                autores = autores
                    .Where(a =>
                        a.Nombre.Contains(
                            texto, StringComparison.OrdinalIgnoreCase) ||
                        a.Apellido.Contains(
                            texto, StringComparison.OrdinalIgnoreCase))
                    .ToList();
            }

            dgvAutores.DataSource = null;
            dgvAutores.DataSource = autores;

            if (dgvAutores.Columns["AutorId"] != null)
            {
                dgvAutores.Columns["AutorId"].Visible = false;
            }

            lblCantidad.Text =
                $"Cantidad de registros: {dgvAutores.Rows.Count}";

            dgvAutores.ClearSelection();
            dgvAutores.CurrentCell = null;
        }
        private void txtBuscar_KeyDown(object? sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                tsbBuscar_Click(sender, EventArgs.Empty);
            }
        }
        private void tsbActualizar_Click(object? sender, EventArgs e)
        {
            // Limpiar el buscador
            txtBuscar.Clear();

            // Volver a mostrar todos los autores
            CargarAutores();

            // Limpiar los campos
            LimpiarCampos();
        }
    }

}
