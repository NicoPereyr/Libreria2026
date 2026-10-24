namespace Libreria.Windows
{
    partial class frmAutores
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
                components.Dispose();

            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAutores));
            toolStrip1 = new ToolStrip();
            tsbNuevo = new ToolStripButton();
            tsbEditar = new ToolStripButton();
            tsbBorrar = new ToolStripButton();
            toolStripSeparator1 = new ToolStripSeparator();
            tsbActualizar = new ToolStripButton();
            tsbCerrar = new ToolStripButton();
            panelDatos = new Panel();
            labelNombre = new Label();
            txtNombre = new TextBox();
            labelApellido = new Label();
            txtApellido = new TextBox();
            labelFechaNacimiento = new Label();
            dtpFechaNacimiento = new DateTimePicker();
            labelNacionalidad = new Label();
            txtNacionalidad = new TextBox();
            btnGuardar = new Button();
            btnCancelar = new Button();
            dgvAutores = new DataGridView();
            panelInferior = new Panel();
            lblCantidad = new Label();
            toolStripLabel1 = new ToolStripLabel();
            txtBuscar = new ToolStripTextBox();
            tsbBuscar = new ToolStripButton();
            toolStrip1.SuspendLayout();
            panelDatos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvAutores).BeginInit();
            panelInferior.SuspendLayout();
            SuspendLayout();
            // 
            // toolStrip1
            // 
            toolStrip1.GripStyle = ToolStripGripStyle.Hidden;
            toolStrip1.ImageScalingSize = new Size(32, 32);
            toolStrip1.Items.AddRange(new ToolStripItem[] { tsbNuevo, tsbEditar, tsbBorrar, toolStripSeparator1, tsbActualizar, tsbCerrar, toolStripLabel1, txtBuscar, tsbBuscar });
            toolStrip1.Location = new Point(0, 0);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Padding = new Padding(5);
            toolStrip1.Size = new Size(900, 49);
            toolStrip1.TabIndex = 3;
            // 
            // tsbNuevo
            // 
            tsbNuevo.AutoSize = false;
            tsbNuevo.DisplayStyle = ToolStripItemDisplayStyle.Text;
            tsbNuevo.Name = "tsbNuevo";
            tsbNuevo.Size = new Size(90, 35);
            tsbNuevo.Text = "Nuevo";
            // 
            // tsbEditar
            // 
            tsbEditar.AutoSize = false;
            tsbEditar.DisplayStyle = ToolStripItemDisplayStyle.Text;
            tsbEditar.Name = "tsbEditar";
            tsbEditar.Size = new Size(90, 35);
            tsbEditar.Text = "Editar";
            // 
            // tsbBorrar
            // 
            tsbBorrar.AutoSize = false;
            tsbBorrar.DisplayStyle = ToolStripItemDisplayStyle.Text;
            tsbBorrar.Name = "tsbBorrar";
            tsbBorrar.Size = new Size(90, 35);
            tsbBorrar.Text = "Borrar";
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(6, 39);
            // 
            // tsbActualizar
            // 
            tsbActualizar.AutoSize = false;
            tsbActualizar.DisplayStyle = ToolStripItemDisplayStyle.Text;
            tsbActualizar.Name = "tsbActualizar";
            tsbActualizar.Size = new Size(90, 35);
            tsbActualizar.Text = "Actualizar";
            // 
            // tsbCerrar
            // 
            tsbCerrar.Alignment = ToolStripItemAlignment.Right;
            tsbCerrar.AutoSize = false;
            tsbCerrar.DisplayStyle = ToolStripItemDisplayStyle.Text;
            tsbCerrar.Name = "tsbCerrar";
            tsbCerrar.Size = new Size(90, 35);
            tsbCerrar.Text = "Cerrar";
            // 
            // panelDatos
            // 
            panelDatos.BackColor = Color.WhiteSmoke;
            panelDatos.Controls.Add(labelNombre);
            panelDatos.Controls.Add(txtNombre);
            panelDatos.Controls.Add(labelApellido);
            panelDatos.Controls.Add(txtApellido);
            panelDatos.Controls.Add(labelFechaNacimiento);
            panelDatos.Controls.Add(dtpFechaNacimiento);
            panelDatos.Controls.Add(labelNacionalidad);
            panelDatos.Controls.Add(txtNacionalidad);
            panelDatos.Controls.Add(btnGuardar);
            panelDatos.Controls.Add(btnCancelar);
            panelDatos.Dock = DockStyle.Top;
            panelDatos.Location = new Point(0, 49);
            panelDatos.Name = "panelDatos";
            panelDatos.Size = new Size(900, 210);
            panelDatos.TabIndex = 2;
            // 
            // labelNombre
            // 
            labelNombre.AutoSize = true;
            labelNombre.Location = new Point(25, 25);
            labelNombre.Name = "labelNombre";
            labelNombre.Size = new Size(54, 15);
            labelNombre.TabIndex = 0;
            labelNombre.Text = "Nombre:";
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(25, 48);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(280, 23);
            txtNombre.TabIndex = 0;
            // 
            // labelApellido
            // 
            labelApellido.AutoSize = true;
            labelApellido.Location = new Point(330, 25);
            labelApellido.Name = "labelApellido";
            labelApellido.Size = new Size(54, 15);
            labelApellido.TabIndex = 1;
            labelApellido.Text = "Apellido:";
            // 
            // txtApellido
            // 
            txtApellido.Location = new Point(330, 48);
            txtApellido.Name = "txtApellido";
            txtApellido.Size = new Size(250, 23);
            txtApellido.TabIndex = 1;
            // 
            // btnGuardar
            // 
            btnGuardar.Location = new Point(25, 155);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(110, 35);
            btnGuardar.TabIndex = 2;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = true;
            // Fecha de nacimiento
            labelFechaNacimiento.AutoSize = true;
            labelFechaNacimiento.Location = new Point(25, 90);
            labelFechaNacimiento.Name = "labelFechaNacimiento";
            labelFechaNacimiento.Text = "Fecha de nacimiento:";

            dtpFechaNacimiento.Location = new Point(25, 113);
            dtpFechaNacimiento.Name = "dtpFechaNacimiento";
            dtpFechaNacimiento.Size = new Size(280, 23);
            dtpFechaNacimiento.Format = DateTimePickerFormat.Short;

            // Nacionalidad
            labelNacionalidad.AutoSize = true;
            labelNacionalidad.Location = new Point(330, 90);
            labelNacionalidad.Name = "labelNacionalidad";
            labelNacionalidad.Text = "Nacionalidad:";

            txtNacionalidad.Location = new Point(330, 113);
            txtNacionalidad.Name = "txtNacionalidad";
            txtNacionalidad.Size = new Size(250, 23);
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new Point(150, 155);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(110, 35);
            btnCancelar.TabIndex = 3;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            // 
            // dgvAutores
            // 
            dgvAutores.AllowUserToAddRows = false;
            dgvAutores.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(235, 235, 235);
            dgvAutores.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dgvAutores.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvAutores.BackgroundColor = Color.White;
            dgvAutores.BorderStyle = BorderStyle.None;
            dgvAutores.Dock = DockStyle.Fill;
            dgvAutores.Location = new Point(0, 199);
            dgvAutores.MultiSelect = false;
            dgvAutores.Name = "dgvAutores";
            dgvAutores.ReadOnly = true;
            dgvAutores.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvAutores.Size = new Size(900, 306);
            dgvAutores.TabIndex = 0;
            // 
            // panelInferior
            // 
            panelInferior.BackColor = Color.WhiteSmoke;
            panelInferior.Controls.Add(lblCantidad);
            panelInferior.Dock = DockStyle.Bottom;
            panelInferior.Location = new Point(0, 505);
            panelInferior.Name = "panelInferior";
            panelInferior.Size = new Size(900, 45);
            panelInferior.TabIndex = 1;
            // 
            // lblCantidad
            // 
            lblCantidad.AutoSize = true;
            lblCantidad.Location = new Point(20, 15);
            lblCantidad.Name = "lblCantidad";
            lblCantidad.Size = new Size(131, 15);
            lblCantidad.TabIndex = 0;
            lblCantidad.Text = "Cantidad de registros: 0";
            // 
            // toolStripLabel1
            // 
            toolStripLabel1.Name = "toolStripLabel1";
            toolStripLabel1.Size = new Size(45, 36);
            toolStripLabel1.Text = "Buscar:";
            // 
            // txtBuscar
            // 
            txtBuscar.Name = "txtBuscar";
            txtBuscar.Size = new Size(150, 39);
            // 
            // tsbBuscar
            // 
            tsbBuscar.DisplayStyle = ToolStripItemDisplayStyle.Image;
            tsbBuscar.Image = (Image)resources.GetObject("tsbBuscar.Image");
            tsbBuscar.ImageTransparentColor = Color.Magenta;
            tsbBuscar.Name = "tsbBuscar";
            tsbBuscar.Size = new Size(36, 36);
            tsbBuscar.Text = "Buscar";
            // 
            // frmEditoriales
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(900, 550);
            Controls.Add(dgvAutores);
            Controls.Add(panelInferior);
            Controls.Add(panelDatos);
            Controls.Add(toolStrip1);
            Name = "frmAutores";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Gestión de Autores";
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            panelDatos.ResumeLayout(false);
            panelDatos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvAutores).EndInit();
            panelInferior.ResumeLayout(false);
            panelInferior.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ToolStrip toolStrip1;
        private ToolStripButton tsbNuevo;
        private ToolStripButton tsbEditar;
        private ToolStripButton tsbBorrar;
        private ToolStripButton tsbActualizar;
        private ToolStripButton tsbCerrar;
        private ToolStripSeparator toolStripSeparator1;

        private Panel panelDatos;
        private Label labelNombre;
        private TextBox txtNombre;
        private Label labelApellido;
        private TextBox txtApellido;
        private Label labelFechaNacimiento;
        private DateTimePicker dtpFechaNacimiento;
        private Label labelNacionalidad;
        private TextBox txtNacionalidad;

        private Button btnGuardar;
        private Button btnCancelar;

        private DataGridView dgvAutores;
        private Panel panelInferior;
        private Label lblCantidad;
        private ToolStripLabel toolStripLabel1;
        private ToolStripTextBox txtBuscar;
        private ToolStripButton tsbBuscar;
    }
}