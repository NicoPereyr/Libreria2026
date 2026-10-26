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
            lblISBN = new Label();
            txtISBN = new TextBox();
            lblStock = new Label();
            nudStock = new NumericUpDown();
            lblIdentificadorDigital = new Label();
            txtIdentificadorDigital = new TextBox();
            lblFormato = new Label();
            cboFormato = new ComboBox();
            lblTamanioMB = new Label();
            nudTamanioMB = new NumericUpDown();
            lblUrlDescarga = new Label();
            txtUrlDescarga = new TextBox();
            clbAutores = new CheckedListBox();
            lblAutores = new Label();
            lblTemas = new Label();
            clbTemas = new CheckedListBox();
            btnNuevo = new Button();
            btnGuardar = new Button();
            btnEditar = new Button();
            btnEliminar = new Button();
            btnCancelar = new Button();
            dgvLibros = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)nudAnio).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudPrecio).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudStock).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudTamanioMB).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvLibros).BeginInit();
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
            txtDescripcion.Multiline = true;
            txtDescripcion.Name = "txtDescripcion";
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
            // lblISBN
            // 
            lblISBN.AutoSize = true;
            lblISBN.Location = new Point(11, 349);
            lblISBN.Name = "lblISBN";
            lblISBN.Size = new Size(35, 15);
            lblISBN.TabIndex = 13;
            lblISBN.Text = "ISBN:";
            // 
            // txtISBN
            // 
            txtISBN.Location = new Point(52, 346);
            txtISBN.Name = "txtISBN";
            txtISBN.Size = new Size(200, 23);
            txtISBN.TabIndex = 14;
            // 
            // lblStock
            // 
            lblStock.AutoSize = true;
            lblStock.Location = new Point(11, 395);
            lblStock.Name = "lblStock";
            lblStock.Size = new Size(39, 15);
            lblStock.TabIndex = 15;
            lblStock.Text = "Stock:";
            // 
            // nudStock
            // 
            nudStock.Location = new Point(56, 393);
            nudStock.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
            nudStock.Name = "nudStock";
            nudStock.Size = new Size(120, 23);
            nudStock.TabIndex = 16;
            // 
            // lblIdentificadorDigital
            // 
            lblIdentificadorDigital.AutoSize = true;
            lblIdentificadorDigital.Location = new Point(11, 430);
            lblIdentificadorDigital.Name = "lblIdentificadorDigital";
            lblIdentificadorDigital.Size = new Size(113, 15);
            lblIdentificadorDigital.TabIndex = 17;
            lblIdentificadorDigital.Text = "Identificador digital:";
            // 
            // txtIdentificadorDigital
            // 
            txtIdentificadorDigital.Location = new Point(130, 427);
            txtIdentificadorDigital.Name = "txtIdentificadorDigital";
            txtIdentificadorDigital.Size = new Size(200, 23);
            txtIdentificadorDigital.TabIndex = 18;
            // 
            // lblFormato
            // 
            lblFormato.AutoSize = true;
            lblFormato.Location = new Point(11, 466);
            lblFormato.Name = "lblFormato";
            lblFormato.Size = new Size(55, 15);
            lblFormato.TabIndex = 19;
            lblFormato.Text = "Formato:";
            // 
            // cboFormato
            // 
            cboFormato.DropDownStyle = ComboBoxStyle.DropDownList;
            cboFormato.FormattingEnabled = true;
            cboFormato.Items.AddRange(new object[] { "PDF", "EPUB", "MOBI" });
            cboFormato.Location = new Point(72, 463);
            cboFormato.Name = "cboFormato";
            cboFormato.Size = new Size(121, 23);
            cboFormato.TabIndex = 20;
            // 
            // lblTamanioMB
            // 
            lblTamanioMB.AutoSize = true;
            lblTamanioMB.Location = new Point(11, 500);
            lblTamanioMB.Name = "lblTamanioMB";
            lblTamanioMB.Size = new Size(79, 15);
            lblTamanioMB.TabIndex = 21;
            lblTamanioMB.Text = "Tamaño (MB)";
            // 
            // nudTamanioMB
            // 
            nudTamanioMB.DecimalPlaces = 2;
            nudTamanioMB.Location = new Point(96, 498);
            nudTamanioMB.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
            nudTamanioMB.Name = "nudTamanioMB";
            nudTamanioMB.Size = new Size(120, 23);
            nudTamanioMB.TabIndex = 22;
            // 
            // lblUrlDescarga
            // 
            lblUrlDescarga.AutoSize = true;
            lblUrlDescarga.Location = new Point(11, 532);
            lblUrlDescarga.Name = "lblUrlDescarga";
            lblUrlDescarga.Size = new Size(94, 15);
            lblUrlDescarga.TabIndex = 23;
            lblUrlDescarga.Text = "URL de descarga";
            // 
            // txtUrlDescarga
            // 
            txtUrlDescarga.Location = new Point(111, 529);
            txtUrlDescarga.Name = "txtUrlDescarga";
            txtUrlDescarga.Size = new Size(300, 23);
            txtUrlDescarga.TabIndex = 24;
            // 
            // clbAutores
            // 
            clbAutores.CheckOnClick = true;
            clbAutores.FormattingEnabled = true;
            clbAutores.Location = new Point(477, 75);
            clbAutores.Name = "clbAutores";
            clbAutores.Size = new Size(250, 148);
            clbAutores.TabIndex = 25;
            // 
            // lblAutores
            // 
            lblAutores.AutoSize = true;
            lblAutores.Location = new Point(477, 48);
            lblAutores.Name = "lblAutores";
            lblAutores.Size = new Size(51, 15);
            lblAutores.TabIndex = 26;
            lblAutores.Text = "Autores:";
            // 
            // lblTemas
            // 
            lblTemas.AutoSize = true;
            lblTemas.Location = new Point(477, 269);
            lblTemas.Name = "lblTemas";
            lblTemas.Size = new Size(44, 15);
            lblTemas.TabIndex = 27;
            lblTemas.Text = "Temas:";
            // 
            // clbTemas
            // 
            clbTemas.CheckOnClick = true;
            clbTemas.FormattingEnabled = true;
            clbTemas.Location = new Point(477, 297);
            clbTemas.Name = "clbTemas";
            clbTemas.Size = new Size(250, 148);
            clbTemas.TabIndex = 28;
            // 
            // btnNuevo
            // 
            btnNuevo.Location = new Point(13, 578);
            btnNuevo.Name = "btnNuevo";
            btnNuevo.Size = new Size(100, 23);
            btnNuevo.TabIndex = 29;
            btnNuevo.Text = "Nuevo";
            btnNuevo.UseVisualStyleBackColor = true;
            // 
            // btnGuardar
            // 
            btnGuardar.Location = new Point(139, 578);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(100, 23);
            btnGuardar.TabIndex = 30;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = true;
            // 
            // btnEditar
            // 
            btnEditar.Location = new Point(262, 578);
            btnEditar.Name = "btnEditar";
            btnEditar.Size = new Size(100, 23);
            btnEditar.TabIndex = 31;
            btnEditar.Text = "Editar";
            btnEditar.UseVisualStyleBackColor = true;
            // 
            // btnEliminar
            // 
            btnEliminar.Location = new Point(383, 578);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(100, 23);
            btnEliminar.TabIndex = 32;
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseVisualStyleBackColor = true;
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new Point(502, 578);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(100, 23);
            btnCancelar.TabIndex = 33;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            // 
            // dgvLibros
            // 
            dgvLibros.AllowUserToAddRows = false;
            dgvLibros.AllowUserToDeleteRows = false;
            dgvLibros.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvLibros.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvLibros.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvLibros.Location = new Point(20, 650);
            dgvLibros.MultiSelect = false;
            dgvLibros.Name = "dgvLibros";
            dgvLibros.ReadOnly = true;
            dgvLibros.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvLibros.Size = new Size(1040, 200);
            dgvLibros.TabIndex = 34;
            // 
            // frmLibros
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1084, 861);
            Controls.Add(dgvLibros);
            Controls.Add(btnCancelar);
            Controls.Add(btnEliminar);
            Controls.Add(btnEditar);
            Controls.Add(btnGuardar);
            Controls.Add(btnNuevo);
            Controls.Add(clbTemas);
            Controls.Add(lblTemas);
            Controls.Add(lblAutores);
            Controls.Add(clbAutores);
            Controls.Add(txtUrlDescarga);
            Controls.Add(lblUrlDescarga);
            Controls.Add(nudTamanioMB);
            Controls.Add(lblTamanioMB);
            Controls.Add(cboFormato);
            Controls.Add(lblFormato);
            Controls.Add(txtIdentificadorDigital);
            Controls.Add(lblIdentificadorDigital);
            Controls.Add(nudStock);
            Controls.Add(lblStock);
            Controls.Add(txtISBN);
            Controls.Add(lblISBN);
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
            ((System.ComponentModel.ISupportInitialize)nudAnio).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudPrecio).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudStock).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudTamanioMB).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvLibros).EndInit();
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
        private Label lblISBN;
        private TextBox txtISBN;
        private Label lblStock;
        private NumericUpDown nudStock;
        private Label lblIdentificadorDigital;
        private TextBox txtIdentificadorDigital;
        private Label lblFormato;
        private ComboBox cboFormato;
        private Label lblTamanioMB;
        private NumericUpDown nudTamanioMB;
        private Label lblUrlDescarga;
        private TextBox txtUrlDescarga;
        private CheckedListBox clbAutores;
        private Label lblAutores;
        private Label lblTemas;
        private CheckedListBox clbTemas;
        private Button btnNuevo;
        private Button btnGuardar;
        private Button btnEditar;
        private Button btnEliminar;
        private Button btnCancelar;
        private DataGridView dgvLibros;
    }
}