
using Libreria.Datos.Interfaces;
using Libreria.DTOs.Ventas;
using Libreria.Entidades.Clientes;
using Libreria.Entidades.Libros;
using Libreria.Servicios.Interfaces;
using Libreria.Windows.Modelos;
using Microsoft.Extensions.DependencyInjection;
using System.ComponentModel;

namespace Libreria.Windows
{
    public partial class frmVentas : Form
    {
        private readonly IVentaServicio _ventaServicio;
        private readonly IClienteServicio _clienteServicio;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IServiceProvider _serviceProvider;
        private readonly BindingList<DetalleCarrito> _carrito = new();


        public frmVentas(
            IVentaServicio ventaServicio,
            IClienteServicio clienteServicio,
            IUnitOfWork unitOfWork,
            IServiceProvider serviceProvider)
        {
            InitializeComponent();

            _ventaServicio = ventaServicio;
            _clienteServicio = clienteServicio;
            _unitOfWork = unitOfWork;
            _serviceProvider = serviceProvider;

            this.Load += frmVentas_Load;
            btnAgregarLibro.Click += btnAgregarLibro_Click;
            btnQuitarLibro.Click += btnQuitarLibro_Click;
            btnRegistrarVenta.Click += btnRegistrarVenta_Click;
            btnNuevaVenta.Click += btnNuevaVenta_Click;
            btnHistorialVentas.Click += btnHistorialVentas_Click;
        }




        private void frmVentas_Load(object? sender, EventArgs e)
        {
            CargarClientes();
            CargarLibros();

            dgvDetalleVenta.AutoGenerateColumns = true;
            dgvDetalleVenta.DataSource = _carrito;
            dgvDetalleVenta.ClearSelection();

            // Ocultar el ID del libro
            var columnaId = dgvDetalleVenta.Columns["LibroId"];

            if (columnaId != null)
            {
                columnaId.Visible = false;
            }

            // Formato de precio unitario
            var columnaPrecio = dgvDetalleVenta.Columns["PrecioUnitario"];

            if (columnaPrecio != null)
            {
                columnaPrecio.DefaultCellStyle.Format = "C2";
            }

            // Formato de subtotal
            var columnaSubtotal = dgvDetalleVenta.Columns["Subtotal"];

            if (columnaSubtotal != null)
            {
                columnaSubtotal.DefaultCellStyle.Format = "C2";
            }

            lblTotal.Text = "Total: $0,00";
        }



