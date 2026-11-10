using Libreria.DTOs.Libros;

using Libreria.Servicios.Interfaces;

namespace Libreria.Windows
{
    public partial class frmLibros : Form
    {
        private readonly ILibroServicio _libroServicio;
        private readonly IEditorialServicio _editorialServicio;
        private readonly IAutorServicio _autorServicio;
        private readonly ITemaServicio _temaServicio;
        private int? _libroIdSeleccionado = null;
        private readonly List<AutorItem> _autoresDisponibles = new();
        private readonly List<AutorItem> _autoresSeleccionados = new();
        private readonly List<TemaItem> _temasDisponibles = new();
        private readonly List<TemaItem> _temasSeleccionados = new();


        public frmLibros(
            ILibroServicio libroServicio,
            IEditorialServicio editorialServicio,
            IAutorServicio autorServicio,
            ITemaServicio temaServicio)
        {
            InitializeComponent();

            _libroServicio = libroServicio;
            _editorialServicio = editorialServicio;
            _autorServicio = autorServicio;
            _temaServicio = temaServicio;

            Load += frmLibros_Load;
            cboTipoLibro.SelectedIndexChanged += cboTipoLibro_SelectedIndexChanged;
            btnNuevo.Click += btnNuevo_Click;
            btnGuardar.Click += btnGuardar_Click;
            btnCancelar.Click += btnCancelar_Click;
            btnEditar.Click += btnEditar_Click;
            btnEliminar.Click += btnEliminar_Click;
            txtBuscarAutor.TextChanged += txtBuscarAutor_TextChanged;
            lstResultadosAutores.Click += lstResultadosAutores_Click;
            txtBuscarTema.TextChanged += txtBuscarTema_TextChanged;
            lstResultadosTemas.Click += lstResultadosTemas_Click;
        }

        private void frmLibros_Load(object? sender, EventArgs e)
        {
            CargarEditoriales();
            CargarAutores();
            CargarTemas();
            CargarLibros();

            cboTipoLibro.SelectedIndex = 0;
            ActualizarCamposPorTipo();
        }

