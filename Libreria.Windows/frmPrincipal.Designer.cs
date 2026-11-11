
namespace Libreria.Windows
{
    partial class frmPrincipal
    {
        private System.ComponentModel.IContainer components = null;

        private Panel pnlMenu;
        private Panel pnlEncabezado;
        private Panel pnlContenido;
        private Panel pnlBienvenida;

        private TableLayoutPanel tblTarjetas;

        private Label lblLogo;
        private Label lblSubLogo;
        private Label lblMenu;
        private Label lblEncabezado;
        private Label lblSubEncabezado;
        private Label lblBienvenida;
        private Label lblDescripcion;
        private Label lblSeccion;
        private Label lblPie;

        private Button btnAutores;
        private Button btnEditoriales;
        private Button btnTemas;
        private Button btnLibros;
        private Button btnClientes;
        private Button btnVentas;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            pnlMenu = new Panel();
            pnlEncabezado = new Panel();
            pnlContenido = new Panel();
            pnlBienvenida = new Panel();

            tblTarjetas = new TableLayoutPanel();

            lblLogo = new Label();
            lblSubLogo = new Label();
            lblMenu = new Label();
            lblEncabezado = new Label();
            lblSubEncabezado = new Label();
            lblBienvenida = new Label();
            lblDescripcion = new Label();
            lblSeccion = new Label();
            lblPie = new Label();

            btnAutores = new Button();
            btnEditoriales = new Button();
            btnTemas = new Button();
            btnLibros = new Button();
            btnClientes = new Button();
            btnVentas = new Button();

            SuspendLayout();

            // ==========================================
            // MENÚ LATERAL
            // ==========================================

            pnlMenu.Name = "pnlMenu";
            pnlMenu.Dock = DockStyle.Left;
            pnlMenu.Width = 230;
            pnlMenu.BackColor = Color.FromArgb(23, 38, 59);

            // Logo
            lblLogo.Text = "LIBRERÍA 2026";
            lblLogo.Font = new Font(
                "Segoe UI", 17F, FontStyle.Bold);
            lblLogo.ForeColor = Color.White;
            lblLogo.Location = new Point(20, 25);
            lblLogo.Size = new Size(205, 35);

            lblSubLogo.Text = "Sistema de administración";
            lblSubLogo.Font = new Font(
                "Segoe UI", 9F);
            lblSubLogo.ForeColor =
                Color.FromArgb(165, 183, 205);
            lblSubLogo.Location = new Point(22, 65);
            lblSubLogo.Size = new Size(200, 25);

            lblMenu.Text = "MENÚ PRINCIPAL";
            lblMenu.Font = new Font(
                "Segoe UI", 9F, FontStyle.Bold);
            lblMenu.ForeColor =
                Color.FromArgb(135, 157, 182);
            lblMenu.Location = new Point(22, 125);
            lblMenu.Size = new Size(190, 25);

            // ==========================================
            // BOTONES DEL MENÚ
            // ==========================================

            btnLibros.Name = "btnLibros";
            btnLibros.Text = "  Libros";
            btnLibros.Location = new Point(12, 165);
            btnLibros.Size = new Size(206, 48);
            btnLibros.TabIndex = 0;

            btnAutores.Name = "btnAutores";
            btnAutores.Text = "  Autores";
            btnAutores.Location = new Point(12, 221);
            btnAutores.Size = new Size(206, 48);
            btnAutores.TabIndex = 1;

            btnEditoriales.Name = "btnEditoriales";
            btnEditoriales.Text = "  Editoriales";
            btnEditoriales.Location = new Point(12, 277);
            btnEditoriales.Size = new Size(206, 48);
            btnEditoriales.TabIndex = 2;

            btnTemas.Name = "btnTemas";
            btnTemas.Text = "  Temas";
            btnTemas.Location = new Point(12, 333);
            btnTemas.Size = new Size(206, 48);
            btnTemas.TabIndex = 3;

