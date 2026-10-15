namespace Libreria.Windows
{
    partial class frmEditoriales
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
            labelNombre = new Label();
            txtNombre = new TextBox();
            labelPaisOrigen = new Label();
            txtPaisOrigen = new TextBox();
            btnNuevo = new Button();
            btnGuardar = new Button();
            btnEditar = new Button();
            btnEliminar = new Button();
            btnCancelar = new Button();
            dgvEditoriales = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgvEditoriales).BeginInit();
            SuspendLayout();
            // 
            // labelNombre
            // 
            labelNombre.AutoSize = true;
            labelNombre.Location = new Point(36, 36);
            labelNombre.Name = "labelNombre";
            labelNombre.Size = new Size(54, 15);
            labelNombre.TabIndex = 0;
            labelNombre.Text = "Nombre:";
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(40, 54);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(100, 23);
            txtNombre.TabIndex = 1;
            // 
            // labelPaisOrigen
            // 
            labelPaisOrigen.AutoSize = true;
            labelPaisOrigen.Location = new Point(36, 88);
            labelPaisOrigen.Name = "labelPaisOrigen";
            labelPaisOrigen.Size = new Size(89, 15);
            labelPaisOrigen.TabIndex = 2;
            labelPaisOrigen.Text = "Pais  de Origen:";
            // 
            // txtPaisOrigen
            // 
            txtPaisOrigen.Location = new Point(36, 106);
            txtPaisOrigen.Name = "txtPaisOrigen";
            txtPaisOrigen.Size = new Size(100, 23);
            txtPaisOrigen.TabIndex = 3;
            // 
            // btnNuevo
            // 
            btnNuevo.Location = new Point(36, 152);
            btnNuevo.Name = "btnNuevo";
            btnNuevo.Size = new Size(75, 47);
            btnNuevo.TabIndex = 4;
            btnNuevo.Text = "Nuevo";
            btnNuevo.UseVisualStyleBackColor = true;
            // 
            // btnGuardar
            // 
            btnGuardar.Location = new Point(153, 152);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(75, 47);
            btnGuardar.TabIndex = 5;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = true;
            // 
            // btnEditar
            // 
            btnEditar.Location = new Point(261, 152);
            btnEditar.Name = "btnEditar";
            btnEditar.Size = new Size(75, 47);
            btnEditar.TabIndex = 6;
            btnEditar.Text = "Editar";
            btnEditar.UseVisualStyleBackColor = true;
            // 
            // btnEliminar
            // 
            btnEliminar.Location = new Point(375, 152);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(75, 47);
            btnEliminar.TabIndex = 7;
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseVisualStyleBackColor = true;
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new Point(490, 152);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(75, 47);
            btnCancelar.TabIndex = 8;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            // 
            // dgvEditoriales
            // 
            dgvEditoriales.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvEditoriales.Dock = DockStyle.Bottom;
            dgvEditoriales.Location = new Point(0, 222);
            dgvEditoriales.Name = "dgvEditoriales";
            dgvEditoriales.Size = new Size(800, 228);
            dgvEditoriales.TabIndex = 9;
            // 
            // frmEditoriales
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(dgvEditoriales);
            Controls.Add(btnCancelar);
            Controls.Add(btnEliminar);
            Controls.Add(btnEditar);
            Controls.Add(btnGuardar);
            Controls.Add(btnNuevo);
            Controls.Add(txtPaisOrigen);
            Controls.Add(labelPaisOrigen);
            Controls.Add(txtNombre);
            Controls.Add(labelNombre);
            Name = "frmEditoriales";
            Text = "frmEditoriales";
            ((System.ComponentModel.ISupportInitialize)dgvEditoriales).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label labelNombre;
        private TextBox txtNombre;
        private Label labelPaisOrigen;
        private TextBox txtPaisOrigen;
        private Button btnNuevo;
        private Button btnGuardar;
        private Button btnEditar;
        private Button btnEliminar;
        private Button btnCancelar;
        private DataGridView dgvEditoriales;
    }
}