        private void CargarLibros()
        {
            try
            {
                var libros = _libroServicio.ObtenerTodos();

                dgvLibros.DataSource = null;
                dgvLibros.DataSource = libros;

                // Ocultar el identificador interno
                if (dgvLibros.Columns["LibroId"] != null)
                {
                    dgvLibros.Columns["LibroId"].Visible = false;
                }

                // Permitir que los textos largos ocupen varias líneas
                dgvLibros.DefaultCellStyle.WrapMode =
                    DataGridViewTriState.True;

                // Ajustar automáticamente la altura de las filas
                dgvLibros.AutoSizeRowsMode =
                    DataGridViewAutoSizeRowsMode.AllCells;

                // Distribuir las columnas en el espacio disponible
                dgvLibros.AutoSizeColumnsMode =
                    DataGridViewAutoSizeColumnsMode.Fill;

                // Dar más espacio a los autores
                if (dgvLibros.Columns["Autores"] != null)
                {
                    dgvLibros.Columns["Autores"].FillWeight = 180;
                }

                // Dar más espacio a los temas
                if (dgvLibros.Columns["Temas"] != null)
                {
                    dgvLibros.Columns["Temas"].FillWeight = 150;
                }

                // Dar más espacio al título
                if (dgvLibros.Columns["Titulo"] != null)
                {
                    dgvLibros.Columns["Titulo"].FillWeight = 150;
                }

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

        private void CargarAutores()
        {
            try
            {
                var autores = _autorServicio.ObtenerTodos();

                _autoresDisponibles.Clear();

                foreach (var autor in autores)
                {
                    var item = new AutorItem
                    {
                        AutorId = autor.AutorId,
                        NombreCompleto = $"{autor.Nombre} {autor.Apellido}"
                    };

                    _autoresDisponibles.Add(item);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Error al cargar los autores: {ex.Message}",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void txtBuscarAutor_TextChanged(object? sender, EventArgs e)
        {
            string texto = txtBuscarAutor.Text.Trim();

            lstResultadosAutores.Items.Clear();

            if (string.IsNullOrWhiteSpace(texto))
            {
                lstResultadosAutores.Visible = false;
                return;
            }

            var resultados = _autoresDisponibles
                .Where(a => a.NombreCompleto.Contains(
                    texto, StringComparison.OrdinalIgnoreCase))
                .ToList();

            foreach (var autor in resultados)
            {
                lstResultadosAutores.Items.Add(autor);
            }

            lstResultadosAutores.Visible = resultados.Count > 0;
        }

        private void lstResultadosAutores_Click(object? sender, EventArgs e)
        {
            if (lstResultadosAutores.SelectedItem is not AutorItem autor)
            {
                return;
            }

            // Evitar agregar el mismo autor dos veces
            if (!_autoresSeleccionados.Any(a => a.AutorId == autor.AutorId))
            {
                _autoresSeleccionados.Add(autor);
                MostrarAutoresSeleccionados();
            }

            // Limpiar el buscador
            txtBuscarAutor.Clear();
            lstResultadosAutores.Visible = false;
            txtBuscarAutor.Focus();
        }

        private void MostrarAutoresSeleccionados()
        {
            flpAutoresSeleccionados.Controls.Clear();

            foreach (var autor in _autoresSeleccionados)
            {
                // Contenedor de la etiqueta
                var panel = new FlowLayoutPanel
                {
                    AutoSize = true,
                    WrapContents = false,
                    FlowDirection = FlowDirection.LeftToRight,
                    BackColor = Color.FromArgb(225, 235, 245),
                    Margin = new Padding(4),
                    Padding = new Padding(5, 2, 5, 2)
                };

                // Nombre del autor
                var lblAutor = new Label
                {
                    Text = autor.NombreCompleto,
                    AutoSize = true,
                    Margin = new Padding(3, 5, 3, 3)
                };

                // Botón para quitar el autor
                var btnQuitar = new Button
                {
                    Text = "×",
                    Size = new Size(24, 24),
                    FlatStyle = FlatStyle.Flat,
                    Cursor = Cursors.Hand,
                    Margin = new Padding(3, 0, 0, 0)
                };

                btnQuitar.FlatAppearance.BorderSize = 0;

                int autorId = autor.AutorId;

                btnQuitar.Click += (s, e) =>
                {
                    _autoresSeleccionados.RemoveAll(
                        a => a.AutorId == autorId);

                    MostrarAutoresSeleccionados();
                };

                panel.Controls.Add(lblAutor);
                panel.Controls.Add(btnQuitar);

                flpAutoresSeleccionados.Controls.Add(panel);
            }
        }

        private void CargarTemas()
        {
            try
            {
                var temas = _temaServicio.ObtenerTodos();

                _temasDisponibles.Clear();

                foreach (var tema in temas)
                {
                    var item = new TemaItem
                    {
                        TemaId = tema.TemaId,
                        Nombre = tema.Nombre
                    };

                    _temasDisponibles.Add(item);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Error al cargar los temas: {ex.Message}",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void txtBuscarTema_TextChanged(object? sender, EventArgs e)
        {
            string texto = txtBuscarTema.Text.Trim();

            lstResultadosTemas.Items.Clear();

            if (string.IsNullOrWhiteSpace(texto))
            {
                lstResultadosTemas.Visible = false;
                return;
            }

            var resultados = _temasDisponibles
                .Where(t => t.Nombre.Contains(
                    texto, StringComparison.OrdinalIgnoreCase))
                .ToList();

            foreach (var tema in resultados)
            {
                lstResultadosTemas.Items.Add(tema);
            }

            lstResultadosTemas.Visible = resultados.Count > 0;
        }

        private void lstResultadosTemas_Click(object? sender, EventArgs e)
        {
            if (lstResultadosTemas.SelectedItem is not TemaItem tema)
            {
                return;
            }

            // Evitar agregar el mismo tema dos veces
            if (!_temasSeleccionados.Any(t => t.TemaId == tema.TemaId))
            {
                _temasSeleccionados.Add(tema);
                MostrarTemasSeleccionados();
            }

            // Limpiar el buscador
            txtBuscarTema.Clear();
            lstResultadosTemas.Visible = false;
            txtBuscarTema.Focus();
        }

        private void MostrarTemasSeleccionados()
        {
            flpTemasSeleccionados.Controls.Clear();

            foreach (var tema in _temasSeleccionados)
            {
                // Contenedor de la etiqueta
                var panel = new FlowLayoutPanel
                {
                    AutoSize = true,
                    WrapContents = false,
                    FlowDirection = FlowDirection.LeftToRight,
                    BackColor = Color.FromArgb(225, 235, 245),
                    Margin = new Padding(4),
                    Padding = new Padding(5, 2, 5, 2)
                };

                // Nombre del tema
                var lblTema = new Label
                {
                    Text = tema.Nombre,
                    AutoSize = true,
                    Margin = new Padding(3, 5, 3, 3)
                };

                // Botón para quitar el tema
                var btnQuitar = new Button
                {
                    Text = "×",
                    Size = new Size(24, 24),
                    FlatStyle = FlatStyle.Flat,
                    Cursor = Cursors.Hand,
                    Margin = new Padding(3, 0, 0, 0)
                };

                btnQuitar.FlatAppearance.BorderSize = 0;

                int temaId = tema.TemaId;

                btnQuitar.Click += (s, e) =>
                {
                    _temasSeleccionados.RemoveAll(
                        t => t.TemaId == temaId);

                    MostrarTemasSeleccionados();
                };

                panel.Controls.Add(lblTema);
                panel.Controls.Add(btnQuitar);

                flpTemasSeleccionados.Controls.Add(panel);
            }
        }



        private void cboTipoLibro_SelectedIndexChanged(object? sender, EventArgs e)
        {
            ActualizarCamposPorTipo();
        }


        private void ActualizarCamposPorTipo()
        {
            string tipo = cboTipoLibro.SelectedItem?.ToString() ?? "";

            bool esFisico = tipo == "Físico";
            bool esDigital = tipo == "Digital";

            // Mostrar solamente el panel correspondiente
            pnlLibroFisico.Visible = esFisico;
            pnlLibroDigital.Visible = esDigital;

            // Traer al frente el panel visible
            if (esFisico)
            {
                pnlLibroFisico.BringToFront();
            }
            else if (esDigital)
            {
                pnlLibroDigital.BringToFront();
            }
        }



        private void LimpiarControles()
        {
            _libroIdSeleccionado = null;
            // Datos generales
            txtTitulo.Clear();
            txtDescripcion.Clear();

            nudAnio.Value = DateTime.Now.Year;
            nudPrecio.Value = 0;

            cboEditorial.SelectedIndex = -1;
            chkActivo.Checked = true;

            // Libro físico
            txtISBN.Clear();
            nudStock.Value = 0;

            // Libro digital
            txtIdentificadorDigital.Clear();
            cboFormato.SelectedIndex = -1;
            nudTamanioMB.Value = 0;
            txtUrlDescarga.Clear();


            // Limpiar los autores del nuevo selector
            _autoresSeleccionados.Clear();

            // Eliminar las etiquetas visuales
            MostrarAutoresSeleccionados();

            // Limpiar el buscador
            txtBuscarAutor.Clear();

            // Ocultar los resultados
            lstResultadosAutores.Visible = false;



            // Limpiar los temas seleccionados
            _temasSeleccionados.Clear();

            // Eliminar las etiquetas visuales
            MostrarTemasSeleccionados();

            // Limpiar el buscador de temas
            txtBuscarTema.Clear();

            // Ocultar los resultados de búsqueda
            lstResultadosTemas.Visible = false;

            // Seleccionar libro físico
            cboTipoLibro.SelectedIndex = 0;
            ActualizarCamposPorTipo();

            // Quitar selección de la grilla
            dgvLibros.ClearSelection();

            txtTitulo.Focus();
            cboTipoLibro.Enabled = true;
        }

        private void btnNuevo_Click(object? sender, EventArgs e)
        {
            LimpiarControles();
        }


        private void btnGuardar_Click(object? sender, EventArgs e)
        {
            try
            {

                // Verificar campos obligatorios
                if (string.IsNullOrWhiteSpace(txtTitulo.Text))
                {
                    MessageBox.Show("Ingresá el título del libro.");
                    txtTitulo.Focus();
                    return;
                }
                if (nudAnio.Value > DateTime.Now.Year)
                {
                    MessageBox.Show(
                        "El año de publicación no puede ser mayor al año actual.",
                        "Validación",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    nudAnio.Focus();
                    return;
                }
                if (nudPrecio.Value <= 0)
                {
                    MessageBox.Show(
                        "El precio del libro debe ser mayor a cero.",
                        "Validación",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    nudPrecio.Focus();
                    return;
                }

                if (cboEditorial.SelectedIndex == -1)
                {
                    MessageBox.Show("Seleccioná una editorial.");
                    return;
                }


                if (cboTipoLibro.SelectedItem?.ToString() == "Físico")
                {
                    string isbn = txtISBN.Text.Trim();

                    if (string.IsNullOrWhiteSpace(isbn))
                    {
                        MessageBox.Show("Ingresá el ISBN del libro.");
                        txtISBN.Focus();
                        return;
                    }

                    if (isbn.Length != 13 || !isbn.All(char.IsDigit))
                    {
                        MessageBox.Show(
                            "El ISBN debe contener exactamente 13 dígitos numéricos.",
                            "Validación",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning);

                        txtISBN.Focus();
                        return;
                    }

                    if (nudStock.Value < 0)
                    {
                        MessageBox.Show(
                            "El stock no puede ser negativo.",
                            "Validación",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning);

                        nudStock.Focus();
                        return;
                    }


                }



                // Obtener los autores del nuevo selector
                var autoresIds = _autoresSeleccionados
                    .Select(a => a.AutorId)
                    .ToList();


                if (autoresIds.Count == 0)
                {
                    MessageBox.Show(
                        "Debés seleccionar al menos un autor.",
                        "Validación",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    txtBuscarAutor.Focus();
                    return;
                }


                // Obtener los temas seleccionados

                // Obtener los temas del nuevo selector
                var temasIds = _temasSeleccionados
                    .Select(t => t.TemaId)
                    .ToList();


                if (temasIds.Count == 0)
                {
                    MessageBox.Show(
                        "Debés seleccionar al menos un tema.",
                        "Validación",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    txtBuscarTema.Focus();
                    return;
                }



                string tipoLibro = cboTipoLibro.SelectedItem?.ToString() ?? "";


                if (tipoLibro == "Físico")
                {
                    if (_libroIdSeleccionado.HasValue)
                    {
                        // Estamos editando un libro físico existente
                        var dto = new LibroFisicoUpdateDto
                        {
                            LibroId = _libroIdSeleccionado.Value,
                            Titulo = txtTitulo.Text.Trim(),
                            Descripcion = txtDescripcion.Text.Trim(),
                            AnioPublicacion = (int)nudAnio.Value,
                            Precio = nudPrecio.Value,
                            Activo = chkActivo.Checked,
                            EditorialId = Convert.ToInt32(cboEditorial.SelectedValue),

                            ISBN = txtISBN.Text.Trim(),
                            Stock = (int)nudStock.Value,

                            AutoresIds = autoresIds,
                            TemasIds = temasIds
                        };

                        _libroServicio.EditarFisico(dto);
                    }
                    else
                    {
                        // Estamos agregando un libro físico nuevo
                        var dto = new LibroFisicoCreateDto
                        {
                            Titulo = txtTitulo.Text.Trim(),
                            Descripcion = txtDescripcion.Text.Trim(),
                            AnioPublicacion = (int)nudAnio.Value,
                            Precio = nudPrecio.Value,
                            Activo = chkActivo.Checked,
                            EditorialId = Convert.ToInt32(cboEditorial.SelectedValue),

                            ISBN = txtISBN.Text.Trim(),
                            Stock = (int)nudStock.Value,

                            AutoresIds = autoresIds,
                            TemasIds = temasIds
                        };

                        _libroServicio.AgregarFisico(dto);
                    }
                }


                else if (tipoLibro == "Digital")
                {
                    if (string.IsNullOrWhiteSpace(txtIdentificadorDigital.Text))
                    {
                        MessageBox.Show("Ingresá el identificador digital.");
                        txtIdentificadorDigital.Focus();
                        return;
                    }

                    if (cboFormato.SelectedIndex == -1)
                    {
                        MessageBox.Show("Seleccioná un formato.");
                        return;
                    }
                    if (nudTamanioMB.Value <= 0)
                    {
                        MessageBox.Show(
                            "El tamaño del libro digital debe ser mayor a 0 MB.",
                            "Validación",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning);

                        nudTamanioMB.Focus();
                        return;
                    }

                    if (string.IsNullOrWhiteSpace(txtUrlDescarga.Text))
                    {
                        MessageBox.Show("Ingresá la URL de descarga.");
                        txtUrlDescarga.Focus();
                        return;
                    }

                    if (_libroIdSeleccionado.HasValue)
                    {
                        // Editar un libro digital existente
                        var dto = new LibroDigitalUpdateDto
                        {
                            LibroId = _libroIdSeleccionado.Value,
                            Titulo = txtTitulo.Text.Trim(),
                            Descripcion = txtDescripcion.Text.Trim(),
                            AnioPublicacion = (int)nudAnio.Value,
                            Precio = nudPrecio.Value,
                            Activo = chkActivo.Checked,
                            EditorialId = Convert.ToInt32(cboEditorial.SelectedValue),

                            IdentificadorDigital = txtIdentificadorDigital.Text.Trim(),
                            Formato = cboFormato.SelectedItem!.ToString()!,
                            TamanioMB = nudTamanioMB.Value,
                            UrlDescarga = txtUrlDescarga.Text.Trim(),

                            AutoresIds = autoresIds,
                            TemasIds = temasIds
                        };

                        _libroServicio.EditarDigital(dto);
                    }
                    else
                    {
                        // Agregar un libro digital nuevo
                        var dto = new LibroDigitalCreateDto
                        {
                            Titulo = txtTitulo.Text.Trim(),
                            Descripcion = txtDescripcion.Text.Trim(),
                            AnioPublicacion = (int)nudAnio.Value,
                            Precio = nudPrecio.Value,
                            Activo = chkActivo.Checked,
                            EditorialId = Convert.ToInt32(cboEditorial.SelectedValue),

                            IdentificadorDigital = txtIdentificadorDigital.Text.Trim(),
                            Formato = cboFormato.SelectedItem!.ToString()!,
                            TamanioMB = nudTamanioMB.Value,
                            UrlDescarga = txtUrlDescarga.Text.Trim(),

                            AutoresIds = autoresIds,
                            TemasIds = temasIds
                        };

                        _libroServicio.AgregarDigital(dto);
                    }
                }

                else
                {
                    MessageBox.Show("Seleccioná un tipo de libro.");
                    return;
                }

                MessageBox.Show(
                    "Libro guardado correctamente.",
                    "Éxito",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                CargarLibros();
                LimpiarControles();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Error al guardar el libro:\n\n{ex.GetBaseException().Message}",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }



        }
        private void btnCancelar_Click(object? sender, EventArgs e)
        {
            LimpiarControles();
        }


        private void btnEditar_Click(object? sender, EventArgs e)
        {
            if (dgvLibros.CurrentRow?.DataBoundItem
                is not LibroListDto libroSeleccionado)
            {
                MessageBox.Show(
                    "Seleccioná un libro para editar.",
                    "Atención",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            _libroIdSeleccionado = libroSeleccionado.LibroId;



            if (libroSeleccionado.TipoLibro == "Físico")
            {
                var libro = _libroServicio.ObtenerFisicoParaEditar(
                    libroSeleccionado.LibroId);

                if (libro == null)
                {
                    MessageBox.Show("No se encontró el libro físico.");
                    _libroIdSeleccionado = null;
                    return;
                }

                // Datos generales
                cboTipoLibro.SelectedItem = "Físico";
                txtTitulo.Text = libro.Titulo;
                txtDescripcion.Text = libro.Descripcion;
                nudAnio.Value = libro.AnioPublicacion;
                nudPrecio.Value = libro.Precio;
                chkActivo.Checked = libro.Activo;
                cboEditorial.SelectedValue = libro.EditorialId;

                // Datos físicos
                txtISBN.Text = libro.ISBN;
                nudStock.Value = libro.Stock;


                // Cargar autores del libro en el nuevo selector
                _autoresSeleccionados.Clear();

                foreach (var autorId in libro.AutoresIds)
                {
                    var autor = _autoresDisponibles
                        .FirstOrDefault(a => a.AutorId == autorId);

                    if (autor != null)
                    {
                        _autoresSeleccionados.Add(autor);
                    }
                }

                MostrarAutoresSeleccionados();

                txtBuscarAutor.Clear();
                lstResultadosAutores.Visible = false;


                // Marcar temas

                // Cargar los temas del libro en el nuevo selector
                _temasSeleccionados.Clear();

                foreach (var temaId in libro.TemasIds)
                {
                    var tema = _temasDisponibles
                        .FirstOrDefault(t => t.TemaId == temaId);

                    if (tema != null)
                    {
                        _temasSeleccionados.Add(tema);
                    }
                }

                MostrarTemasSeleccionados();

                txtBuscarTema.Clear();
                lstResultadosTemas.Visible = false;
            }

            else if (libroSeleccionado.TipoLibro == "Digital")
            {
                var libro = _libroServicio.ObtenerDigitalParaEditar(
                    libroSeleccionado.LibroId);

                if (libro == null)
                {
                    MessageBox.Show("No se encontró el libro digital.");
                    _libroIdSeleccionado = null;
                    return;
                }

                // Datos generales
                cboTipoLibro.SelectedItem = "Digital";
                txtTitulo.Text = libro.Titulo;
                txtDescripcion.Text = libro.Descripcion;
                nudAnio.Value = libro.AnioPublicacion;
                nudPrecio.Value = libro.Precio;
                chkActivo.Checked = libro.Activo;
                cboEditorial.SelectedValue = libro.EditorialId;

                // Datos digitales
                txtIdentificadorDigital.Text = libro.IdentificadorDigital;
                cboFormato.SelectedItem = libro.Formato;
                nudTamanioMB.Value = libro.TamanioMB;
                txtUrlDescarga.Text = libro.UrlDescarga;


                // Cargar autores del libro en el nuevo selector
                _autoresSeleccionados.Clear();

                foreach (var autorId in libro.AutoresIds)
                {
                    var autor = _autoresDisponibles
                        .FirstOrDefault(a => a.AutorId == autorId);

                    if (autor != null)
                    {
                        _autoresSeleccionados.Add(autor);
                    }
                }

                MostrarAutoresSeleccionados();

                txtBuscarAutor.Clear();
                lstResultadosAutores.Visible = false;



                // Cargar los temas del libro en el nuevo selector
                _temasSeleccionados.Clear();

                foreach (var temaId in libro.TemasIds)
                {
                    var tema = _temasDisponibles
                        .FirstOrDefault(t => t.TemaId == temaId);

                    if (tema != null)
                    {
                        _temasSeleccionados.Add(tema);
                    }
                }

                MostrarTemasSeleccionados();

                txtBuscarTema.Clear();
                lstResultadosTemas.Visible = false;

            }
            cboTipoLibro.Enabled = false;
        }


        private void btnEliminar_Click(object? sender, EventArgs e)
        {
            if (dgvLibros.CurrentRow?.DataBoundItem
                is not LibroListDto libroSeleccionado)
            {
                MessageBox.Show(
                    "Seleccioná un libro para eliminar.",
                    "Atención",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            var respuesta = MessageBox.Show(
                $"¿Estás seguro de eliminar el libro '{libroSeleccionado.Titulo}'?",
                "Confirmar eliminación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (respuesta != DialogResult.Yes)
            {
                return;
            }

            try
            {
                _libroServicio.Eliminar(libroSeleccionado.LibroId);

                MessageBox.Show(
                    "Libro eliminado correctamente.",
                    "Éxito",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                CargarLibros();
                LimpiarControles();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Error al eliminar el libro: {ex.Message}",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

    }

    public class AutorItem
    {
        public int AutorId { get; set; }

        public string NombreCompleto { get; set; } = string.Empty;

        public override string ToString()
        {
            return NombreCompleto;
        }
    }


    public class TemaItem
    {
        public int TemaId { get; set; }

        public string Nombre { get; set; } = string.Empty;

        public override string ToString()
        {
            return Nombre;
        }
    }


}