            btnClientes.Name = "btnClientes";
            btnClientes.Text = "  Clientes";
            btnClientes.Location = new Point(12, 389);
            btnClientes.Size = new Size(206, 48);
            btnClientes.TabIndex = 4;

            btnVentas.Name = "btnVentas";
            btnVentas.Text = "  Ventas";
            btnVentas.Location = new Point(12, 445);
            btnVentas.Size = new Size(206, 48);
            btnVentas.TabIndex = 5;

            // Estilo común del menú
            Button[] botones =
            {
                btnLibros,
                btnAutores,
                btnEditoriales,
                btnTemas,
                btnClientes,
                btnVentas
            };

            foreach (Button boton in botones)
            {
                boton.FlatStyle = FlatStyle.Flat;
                boton.FlatAppearance.BorderSize = 0;
                boton.FlatAppearance.MouseOverBackColor =
                    Color.FromArgb(48, 72, 103);

                boton.BackColor =
                    Color.FromArgb(23, 38, 59);

                boton.ForeColor = Color.White;
                boton.Font = new Font(
                    "Segoe UI", 11F);

                boton.TextAlign =
                    ContentAlignment.MiddleLeft;

                boton.Cursor = Cursors.Hand;
                boton.UseVisualStyleBackColor = false;

                boton.Anchor =
                    AnchorStyles.Top |
                    AnchorStyles.Left |
                    AnchorStyles.Right;
            }

            // Destacar Ventas
            btnVentas.BackColor =
                Color.FromArgb(37, 99, 180);

            btnVentas.FlatAppearance.MouseOverBackColor =
                Color.FromArgb(51, 119, 207);

            // Pie del menú
            lblPie.Text = "Librería 2026  |  Gestión";
            lblPie.ForeColor =
                Color.FromArgb(150, 168, 190);
            lblPie.Font = new Font("Segoe UI", 9F);
            lblPie.AutoSize = false;
            lblPie.Dock = DockStyle.Bottom;
            lblPie.Height = 50;
            lblPie.TextAlign =
                ContentAlignment.MiddleCenter;

            pnlMenu.Controls.Add(lblLogo);
            pnlMenu.Controls.Add(lblSubLogo);
            pnlMenu.Controls.Add(lblMenu);

            pnlMenu.Controls.Add(btnLibros);
            pnlMenu.Controls.Add(btnAutores);
            pnlMenu.Controls.Add(btnEditoriales);
            pnlMenu.Controls.Add(btnTemas);
            pnlMenu.Controls.Add(btnClientes);
            pnlMenu.Controls.Add(btnVentas);
            pnlMenu.Controls.Add(lblPie);

            // ==========================================
            // ENCABEZADO SUPERIOR
            // ==========================================

            pnlEncabezado.Name = "pnlEncabezado";
            pnlEncabezado.Dock = DockStyle.Top;
            pnlEncabezado.Height = 90;
            pnlEncabezado.BackColor = Color.White;
            pnlEncabezado.Padding = new Padding(28, 10, 20, 10);

            lblEncabezado.Text = "Panel principal";
            lblEncabezado.Font = new Font(
                "Segoe UI", 19F, FontStyle.Bold);
            lblEncabezado.ForeColor =
                Color.FromArgb(31, 46, 68);
            lblEncabezado.Location = new Point(28, 15);
            lblEncabezado.Size = new Size(400, 40);

            lblSubEncabezado.Text =
                "Administración y control de librería";
            lblSubEncabezado.Font = new Font(
                "Segoe UI", 10F);
            lblSubEncabezado.ForeColor =
                Color.FromArgb(115, 128, 145);
            lblSubEncabezado.Location = new Point(30, 58);
            lblSubEncabezado.Size = new Size(440, 25);

            pnlEncabezado.Controls.Add(lblEncabezado);
            pnlEncabezado.Controls.Add(lblSubEncabezado);

            // ==========================================
            // CONTENIDO CENTRAL
            // ==========================================

