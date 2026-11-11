
using Libreria.Datos.Interfaces;
using Libreria.Servicios.Interfaces;
namespace Libreria.Windows
{
    public partial class frmListadoVentas : Form
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IVentaServicio _ventaServicio;

        public frmListadoVentas(
            IUnitOfWork unitOfWork,
            IVentaServicio ventaServicio)
        {
            InitializeComponent();

            _unitOfWork = unitOfWork;
            _ventaServicio = ventaServicio;

            this.Load += frmListadoVentas_Load;
            btnVerDetalles.Click += btnVerDetalles_Click;
            btnAnularVenta.Click += btnAnularVenta_Click;
            btnActualizar.Click += btnActualizar_Click;
        }


        private void frmListadoVentas_Load(object? sender, EventArgs e)
        {
            CargarVentas();
        }

        private void CargarVentas()
        {
            try
            {
                var ventas = _unitOfWork.Ventas.ObtenerTodos();

                var clientes = _unitOfWork.Clientes.ObtenerTodos();

                var listado = ventas.Select(v => new
                {
                    v.VentaId,
                    v.FechaVenta,
                    Cliente = clientes
                        .Where(c => c.ClienteId == v.ClienteId)
                        .Select(c => $"{c.Nombre} {c.Apellido}")
                        .FirstOrDefault() ?? "Sin cliente",
                    v.Total,
                    v.Anulada
                }).ToList();

                dgvVentas.DataSource = null;
                dgvVentas.DataSource = listado;

                dgvVentas.ClearSelection();
                dgvDetalles.DataSource = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Error al cargar ventas",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void btnVerDetalles_Click(object? sender, EventArgs e)
        {
            try
            {
                if (dgvVentas.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Seleccioná una venta para ver sus detalles.");
                    return;
                }

                // Obtener el identificador de la venta seleccionada
                var valorId = dgvVentas.SelectedRows[0]
                    .Cells["VentaId"].Value;

                if (valorId == null)
                {
                    MessageBox.Show("No se pudo identificar la venta.");
                    return;
                }

                int ventaId = Convert.ToInt32(valorId);

                // Obtener los detalles de esa venta
                var detalles = _unitOfWork.DetalleVentas.ObtenerTodos()
                    .Where(d => d.VentaId == ventaId)
                    .ToList();

                // Obtener los libros para mostrar sus títulos
                var libros = _unitOfWork.Libros.ObtenerTodos();

                var listado = detalles.Select(d => new
                {
                    Libro = libros
                        .Where(l => l.LibroId == d.LibroId)
                        .Select(l => l.Titulo)
                        .FirstOrDefault() ?? "Libro no encontrado",

                    d.Cantidad,
                    d.PrecioUnitario,
                    d.Subtotal
                }).ToList();

                dgvDetalles.DataSource = null;
                dgvDetalles.DataSource = listado;

                dgvDetalles.ClearSelection();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Error al consultar detalles",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void btnAnularVenta_Click(object? sender, EventArgs e)
        {
            try
            {
                if (dgvVentas.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Seleccioná una venta para anular.");
                    return;
                }

                var fila = dgvVentas.SelectedRows[0];

                int ventaId = Convert.ToInt32(
                    fila.Cells["VentaId"].Value);

                bool anulada = Convert.ToBoolean(
                    fila.Cells["Anulada"].Value);

                if (anulada)
                {
                    MessageBox.Show("La venta ya se encuentra anulada.");
                    return;
                }

                var respuesta = MessageBox.Show(
                    $"¿Estás seguro de anular la venta N.º {ventaId}?\n" +
                    "Se restaurará el stock de los libros físicos.",
                    "Confirmar anulación",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                if (respuesta != DialogResult.Yes)
                    return;

                _ventaServicio.AnularVenta(ventaId);

                MessageBox.Show(
                    "Venta anulada correctamente.",
                    "Ventas",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                CargarVentas();
                dgvDetalles.DataSource = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Error al anular venta",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void btnActualizar_Click(object? sender, EventArgs e)
        {
            CargarVentas();

            dgvDetalles.DataSource = null;
            dgvVentas.ClearSelection();
        }


    }
}

