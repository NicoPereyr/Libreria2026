namespace Libreria.Windows
{
    partial class frmListadoVentas
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
            dgvVentas = new DataGridView();
            dgvDetalles = new DataGridView();
            btnVerDetalles = new Button();
            btnAnularVenta = new Button();
            btnActualizar = new Button();
            lblVentas = new Label();
            lblDetalles = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvVentas).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvDetalles).BeginInit();
            SuspendLayout();
            // 
            // dgvVentas
            // 
            dgvVentas.AllowUserToAddRows = false;
            dgvVentas.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            dgvVentas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvVentas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvVentas.Location = new Point(30, 80);
            dgvVentas.MultiSelect = false;
            dgvVentas.Name = "dgvVentas";
            dgvVentas.ReadOnly = true;
            dgvVentas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvVentas.Size = new Size(760, 170);
            dgvVentas.TabIndex = 0;
            // 
            // dgvDetalles
            // 
            dgvDetalles.AllowUserToAddRows = false;
            dgvDetalles.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvDetalles.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvDetalles.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDetalles.Location = new Point(30, 340);
            dgvDetalles.MultiSelect = false;
            dgvDetalles.Name = "dgvDetalles";
            dgvDetalles.ReadOnly = true;
            dgvDetalles.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvDetalles.Size = new Size(760, 210);
            dgvDetalles.TabIndex = 1;
            // 
            // btnVerDetalles
            // 
            btnVerDetalles.Location = new Point(30, 275);
            btnVerDetalles.Name = "btnVerDetalles";
            btnVerDetalles.Size = new Size(75, 23);
            btnVerDetalles.TabIndex = 2;
            btnVerDetalles.Text = "Ver detalles";
            btnVerDetalles.UseVisualStyleBackColor = true;
            // 
            // btnAnularVenta
            // 
            btnAnularVenta.Location = new Point(127, 275);
            btnAnularVenta.Name = "btnAnularVenta";
            btnAnularVenta.Size = new Size(82, 23);
            btnAnularVenta.TabIndex = 3;
            btnAnularVenta.Text = "Anular venta";
            btnAnularVenta.UseVisualStyleBackColor = true;
            // 
            // btnActualizar
            // 
            btnActualizar.Location = new Point(229, 275);
            btnActualizar.Name = "btnActualizar";
            btnActualizar.Size = new Size(75, 23);
            btnActualizar.TabIndex = 4;
            btnActualizar.Text = "Actualizar";
            btnActualizar.UseVisualStyleBackColor = true;
            // 
            // lblVentas
            // 
            lblVentas.AutoSize = true;
            lblVentas.Location = new Point(27, 62);
            lblVentas.Name = "lblVentas";
            lblVentas.Size = new Size(101, 15);
            lblVentas.TabIndex = 5;
            lblVentas.Text = "Ventas registradas";
            // 
            // lblDetalles
            // 
            lblDetalles.AutoSize = true;
            lblDetalles.Location = new Point(30, 322);
            lblDetalles.Name = "lblDetalles";
            lblDetalles.Size = new Size(108, 15);
            lblDetalles.TabIndex = 6;
            lblDetalles.Text = "Detalles de la venta";
            // 
            // frmListadoVentas
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(884, 561);
            Controls.Add(lblDetalles);
            Controls.Add(lblVentas);
            Controls.Add(btnActualizar);
            Controls.Add(btnAnularVenta);
            Controls.Add(btnVerDetalles);
            Controls.Add(dgvDetalles);
            Controls.Add(dgvVentas);
            MinimumSize = new Size(900, 600);
            Name = "frmListadoVentas";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Historial de Ventas";
            WindowState = FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)dgvVentas).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvDetalles).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvVentas;
        private DataGridView dgvDetalles;
        private Button btnVerDetalles;
        private Button btnAnularVenta;
        private Button btnActualizar;
        private Label lblVentas;
        private Label lblDetalles;
    }
}