            pnlContenido.Name = "pnlContenido";
            pnlContenido.Dock = DockStyle.Fill;
            pnlContenido.BackColor =
                Color.FromArgb(243, 246, 251);
            pnlContenido.Padding = new Padding(30);

            // Tarjeta de bienvenida
            pnlBienvenida.Name = "pnlBienvenida";
            pnlBienvenida.Dock = DockStyle.Top;
            pnlBienvenida.Height = 150;
            pnlBienvenida.BackColor = Color.White;
            pnlBienvenida.Padding = new Padding(24);

            lblBienvenida.Text =
                "Bienvenido a Librería 2026";
            lblBienvenida.Font = new Font(
                "Segoe UI", 20F, FontStyle.Bold);
            lblBienvenida.ForeColor =
                Color.FromArgb(29, 48, 73);
            lblBienvenida.Location = new Point(25, 25);
            lblBienvenida.Size = new Size(550, 45);
            lblBienvenida.Anchor =
                AnchorStyles.Top |
                AnchorStyles.Left |
                AnchorStyles.Right;

            lblDescripcion.Text =
                "Gestioná libros, clientes y ventas " +
                "desde un solo lugar.\r\n" +
                "Seleccioná una opción del menú lateral " +
                "para comenzar.";

            lblDescripcion.Font = new Font(
                "Segoe UI", 11F);
            lblDescripcion.ForeColor =
                Color.FromArgb(105, 120, 140);
            lblDescripcion.Location = new Point(27, 80);
            lblDescripcion.Size = new Size(560, 55);
            lblDescripcion.Anchor =
                AnchorStyles.Top |
                AnchorStyles.Left |
                AnchorStyles.Right;

            pnlBienvenida.Controls.Add(lblBienvenida);
            pnlBienvenida.Controls.Add(lblDescripcion);

            // Título de la sección
            lblSeccion.Text = "Áreas de administración";
            lblSeccion.Font = new Font(
                "Segoe UI", 14F, FontStyle.Bold);
            lblSeccion.ForeColor =
                Color.FromArgb(31, 46, 68);
            lblSeccion.Dock = DockStyle.Top;
            lblSeccion.Height = 65;
            lblSeccion.TextAlign =
                ContentAlignment.BottomLeft;

            // ==========================================
            // TARJETAS INFORMATIVAS
            // ==========================================

            tblTarjetas.Name = "tblTarjetas";
            tblTarjetas.Dock = DockStyle.Top;
            tblTarjetas.Height = 165;
            tblTarjetas.ColumnCount = 3;
            tblTarjetas.RowCount = 1;
            tblTarjetas.BackColor =
                Color.FromArgb(243, 246, 251);

            tblTarjetas.ColumnStyles.Add(
                new ColumnStyle(SizeType.Percent, 33.33F));
            tblTarjetas.ColumnStyles.Add(
                new ColumnStyle(SizeType.Percent, 33.34F));
            tblTarjetas.ColumnStyles.Add(
                new ColumnStyle(SizeType.Percent, 33.33F));

            Panel tarjetaLibros = new Panel();
            tarjetaLibros.Dock = DockStyle.Fill;
            tarjetaLibros.BackColor = Color.White;
            tarjetaLibros.Margin = new Padding(0, 8, 10, 8);

            Panel tarjetaClientes = new Panel();
            tarjetaClientes.Dock = DockStyle.Fill;
            tarjetaClientes.BackColor = Color.White;
            tarjetaClientes.Margin = new Padding(5, 8, 5, 8);

            Panel tarjetaVentas = new Panel();
            tarjetaVentas.Dock = DockStyle.Fill;
            tarjetaVentas.BackColor = Color.White;
            tarjetaVentas.Margin = new Padding(10, 8, 0, 8);

            // Tarjeta Libros
            Label tituloLibros = new Label();
            tituloLibros.Text = "LIBROS";
            tituloLibros.Font = new Font(
                "Segoe UI", 11F, FontStyle.Bold);
            tituloLibros.ForeColor =
                Color.FromArgb(42, 102, 185);
            tituloLibros.Location = new Point(18, 22);
            tituloLibros.Size = new Size(180, 28);

