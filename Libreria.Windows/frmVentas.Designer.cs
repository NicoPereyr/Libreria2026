namespace Libreria.Windows
{
    partial class frmVentas
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
            lblCliente = new Label();
            cboClientes = new ComboBox();
            cboLibros = new ComboBox();
            lblLibro = new Label();
            lblCantidad = new Label();
            nudCantidad = new NumericUpDown();
            btnAgregarLibro = new Button();
            btnQuitarLibro = new Button();
            dgvDetalleVenta = new DataGridView();
            lblTotal = new Label();
            btnRegistrarVenta = new Button();
            btnNuevaVenta = new Button();
            btnHistorialVentas = new Button();
            ((System.ComponentModel.ISupportInitialize)nudCantidad).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvDetalleVenta).BeginInit();
            SuspendLayout();
            // 
            // lblCliente
            // 
            lblCliente.AutoSize = true;
            lblCliente.Location = new Point(42, 26);
            lblCliente.Name = "lblCliente";
            lblCliente.Size = new Size(44, 15);
            lblCliente.TabIndex = 0;
            lblCliente.Text = "Cliente";
            // 
            // cboClientes
            // 
            cboClientes.DropDownStyle = ComboBoxStyle.DropDownList;
            cboClientes.FormattingEnabled = true;
            cboClientes.Location = new Point(42, 44);
            cboClientes.Name = "cboClientes";
            cboClientes.Size = new Size(300, 23);
            cboClientes.TabIndex = 1;
            // 
            // cboLibros
            // 
            cboLibros.DropDownStyle = ComboBoxStyle.DropDownList;
            cboLibros.FormattingEnabled = true;
            cboLibros.Location = new Point(42, 108);
            cboLibros.Name = "cboLibros";
            cboLibros.Size = new Size(400, 23);
            cboLibros.TabIndex = 3;
            // 
            // lblLibro
            // 
            lblLibro.AutoSize = true;
            lblLibro.Location = new Point(42, 90);
            lblLibro.Name = "lblLibro";
            lblLibro.Size = new Size(34, 15);
            lblLibro.TabIndex = 2;
            lblLibro.Text = "Libro";
            // 
            // lblCantidad
            // 
            lblCantidad.AutoSize = true;
            lblCantidad.Location = new Point(474, 90);
            lblCantidad.Name = "lblCantidad";
            lblCantidad.Size = new Size(55, 15);
            lblCantidad.TabIndex = 4;
            lblCantidad.Text = "Cantidad";
            // 
            // nudCantidad
            // 
            nudCantidad.Location = new Point(474, 108);
            nudCantidad.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            nudCantidad.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            nudCantidad.Name = "nudCantidad";
            nudCantidad.Size = new Size(120, 23);
            nudCantidad.TabIndex = 5;
            nudCantidad.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // btnAgregarLibro
            // 
            btnAgregarLibro.Location = new Point(44, 155);
            btnAgregarLibro.Name = "btnAgregarLibro";
            btnAgregarLibro.Size = new Size(90, 23);
            btnAgregarLibro.TabIndex = 6;
            btnAgregarLibro.Text = "Agregar libro";
            btnAgregarLibro.UseVisualStyleBackColor = true;
            // 
            // btnQuitarLibro
            // 
            btnQuitarLibro.Location = new Point(154, 155);
            btnQuitarLibro.Name = "btnQuitarLibro";
            btnQuitarLibro.Size = new Size(94, 23);
            btnQuitarLibro.TabIndex = 7;
            btnQuitarLibro.Text = "Quitar libro";
            btnQuitarLibro.UseVisualStyleBackColor = true;
            // 
            // dgvDetalleVenta
            // 
            dgvDetalleVenta.AllowUserToAddRows = false;
            dgvDetalleVenta.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvDetalleVenta.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvDetalleVenta.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDetalleVenta.Location = new Point(42, 204);
            dgvDetalleVenta.MultiSelect = false;
            dgvDetalleVenta.Name = "dgvDetalleVenta";
            dgvDetalleVenta.ReadOnly = true;
            dgvDetalleVenta.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvDetalleVenta.Size = new Size(790, 260);
            dgvDetalleVenta.TabIndex = 8;
            // 
            // lblTotal
            // 
            lblTotal.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            lblTotal.AutoSize = true;
            lblTotal.Location = new Point(12, 505);
            lblTotal.Name = "lblTotal";
            lblTotal.Size = new Size(60, 15);
            lblTotal.TabIndex = 9;
            lblTotal.Text = "Total: 0,00";
            // 
            // btnRegistrarVenta
            // 
            btnRegistrarVenta.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnRegistrarVenta.Location = new Point(653, 505);
            btnRegistrarVenta.Name = "btnRegistrarVenta";
            btnRegistrarVenta.Size = new Size(97, 23);
            btnRegistrarVenta.TabIndex = 10;
            btnRegistrarVenta.Text = "Registrar venta";
            btnRegistrarVenta.UseVisualStyleBackColor = true;
            // 
            // btnNuevaVenta
            // 
            btnNuevaVenta.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnNuevaVenta.Location = new Point(769, 505);
            btnNuevaVenta.Name = "btnNuevaVenta";
            btnNuevaVenta.Size = new Size(84, 23);
            btnNuevaVenta.TabIndex = 11;
            btnNuevaVenta.Text = "Nueva venta";
            btnNuevaVenta.UseVisualStyleBackColor = true;
            // 
            // btnHistorialVentas
            // 
            btnHistorialVentas.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnHistorialVentas.Location = new Point(519, 505);
            btnHistorialVentas.Name = "btnHistorialVentas";
            btnHistorialVentas.Size = new Size(115, 23);
            btnHistorialVentas.TabIndex = 12;
            btnHistorialVentas.Text = "Historial de Ventas";
            btnHistorialVentas.UseVisualStyleBackColor = true;
            // 
            // frmVentas
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            ClientSize = new Size(884, 561);
            Controls.Add(btnHistorialVentas);
            Controls.Add(btnNuevaVenta);
            Controls.Add(btnRegistrarVenta);
            Controls.Add(lblTotal);
            Controls.Add(dgvDetalleVenta);
            Controls.Add(btnQuitarLibro);
            Controls.Add(btnAgregarLibro);
            Controls.Add(nudCantidad);
            Controls.Add(lblCantidad);
            Controls.Add(cboLibros);
            Controls.Add(lblLibro);
            Controls.Add(cboClientes);
            Controls.Add(lblCliente);
            MinimumSize = new Size(900, 600);
            Name = "frmVentas";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Gestión de Ventas";
            WindowState = FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)nudCantidad).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvDetalleVenta).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblCliente;
        private ComboBox cboClientes;
        private ComboBox cboLibros;
        private Label lblLibro;
        private Label lblCantidad;
        private NumericUpDown nudCantidad;
        private Button btnAgregarLibro;
        private Button btnQuitarLibro;
        private DataGridView dgvDetalleVenta;
        private Label lblTotal;
        private Button btnRegistrarVenta;
        private Button btnNuevaVenta;
        private Button btnHistorialVentas;
    }
}