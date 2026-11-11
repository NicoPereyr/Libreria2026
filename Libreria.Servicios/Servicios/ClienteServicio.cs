
using Libreria.Datos.Interfaces;
using Libreria.Entidades.Clientes;
using Libreria.Servicios.Interfaces;

namespace Libreria.Servicios.Servicios
{
    public class ClienteServicio : IClienteServicio
    {
        private readonly IUnitOfWork _unitOfWork;

        public ClienteServicio(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public List<Cliente> ObtenerTodos()
        {
            return _unitOfWork.Clientes.ObtenerTodos();
        }

        public Cliente? ObtenerPorId(int clienteId)
        {
            return _unitOfWork.Clientes.ObtenerPorId(clienteId);
        }

        public void Agregar(Cliente cliente)
        {
            ValidarCliente(cliente);

            bool documentoExiste = _unitOfWork.Clientes
                .ObtenerTodos()
                .Any(c => c.Documento == cliente.Documento);

            if (documentoExiste)
            {
                throw new Exception(
                    "Ya existe un cliente con ese documento.");
            }

            cliente.Activo = true;

            _unitOfWork.Clientes.Agregar(cliente);
            _unitOfWork.Guardar();
        }

        public void Editar(Cliente cliente)
        {
            ValidarCliente(cliente);

            var clienteExistente = _unitOfWork.Clientes
                .ObtenerPorId(cliente.ClienteId);

            if (clienteExistente == null)
            {
                throw new Exception("El cliente no existe.");
            }

            bool documentoExiste = _unitOfWork.Clientes
                .ObtenerTodos()
                .Any(c =>
                    c.Documento == cliente.Documento &&
                    c.ClienteId != cliente.ClienteId);

            if (documentoExiste)
            {
                throw new Exception(
                    "Ya existe otro cliente con ese documento.");
            }

            clienteExistente.Nombre = cliente.Nombre;
            clienteExistente.Apellido = cliente.Apellido;
            clienteExistente.Documento = cliente.Documento;
            clienteExistente.Email = cliente.Email;
            clienteExistente.Telefono = cliente.Telefono;

            _unitOfWork.Guardar();
        }

        public void Eliminar(int clienteId)
        {
            var cliente = _unitOfWork.Clientes
                .ObtenerPorId(clienteId);

            if (cliente == null)
            {
                throw new Exception("El cliente no existe.");
            }

            // Baja lógica: no se elimina de la base de datos.
            cliente.Activo = false;

            _unitOfWork.Guardar();
        }

        private void ValidarCliente(Cliente cliente)
        {
            if (cliente == null)
            {
                throw new ArgumentNullException(nameof(cliente));
            }

            if (string.IsNullOrWhiteSpace(cliente.Nombre))
            {
                throw new Exception(
                    "Debe ingresar el nombre del cliente.");
            }

            if (cliente.Nombre.Trim().Length > 50)
            {
                throw new Exception(
                    "El nombre no puede superar los 50 caracteres.");
            }

            if (string.IsNullOrWhiteSpace(cliente.Apellido))
            {
                throw new Exception(
                    "Debe ingresar el apellido del cliente.");
            }

            if (cliente.Apellido.Trim().Length > 50)
            {
                throw new Exception(
                    "El apellido no puede superar los 50 caracteres.");
            }

            if (string.IsNullOrWhiteSpace(cliente.Documento))
            {
                throw new Exception(
                    "Debe ingresar el documento del cliente.");
            }

            if (cliente.Documento.Trim().Length > 20)
            {
                throw new Exception(
                    "El documento no puede superar los 20 caracteres.");
            }

            if (cliente.Email?.Length > 100)
            {
                throw new Exception(
                    "El email no puede superar los 100 caracteres.");
            }

            if (cliente.Telefono?.Length > 30)
            {
                throw new Exception(
                    "El teléfono no puede superar los 30 caracteres.");
            }

            cliente.Nombre = cliente.Nombre.Trim();
            cliente.Apellido = cliente.Apellido.Trim();
            cliente.Documento = cliente.Documento.Trim();
            cliente.Email = cliente.Email?.Trim() ?? string.Empty;
            cliente.Telefono = cliente.Telefono?.Trim() ?? string.Empty;
        }
    }
}