            Label descLibros = new Label();
            descLibros.Text =
                "Catálogo de libros\r\nfísicos y digitales";
            descLibros.Font = new Font(
                "Segoe UI", 10F);
            descLibros.ForeColor =
                Color.FromArgb(105, 120, 140);
            descLibros.Location = new Point(18, 65);
            descLibros.Size = new Size(200, 55);
            descLibros.Anchor =
                AnchorStyles.Top |
                AnchorStyles.Left |
                AnchorStyles.Right;

            tarjetaLibros.Controls.Add(tituloLibros);
            tarjetaLibros.Controls.Add(descLibros);

            // Tarjeta Clientes
            Label tituloClientes = new Label();
            tituloClientes.Text = "CLIENTES";
            tituloClientes.Font = new Font(
                "Segoe UI", 11F, FontStyle.Bold);
            tituloClientes.ForeColor =
                Color.FromArgb(42, 102, 185);
            tituloClientes.Location = new Point(18, 22);
            tituloClientes.Size = new Size(180, 28);

            Label descClientes = new Label();
            descClientes.Text =
                "Registro, administración\r\ny seguimiento de clientes";
            descClientes.Font = new Font(
                "Segoe UI", 10F);
            descClientes.ForeColor =
                Color.FromArgb(105, 120, 140);
            descClientes.Location = new Point(18, 65);
            descClientes.Size = new Size(200, 55);
            descClientes.Anchor =
                AnchorStyles.Top |
                AnchorStyles.Left |
                AnchorStyles.Right;

            tarjetaClientes.Controls.Add(tituloClientes);
            tarjetaClientes.Controls.Add(descClientes);

            // Tarjeta Ventas
            Label tituloVentas = new Label();
            tituloVentas.Text = "VENTAS";
            tituloVentas.Font = new Font(
                "Segoe UI", 11F, FontStyle.Bold);
            tituloVentas.ForeColor =
                Color.FromArgb(42, 102, 185);
            tituloVentas.Location = new Point(18, 22);
            tituloVentas.Size = new Size(180, 28);

            Label descVentas = new Label();
            descVentas.Text =
                "Registro de operaciones\r\ny control de stock";
            descVentas.Font = new Font(
                "Segoe UI", 10F);
            descVentas.ForeColor =
                Color.FromArgb(105, 120, 140);
            descVentas.Location = new Point(18, 65);
            descVentas.Size = new Size(200, 55);
            descVentas.Anchor =
                AnchorStyles.Top |
                AnchorStyles.Left |
                AnchorStyles.Right;

            tarjetaVentas.Controls.Add(tituloVentas);
            tarjetaVentas.Controls.Add(descVentas);

            tblTarjetas.Controls.Add(tarjetaLibros, 0, 0);
            tblTarjetas.Controls.Add(tarjetaClientes, 1, 0);
            tblTarjetas.Controls.Add(tarjetaVentas, 2, 0);

            // Orden de controles Dock.Top
            pnlContenido.Controls.Add(tblTarjetas);
            pnlContenido.Controls.Add(lblSeccion);
            pnlContenido.Controls.Add(pnlBienvenida);

            // ==========================================
            // FORMULARIO PRINCIPAL
            // ==========================================

            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;

            ClientSize = new Size(1100, 680);

            MinimumSize = new Size(850, 550);

            BackColor =
                Color.FromArgb(243, 246, 251);

            FormBorderStyle = FormBorderStyle.Sizable;
            MaximizeBox = true;
            WindowState = FormWindowState.Maximized;

            StartPosition = FormStartPosition.CenterScreen;

            Name = "frmPrincipal";
            Text = "Librería 2026 - Sistema de Gestión";

            // Orden de acoplamiento
            Controls.Add(pnlContenido);
            Controls.Add(pnlEncabezado);
            Controls.Add(pnlMenu);

            ResumeLayout(false);
        }

        #endregion
    }
}
