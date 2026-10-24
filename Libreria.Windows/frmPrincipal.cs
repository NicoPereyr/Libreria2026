
using Microsoft.Extensions.DependencyInjection;

namespace Libreria.Windows
{
    public partial class frmPrincipal : Form
    {
        private readonly IServiceProvider _serviceProvider;

        public frmPrincipal(IServiceProvider serviceProvider)
        {
            InitializeComponent();

            _serviceProvider = serviceProvider;

            // Eventos de los botones
            btnEditoriales.Click += btnEditoriales_Click;
            btnAutores.Click += btnAutores_Click;
            btnTemas.Click += btnTemas_Click;
        }

        private void btnEditoriales_Click(object? sender, EventArgs e)
        {
            using var scope = _serviceProvider.CreateScope();

            using var formulario = scope.ServiceProvider
                .GetRequiredService<frmEditoriales>();

            formulario.ShowDialog(this);
        }

        private void btnAutores_Click(object? sender, EventArgs e)
        {
            using var scope = _serviceProvider.CreateScope();

            using var formulario = scope.ServiceProvider
                .GetRequiredService<frmAutores>();

            formulario.ShowDialog(this);
        }

        private void btnTemas_Click(object? sender, EventArgs e)
        {
            MessageBox.Show(
                "Próximamente: Gestión de Temas",
                "Información",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }
    }
}