        private void CargarClientes()
        {
            try
            {
                var clientes = _clienteServicio.ObtenerTodos()
                    .Where(c => c.Activo)
                    .Select(c => new
                    {
                        c.ClienteId,
                        NombreCompleto = $"{c.Nombre} {c.Apellido}"
                    })
                    .ToList();

                cboClientes.DataSource = clientes;
                cboClientes.DisplayMember = "NombreCompleto";
                cboClientes.ValueMember = "ClienteId";
                cboClientes.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Error al cargar clientes",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void CargarLibros()
        {
            try
            {
                var libros = _unitOfWork.Libros.ObtenerTodos()
                    .Where(l => l.Activo &&
                        (l is LibroDigital ||
                         (l is LibroFisico fisico && fisico.Stock > 0)))
                    .Select(l => new
                    {
                        l.LibroId,
                        Descripcion = $"{l.Titulo} - ${l.Precio:N2}"
                    })
                    .ToList();

                cboLibros.DataSource = libros;
                cboLibros.DisplayMember = "Descripcion";
                cboLibros.ValueMember = "LibroId";
                cboLibros.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Error al cargar libros",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void btnAgregarLibro_Click(object? sender, EventArgs e)
        {
            try
            {
                if (cboLibros.SelectedValue is not int libroId)
                {
                    MessageBox.Show("Seleccioná un libro.");
                    return;
                }

                int cantidad = (int)nudCantidad.Value;

                var libro = _unitOfWork.Libros.ObtenerPorId(libroId);

                if (libro == null || !libro.Activo)
                {
                    MessageBox.Show("El libro no está disponible.");
                    return;
                }

                // Buscar si el libro ya está en el carrito
                var detalleExistente = _carrito
                    .FirstOrDefault(d => d.LibroId == libroId);

                int cantidadActual = detalleExistente?.Cantidad ?? 0;
                int cantidadTotal = cantidadActual + cantidad;

                // Verificar stock únicamente para libros físicos
                if (libro is LibroFisico fisico &&
                    cantidadTotal > fisico.Stock)
                {
                    MessageBox.Show(
                        $"Stock insuficiente. Disponible: {fisico.Stock}");
                    return;
                }

                if (detalleExistente != null)
                {
                    detalleExistente.Cantidad = cantidadTotal;

                    // Actualizar visualmente la grilla
                    _carrito.ResetBindings();
                }
                else
                {
                    _carrito.Add(new DetalleCarrito
                    {
                        LibroId = libro.LibroId,
                        Titulo = libro.Titulo,
                        Cantidad = cantidad,
                        PrecioUnitario = libro.Precio
                    });
                }

                ActualizarTotal();

                cboLibros.SelectedIndex = -1;
                nudCantidad.Value = 1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Error al agregar libro",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void ActualizarTotal()
        {
            decimal total = _carrito.Sum(d => d.Subtotal);

            lblTotal.Text = $"Total: {total:C2}";
        }

        private void btnQuitarLibro_Click(object? sender, EventArgs e)
        {
            try
            {
                if (dgvDetalleVenta.SelectedRows.Count == 0)
                {
                    MessageBox.Show(
                        "Seleccioná un libro del carrito para quitar.");
                    return;
                }

                var detalleSeleccionado =
                    dgvDetalleVenta.SelectedRows[0].DataBoundItem
                    as DetalleCarrito;

                if (detalleSeleccionado == null)
                {
                    MessageBox.Show(
                        "No se pudo obtener el libro seleccionado.");
                    return;
                }

                _carrito.Remove(detalleSeleccionado);

                ActualizarTotal();

                dgvDetalleVenta.ClearSelection();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Error al quitar libro",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void btnRegistrarVenta_Click(object? sender, EventArgs e)
        {
            try
            {
                // Validar cliente seleccionado
                if (cboClientes.SelectedValue is not int clienteId)
                {
                    MessageBox.Show(
                        "Seleccioná un cliente para registrar la venta.");
                    return;
                }

                // Validar que el carrito no esté vacío
                if (_carrito.Count == 0)
                {
                    MessageBox.Show(
                        "Agregá al menos un libro a la venta.");
                    return;
                }

                // Preparar los datos para el servicio
                var ventaDto = new VentaCreateDto
                {
                    ClienteId = clienteId,

                    Detalles = _carrito.Select(d => new DetalleVentaDto
                    {
                        LibroId = d.LibroId,
                        Cantidad = d.Cantidad
                    }).ToList()
                };

                var respuesta = MessageBox.Show(
                    $"¿Confirmás la venta por {_carrito.Sum(d => d.Subtotal):C2}?",
                    "Confirmar venta",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (respuesta != DialogResult.Yes)
                    return;

                // Guardar venta, detalles y stock en SQL Server
                int ventaId = _ventaServicio.RegistrarVenta(ventaDto);

                MessageBox.Show(
                    $"Venta N.º {ventaId} registrada correctamente.",
                    "Ventas",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                // Limpiar carrito y actualizar los libros disponibles
                _carrito.Clear();
                ActualizarTotal();

                cboClientes.SelectedIndex = -1;
                cboLibros.SelectedIndex = -1;
                nudCantidad.Value = 1;

                CargarLibros();
                dgvDetalleVenta.ClearSelection();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Error al registrar venta",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void btnNuevaVenta_Click(object? sender, EventArgs e)
        {
            _carrito.Clear();

            cboClientes.SelectedIndex = -1;
            cboLibros.SelectedIndex = -1;

            nudCantidad.Value = 1;

            ActualizarTotal();

            CargarClientes();
            CargarLibros();

            dgvDetalleVenta.ClearSelection();

            cboClientes.Focus();
        }

        private void btnHistorialVentas_Click(object? sender, EventArgs e)
        {
            using var scope = _serviceProvider.CreateScope();

            using var formulario = scope.ServiceProvider
                .GetRequiredService<frmListadoVentas>();

            formulario.ShowDialog(this);
        }


    }
}
