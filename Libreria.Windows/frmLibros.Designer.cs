namespace Libreria.Windows
{
    partial class frmLibros
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lblTipoLibro = new Label();
            cboTipoLibro = new ComboBox();
            lblTitulo = new Label();
            txtTitulo = new TextBox();
            lblDescripcion = new Label();
            txtDescripcion = new TextBox();
            lblAnio = new Label();
            nudAnio = new NumericUpDown();
            lblPrecio = new Label();
            nudPrecio = new NumericUpDown();
            lblEditorial = new Label();
            cboEditorial = new ComboBox();
            chkActivo = new CheckBox();
            btnNuevo = new Button();
            btnGuardar = new Button();
            btnEditar = new Button();
            btnEliminar = new Button();
            btnCancelar = new Button();
            txtBuscarAutor = new TextBox();
            lstResultadosAutores = new ListBox();
            flpAutoresSeleccionados = new FlowLayoutPanel();
            flpTemasSeleccionados = new FlowLayoutPanel();
            lstResultadosTemas = new ListBox();
            txtBuscarTema = new TextBox();
            pnlListadoLibros = new Panel();
            dgvLibros = new DataGridView();
            pnlLibroFisico = new Panel();
            nudStock = new NumericUpDown();
            lblStock = new Label();
            txtISBN = new TextBox();
            lblISBN = new Label();
            pnlLibroDigital = new Panel();
            txtUrlDescarga = new TextBox();
            lblUrlDescarga = new Label();
            nudTamanioMB = new NumericUpDown();
            lblTamanioMB = new Label();
            cboFormato = new ComboBox();
            lblFormato = new Label();
            txtIdentificadorDigital = new TextBox();
            lblIdentificadorDigital = new Label();
            ((System.ComponentModel.ISupportInitialize)nudAnio).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudPrecio).BeginInit();
            pnlListadoLibros.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvLibros).BeginInit();
            pnlLibroFisico.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudStock).BeginInit();
            pnlLibroDigital.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudTamanioMB).BeginInit();
            SuspendLayout();
            // 
            // lblTipoLibro
            // 
            lblTipoLibro.AutoSize = true;
            lblTipoLibro.Font = new Font("Segoe UI", 10F);
            lblTipoLibro.Location = new Point(11, 30);
            lblTipoLibro.Name = "lblTipoLibro";
            lblTipoLibro.Size = new Size(88, 19);
            lblTipoLibro.TabIndex = 0;
            lblTipoLibro.Text = "Tipo de libro:";
            // 
            // cboTipoLibro
            // 
            cboTipoLibro.DropDownStyle = ComboBoxStyle.DropDownList;
            cboTipoLibro.FormattingEnabled = true;
            cboTipoLibro.Items.AddRange(new object[] { "Físico", "Digital" });
            cboTipoLibro.Location = new Point(106, 26);
            cboTipoLibro.Name = "cboTipoLibro";
            cboTipoLibro.Size = new Size(200, 23);
            cboTipoLibro.TabIndex = 1;
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Location = new Point(11, 75);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(41, 15);
            lblTitulo.TabIndex = 2;
            lblTitulo.Text = "Título:";
            // 
            // txtTitulo
            // 
            txtTitulo.Location = new Point(58, 72);
            txtTitulo.MaxLength = 150;
            txtTitulo.Name = "txtTitulo";
            txtTitulo.Size = new Size(300, 23);
            txtTitulo.TabIndex = 3;
            // 
            // lblDescripcion
            // 
            lblDescripcion.AutoSize = true;
            lblDescripcion.Location = new Point(11, 111);
            lblDescripcion.Name = "lblDescripcion";
            lblDescripcion.Size = new Size(72, 15);
            lblDescripcion.TabIndex = 4;
            lblDescripcion.Text = "Descripción:";
            // 
            // txtDescripcion
            // 
            txtDescripcion.Location = new Point(89, 108);
            txtDescripcion.MaxLength = 500;
            txtDescripcion.Multiline = true;
            txtDescripcion.Name = "txtDescripcion";
            txtDescripcion.ScrollBars = ScrollBars.Vertical;
            txtDescripcion.Size = new Size(300, 75);
            txtDescripcion.TabIndex = 5;
            // 
            // lblAnio
            // 
            lblAnio.AutoSize = true;
            lblAnio.Location = new Point(11, 193);
            lblAnio.Name = "lblAnio";
            lblAnio.Size = new Size(113, 15);
            lblAnio.TabIndex = 6;
            lblAnio.Text = "Año de publicación:";
            // 
            // nudAnio
            // 
            nudAnio.Location = new Point(136, 191);
            nudAnio.Maximum = new decimal(new int[] { 9999, 0, 0, 0 });
            nudAnio.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            nudAnio.Name = "nudAnio";
            nudAnio.Size = new Size(120, 23);
            nudAnio.TabIndex = 7;
            nudAnio.Value = new decimal(new int[] { 2026, 0, 0, 0 });
            // 
            // lblPrecio
            // 
            lblPrecio.AutoSize = true;
            lblPrecio.Location = new Point(11, 229);
            lblPrecio.Name = "lblPrecio";
            lblPrecio.Size = new Size(43, 15);
            lblPrecio.TabIndex = 8;
            lblPrecio.Text = "Precio:";
            // 
            // nudPrecio
            // 
            nudPrecio.DecimalPlaces = 2;
            nudPrecio.Location = new Point(66, 227);
            nudPrecio.Maximum = new decimal(new int[] { 10000000, 0, 0, 0 });
            nudPrecio.Name = "nudPrecio";
            nudPrecio.Size = new Size(120, 23);
            nudPrecio.TabIndex = 9;
            // 
            // lblEditorial
            // 
            lblEditorial.AutoSize = true;
            lblEditorial.Location = new Point(11, 264);
            lblEditorial.Name = "lblEditorial";
            lblEditorial.Size = new Size(53, 15);
            lblEditorial.TabIndex = 10;
            lblEditorial.Text = "Editorial:";
            // 
            // cboEditorial
            // 
            cboEditorial.DropDownStyle = ComboBoxStyle.DropDownList;
            cboEditorial.FormattingEnabled = true;
            cboEditorial.Location = new Point(79, 261);
            cboEditorial.Name = "cboEditorial";
            cboEditorial.Size = new Size(200, 23);
            cboEditorial.TabIndex = 11;
            // 
            // chkActivo
            // 
            chkActivo.AutoSize = true;
            chkActivo.Checked = true;
            chkActivo.CheckState = CheckState.Checked;
            chkActivo.Location = new Point(11, 306);
            chkActivo.Name = "chkActivo";
            chkActivo.Size = new Size(60, 19);
            chkActivo.TabIndex = 12;
            chkActivo.Text = "Activo";
            chkActivo.UseVisualStyleBackColor = true;
            // 
            // btnNuevo
            // 
            btnNuevo.Location = new Point(12, 464);
            btnNuevo.Name = "btnNuevo";
            btnNuevo.Size = new Size(100, 23);
            btnNuevo.TabIndex = 29;
            btnNuevo.Text = "Nuevo";
            btnNuevo.UseVisualStyleBackColor = true;
            // 
            // btnGuardar
            // 
            btnGuardar.Location = new Point(137, 464);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(100, 23);
            btnGuardar.TabIndex = 30;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = true;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // btnEditar
            // 
            btnEditar.Location = new Point(257, 464);
            btnEditar.Name = "btnEditar";
            btnEditar.Size = new Size(100, 23);
            btnEditar.TabIndex = 31;
            btnEditar.Text = "Editar";
            btnEditar.UseVisualStyleBackColor = true;
            // 
            // btnEliminar
            // 
            btnEliminar.Location = new Point(374, 464);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(100, 23);
            btnEliminar.TabIndex = 32;
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseVisualStyleBackColor = true;
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new Point(497, 464);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(100, 23);
            btnCancelar.TabIndex = 33;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            // 
            // txtBuscarAutor
            // 
            txtBuscarAutor.Location = new Point(475, 15);
            txtBuscarAutor.Name = "txtBuscarAutor";
            txtBuscarAutor.PlaceholderText = "Buscar autor...";
            txtBuscarAutor.Size = new Size(250, 23);
            txtBuscarAutor.TabIndex = 35;
            // 
            // lstResultadosAutores
            // 
            lstResultadosAutores.FormattingEnabled = true;
            lstResultadosAutores.Location = new Point(733, 15);
            lstResultadosAutores.Name = "lstResultadosAutores";
            lstResultadosAutores.Size = new Size(250, 79);
            lstResultadosAutores.TabIndex = 36;
            lstResultadosAutores.Visible = false;
            // 
            // flpAutoresSeleccionados
            // 
            flpAutoresSeleccionados.AutoScroll = true;
            flpAutoresSeleccionados.BorderStyle = BorderStyle.FixedSingle;
            flpAutoresSeleccionados.Location = new Point(477, 44);
            flpAutoresSeleccionados.Name = "flpAutoresSeleccionados";
            flpAutoresSeleccionados.Size = new Size(250, 70);
            flpAutoresSeleccionados.TabIndex = 37;
            // 
            // flpTemasSeleccionados
            // 
            flpTemasSeleccionados.AutoScroll = true;
            flpTemasSeleccionados.BorderStyle = BorderStyle.FixedSingle;
            flpTemasSeleccionados.Location = new Point(477, 167);
            flpTemasSeleccionados.Name = "flpTemasSeleccionados";
            flpTemasSeleccionados.Size = new Size(250, 70);
            flpTemasSeleccionados.TabIndex = 40;
            // 
            // lstResultadosTemas
            // 
            lstResultadosTemas.FormattingEnabled = true;
            lstResultadosTemas.Location = new Point(731, 138);
            lstResultadosTemas.Name = "lstResultadosTemas";
            lstResultadosTemas.Size = new Size(250, 79);
            lstResultadosTemas.TabIndex = 39;
            lstResultadosTemas.Visible = false;
            // 
            // txtBuscarTema
            // 
            txtBuscarTema.Location = new Point(475, 138);
            txtBuscarTema.Name = "txtBuscarTema";
            txtBuscarTema.PlaceholderText = "Buscar tema...";
            txtBuscarTema.Size = new Size(250, 23);
            txtBuscarTema.TabIndex = 38;
            // 
            // pnlListadoLibros
            // 
            pnlListadoLibros.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pnlListadoLibros.Controls.Add(dgvLibros);
            pnlListadoLibros.Location = new Point(10, 530);
            pnlListadoLibros.Name = "pnlListadoLibros";
            pnlListadoLibros.Padding = new Padding(10);
            pnlListadoLibros.Size = new Size(1000, 300);
            pnlListadoLibros.TabIndex = 41;
            // 
            // dgvLibros
            // 
            dgvLibros.AllowUserToAddRows = false;
            dgvLibros.AllowUserToDeleteRows = false;
            dgvLibros.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvLibros.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvLibros.Dock = DockStyle.Fill;
            dgvLibros.Location = new Point(10, 10);
            dgvLibros.MultiSelect = false;
            dgvLibros.Name = "dgvLibros";
            dgvLibros.ReadOnly = true;
            dgvLibros.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvLibros.Size = new Size(980, 280);
            dgvLibros.TabIndex = 35;
            // 
            // pnlLibroFisico
            // 
            pnlLibroFisico.Controls.Add(nudStock);
            pnlLibroFisico.Controls.Add(lblStock);
            pnlLibroFisico.Controls.Add(txtISBN);
            pnlLibroFisico.Controls.Add(lblISBN);
            pnlLibroFisico.Location = new Point(13, 333);
            pnlLibroFisico.Name = "pnlLibroFisico";
            pnlLibroFisico.Size = new Size(350, 90);
            pnlLibroFisico.TabIndex = 42;
            // 
            // nudStock
            // 
            nudStock.Location = new Point(214, 29);
            nudStock.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
            nudStock.Name = "nudStock";
            nudStock.Size = new Size(120, 23);
            nudStock.TabIndex = 20;
            // 
            // lblStock
            // 
            lblStock.AutoSize = true;
            lblStock.Location = new Point(214, 11);
            lblStock.Name = "lblStock";
            lblStock.Size = new Size(39, 15);
            lblStock.TabIndex = 19;
            lblStock.Text = "Stock:";
            // 
            // txtISBN
            // 
            txtISBN.Location = new Point(3, 28);
            txtISBN.MaxLength = 13;
            txtISBN.Name = "txtISBN";
            txtISBN.Size = new Size(200, 23);
            txtISBN.TabIndex = 18;
            // 
            // lblISBN
            // 
            lblISBN.AutoSize = true;
            lblISBN.Location = new Point(6, 10);
            lblISBN.Name = "lblISBN";
            lblISBN.Size = new Size(35, 15);
            lblISBN.TabIndex = 17;
            lblISBN.Text = "ISBN:";
            // 
            // pnlLibroDigital
            // 
            pnlLibroDigital.Controls.Add(txtUrlDescarga);
            pnlLibroDigital.Controls.Add(lblUrlDescarga);
            pnlLibroDigital.Controls.Add(nudTamanioMB);
            pnlLibroDigital.Controls.Add(lblTamanioMB);
            pnlLibroDigital.Controls.Add(cboFormato);
            pnlLibroDigital.Controls.Add(lblFormato);
            pnlLibroDigital.Controls.Add(txtIdentificadorDigital);
            pnlLibroDigital.Controls.Add(lblIdentificadorDigital);
            pnlLibroDigital.Location = new Point(13, 333);
            pnlLibroDigital.Name = "pnlLibroDigital";
            pnlLibroDigital.Size = new Size(537, 125);
            pnlLibroDigital.TabIndex = 43;
            // 
            // txtUrlDescarga
            // 
            txtUrlDescarga.Location = new Point(222, 77);
            txtUrlDescarga.MaxLength = 500;
            txtUrlDescarga.Name = "txtUrlDescarga";
            txtUrlDescarga.Size = new Size(300, 23);
            txtUrlDescarga.TabIndex = 32;
            // 
            // lblUrlDescarga
            // 
            lblUrlDescarga.AutoSize = true;
            lblUrlDescarga.Location = new Point(222, 59);
            lblUrlDescarga.Name = "lblUrlDescarga";
            lblUrlDescarga.Size = new Size(94, 15);
            lblUrlDescarga.TabIndex = 31;
            lblUrlDescarga.Text = "URL de descarga";
            // 
            // nudTamanioMB
            // 
            nudTamanioMB.DecimalPlaces = 2;
            nudTamanioMB.Location = new Point(10, 77);
            nudTamanioMB.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
            nudTamanioMB.Name = "nudTamanioMB";
            nudTamanioMB.Size = new Size(120, 23);
            nudTamanioMB.TabIndex = 30;
            // 
            // lblTamanioMB
            // 
            lblTamanioMB.AutoSize = true;
            lblTamanioMB.Location = new Point(10, 59);
            lblTamanioMB.Name = "lblTamanioMB";
            lblTamanioMB.Size = new Size(79, 15);
            lblTamanioMB.TabIndex = 29;
            lblTamanioMB.Text = "Tamaño (MB)";
            // 
            // cboFormato
            // 
            cboFormato.DropDownStyle = ComboBoxStyle.DropDownList;
            cboFormato.FormattingEnabled = true;
            cboFormato.Items.AddRange(new object[] { "PDF", "EPUB", "MOBI" });
            cboFormato.Location = new Point(222, 28);
            cboFormato.Name = "cboFormato";
            cboFormato.Size = new Size(121, 23);
            cboFormato.TabIndex = 28;
            // 
            // lblFormato
            // 
            lblFormato.AutoSize = true;
            lblFormato.Location = new Point(222, 7);
            lblFormato.Name = "lblFormato";
            lblFormato.Size = new Size(55, 15);
            lblFormato.TabIndex = 27;
            lblFormato.Text = "Formato:";
            // 
            // txtIdentificadorDigital
            // 
            txtIdentificadorDigital.Location = new Point(10, 28);
            txtIdentificadorDigital.MaxLength = 50;
            txtIdentificadorDigital.Name = "txtIdentificadorDigital";
            txtIdentificadorDigital.Size = new Size(200, 23);
            txtIdentificadorDigital.TabIndex = 26;
            // 
            // lblIdentificadorDigital
            // 
            lblIdentificadorDigital.AutoSize = true;
            lblIdentificadorDigital.Location = new Point(10, 8);
            lblIdentificadorDigital.Name = "lblIdentificadorDigital";
            lblIdentificadorDigital.Size = new Size(113, 15);
            lblIdentificadorDigital.TabIndex = 25;
            lblIdentificadorDigital.Text = "Identificador digital:";
            // 
            // frmLibros
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            ClientSize = new Size(1084, 861);
            Controls.Add(pnlLibroDigital);
            Controls.Add(pnlLibroFisico);
            Controls.Add(pnlListadoLibros);
            Controls.Add(flpTemasSeleccionados);
            Controls.Add(lstResultadosTemas);
            Controls.Add(txtBuscarTema);
            Controls.Add(flpAutoresSeleccionados);
            Controls.Add(lstResultadosAutores);
            Controls.Add(txtBuscarAutor);
            Controls.Add(btnCancelar);
            Controls.Add(btnEliminar);
            Controls.Add(btnEditar);
            Controls.Add(btnGuardar);
            Controls.Add(btnNuevo);
            Controls.Add(chkActivo);
            Controls.Add(cboEditorial);
            Controls.Add(lblEditorial);
            Controls.Add(nudPrecio);
            Controls.Add(lblPrecio);
            Controls.Add(nudAnio);
            Controls.Add(lblAnio);
            Controls.Add(txtDescripcion);
            Controls.Add(lblDescripcion);
            Controls.Add(txtTitulo);
            Controls.Add(lblTitulo);
            Controls.Add(cboTipoLibro);
            Controls.Add(lblTipoLibro);
            MinimumSize = new Size(900, 600);
            Name = "frmLibros";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Administración de Libros";
            WindowState = FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)nudAnio).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudPrecio).EndInit();
            pnlListadoLibros.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvLibros).EndInit();
            pnlLibroFisico.ResumeLayout(false);
            pnlLibroFisico.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nudStock).EndInit();
            pnlLibroDigital.ResumeLayout(false);
            pnlLibroDigital.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nudTamanioMB).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTipoLibro;
        private ComboBox cboTipoLibro;
        private Label lblTitulo;
        private TextBox txtTitulo;
        private Label lblDescripcion;
        private TextBox txtDescripcion;
        private Label lblAnio;
        private NumericUpDown nudAnio;
        private Label lblPrecio;
        private NumericUpDown nudPrecio;
        private Label lblEditorial;
        private ComboBox cboEditorial;
        private CheckBox chkActivo;
        private Button btnNuevo;
        private Button btnGuardar;
        private Button btnEditar;
        private Button btnEliminar;
        private Button btnCancelar;
        private TextBox txtBuscarAutor;
        private ListBox lstResultadosAutores;
        private FlowLayoutPanel flpAutoresSeleccionados;
        private FlowLayoutPanel flpTemasSeleccionados;
        private ListBox lstResultadosTemas;
        private TextBox txtBuscarTema;
        private Panel pnlListadoLibros;
        private DataGridView dgvLibros;
        private Panel pnlLibroFisico;
        private NumericUpDown nudStock;
        private Label lblStock;
        private TextBox txtISBN;
        private Label lblISBN;
        private Panel pnlLibroDigital;
        private TextBox txtUrlDescarga;
        private Label lblUrlDescarga;
        private NumericUpDown nudTamanioMB;
        private Label lblTamanioMB;
        private ComboBox cboFormato;
        private Label lblFormato;
        private TextBox txtIdentificadorDigital;
        private Label lblIdentificadorDigital;
    }
}