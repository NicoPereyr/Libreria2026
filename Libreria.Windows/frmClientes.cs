
using Libreria.Servicios.Interfaces;

namespace Libreria.Windows
{
    public partial class frmClientes : Form
    {
        private readonly IClienteServicio _clienteServicio;
        private int? _clienteIdSeleccionado = null;

        public frmClientes(IClienteServicio clienteServicio)
        {
            InitializeComponent();
            _clienteServicio = clienteServicio;
            btnNuevo.Click += btnNuevo_Click;
            btnGuardar.Click += btnGuardar_Click;
            btnEditar.Click += btnEditar_Click;
            btnCancelar.Click += btnCancelar_Click;
            btnEliminar.Click += btnEliminar_Click;

            this.Load += frmClientes_Load;
        }

        private void frmClientes_Load(object? sender, EventArgs e)
        {
            CargarClientes();
        }

        private void CargarClientes()
        {
            try
            {
                var clientes = _clienteServicio.ObtenerTodos();

                dgvClientes.DataSource = null;
                dgvClientes.DataSource = clientes;

                // Ocultar el identificador interno
                if (dgvClientes.Columns["ClienteId"] != null)
                {
                    dgvClientes.Columns["ClienteId"].Visible = false;
                }

                dgvClientes.ClearSelection();
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

        private void btnNuevo_Click(object? sender, EventArgs e)
        {
            LimpiarControles();
            txtNombre.Focus();
        }

        private void btnGuardar_Click(object? sender, EventArgs e)
        {
            try
            {

                if (_clienteIdSeleccionado != null)
                {
                    var clienteEditado = new Libreria.Entidades.Clientes.Cliente
                    {
                        ClienteId = _clienteIdSeleccionado.Value,
                        Nombre = txtNombre.Text,
                        Apellido = txtApellido.Text,
                        Documento = txtDocumento.Text,
                        Email = txtEmail.Text,
                        Telefono = txtTelefono.Text
                    };

                    _clienteServicio.Editar(clienteEditado);

                    MessageBox.Show(
                        "Cliente actualizado correctamente.",
                        "Clientes",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    CargarClientes();
                    LimpiarControles();
                    return;
                }


                var cliente = new Libreria.Entidades.Clientes.Cliente
                {
                    Nombre = txtNombre.Text,
                    Apellido = txtApellido.Text,
                    Documento = txtDocumento.Text,
                    Email = txtEmail.Text,
                    Telefono = txtTelefono.Text,
                    Activo = true
                };

                _clienteServicio.Agregar(cliente);

                MessageBox.Show(
                    "Cliente guardado correctamente.",
                    "Clientes",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                CargarClientes();
                LimpiarControles();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Error al guardar cliente",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void LimpiarControles()
        {
            _clienteIdSeleccionado = null;

            txtNombre.Clear();
            txtApellido.Clear();
            txtDocumento.Clear();
            txtEmail.Clear();
            txtTelefono.Clear();

            dgvClientes.ClearSelection();
        }

        private void btnEditar_Click(object? sender, EventArgs e)
        {
            try
            {
                if (dgvClientes.CurrentRow == null)
                {
                    MessageBox.Show("Seleccioná un cliente para editar.");
                    return;
                }

                var clienteSeleccionado =
                    dgvClientes.CurrentRow.DataBoundItem
                    as Libreria.Entidades.Clientes.Cliente;

                if (clienteSeleccionado == null)
                {
                    MessageBox.Show("No se pudo obtener el cliente seleccionado.");
                    return;
                }

                _clienteIdSeleccionado = clienteSeleccionado.ClienteId;

                txtNombre.Text = clienteSeleccionado.Nombre;
                txtApellido.Text = clienteSeleccionado.Apellido;
                txtDocumento.Text = clienteSeleccionado.Documento;
                txtEmail.Text = clienteSeleccionado.Email;
                txtTelefono.Text = clienteSeleccionado.Telefono;

                txtNombre.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Error al editar cliente",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_Click(object? sender, EventArgs e)
        {
            LimpiarControles();
        }


        private void btnEliminar_Click(object? sender, EventArgs e)
        {
            try
            {
                if (dgvClientes.CurrentRow == null ||
                    dgvClientes.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Seleccioná un cliente para dar de baja.");
                    return;
                }

                var clienteSeleccionado =
                    dgvClientes.CurrentRow.DataBoundItem
                    as Libreria.Entidades.Clientes.Cliente;

                if (clienteSeleccionado == null)
                {
                    MessageBox.Show("No se pudo obtener el cliente seleccionado.");
                    return;
                }

                if (!clienteSeleccionado.Activo)
                {
                    MessageBox.Show("El cliente ya se encuentra inactivo.");
                    return;
                }

                var respuesta = MessageBox.Show(
                    $"¿Deseás dar de baja a {clienteSeleccionado.Nombre} {clienteSeleccionado.Apellido}?",
                    "Confirmar baja",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (respuesta != DialogResult.Yes)
                    return;

                _clienteServicio.Eliminar(clienteSeleccionado.ClienteId);

                MessageBox.Show(
                    "Cliente dado de baja correctamente.",
                    "Clientes",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                CargarClientes();
                LimpiarControles();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Error al dar de baja",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

    }
}
