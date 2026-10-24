namespace Libreria.Windows
{
    partial class frmPrincipal
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
            btnAutores = new Button();
            btnEditoriales = new Button();
            btnTemas = new Button();
            SuspendLayout();
            // 
            // btnAutores
            // 
            btnAutores.Location = new Point(99, 153);
            btnAutores.Name = "btnAutores";
            btnAutores.Size = new Size(160, 70);
            btnAutores.TabIndex = 0;
            btnAutores.Text = "Autores";
            btnAutores.UseVisualStyleBackColor = true;
            // 
            // btnEditoriales
            // 
            btnEditoriales.Location = new Point(280, 153);
            btnEditoriales.Name = "btnEditoriales";
            btnEditoriales.Size = new Size(160, 70);
            btnEditoriales.TabIndex = 1;
            btnEditoriales.Text = "Editoriales";
            btnEditoriales.UseVisualStyleBackColor = true;
            // 
            // btnTemas
            // 
            btnTemas.Location = new Point(462, 153);
            btnTemas.Name = "btnTemas";
            btnTemas.Size = new Size(160, 70);
            btnTemas.TabIndex = 2;
            btnTemas.Text = "Temas";
            btnTemas.UseVisualStyleBackColor = true;
            // 
            // frmPrincipal
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(634, 361);
            Controls.Add(btnTemas);
            Controls.Add(btnEditoriales);
            Controls.Add(btnAutores);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "frmPrincipal";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Librería 2026 - Menú Principal";
            ResumeLayout(false);
        }

        #endregion

        private Button btnAutores;
        private Button btnEditoriales;
        private Button btnTemas;
    }
}