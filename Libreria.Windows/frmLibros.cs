using System;
using System.Collections.Generic;
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

                clbAutores.Items.Clear();

                foreach (var autor in autores)
                {
                    clbAutores.Items.Add(
                        new AutorItem
                        {
                            AutorId = autor.AutorId,
                            NombreCompleto = $"{autor.Nombre} {autor.Apellido}"
                        });
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


        private void CargarTemas()
        {
            try
            {
                var temas = _temaServicio.ObtenerTodos();

                clbTemas.Items.Clear();

                foreach (var tema in temas)
                {
                    clbTemas.Items.Add(new TemaItem
                    {
                        TemaId = tema.TemaId,
                        Nombre = tema.Nombre
                    });
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


        private void cboTipoLibro_SelectedIndexChanged(object? sender, EventArgs e)
        {
            ActualizarCamposPorTipo();
        }

        private void ActualizarCamposPorTipo()
        {
            string tipo = cboTipoLibro.SelectedItem?.ToString() ?? "";

            bool esFisico = tipo == "Físico";
            bool esDigital = tipo == "Digital";

            // Campos de libro físico
            lblISBN.Visible = esFisico;
            txtISBN.Visible = esFisico;
            lblStock.Visible = esFisico;
            nudStock.Visible = esFisico;

            // Campos de libro digital
            lblIdentificadorDigital.Visible = esDigital;
            txtIdentificadorDigital.Visible = esDigital;
            lblFormato.Visible = esDigital;
            cboFormato.Visible = esDigital;
            lblTamanioMB.Visible = esDigital;
            nudTamanioMB.Visible = esDigital;
            lblUrlDescarga.Visible = esDigital;
            txtUrlDescarga.Visible = esDigital;
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

            // Desmarcar autores
            for (int i = 0; i < clbAutores.Items.Count; i++)
            {
                clbAutores.SetItemChecked(i, false);
            }

            // Desmarcar temas
            for (int i = 0; i < clbTemas.Items.Count; i++)
            {
                clbTemas.SetItemChecked(i, false);
            }
            // Quitar la selección visual azul
            clbAutores.ClearSelected();
            clbTemas.ClearSelected();

            // Seleccionar libro físico
            cboTipoLibro.SelectedIndex = 0;
            ActualizarCamposPorTipo();

            // Quitar selección de la grilla
            dgvLibros.ClearSelection();

            txtTitulo.Focus();
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

                    if (cboTipoLibro.SelectedItem?.ToString() == "Físico")
                    {
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

                }


                // Obtener los autores seleccionados
                var autoresIds = clbAutores.CheckedItems
                    .Cast<AutorItem>()
                    .Select(a => a.AutorId)
                    .ToList();

                // Obtener los temas seleccionados
                var temasIds = clbTemas.CheckedItems
                    .Cast<TemaItem>()
                    .Select(t => t.TemaId)
                    .ToList();


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

                // Marcar autores
                for (int i = 0; i < clbAutores.Items.Count; i++)
                {
                    if (clbAutores.Items[i] is AutorItem autor)
                    {
                        clbAutores.SetItemChecked(
                            i, libro.AutoresIds.Contains(autor.AutorId));
                    }
                }

                // Marcar temas
                for (int i = 0; i < clbTemas.Items.Count; i++)
                {
                    if (clbTemas.Items[i] is TemaItem tema)
                    {
                        clbTemas.SetItemChecked(
                            i, libro.TemasIds.Contains(tema.TemaId));
                    }
                }

                clbAutores.ClearSelected();
                clbTemas.ClearSelected();
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

                // Marcar autores
                for (int i = 0; i < clbAutores.Items.Count; i++)
                {
                    if (clbAutores.Items[i] is AutorItem autor)
                    {
                        clbAutores.SetItemChecked(
                            i, libro.AutoresIds.Contains(autor.AutorId));
                    }
                }

                // Marcar temas
                for (int i = 0; i < clbTemas.Items.Count; i++)
                {
                    if (clbTemas.Items[i] is TemaItem tema)
                    {
                        clbTemas.SetItemChecked(
                            i, libro.TemasIds.Contains(tema.TemaId));
                    }
                }

                clbAutores.ClearSelected();
                clbTemas.ClearSelected();
            }

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


