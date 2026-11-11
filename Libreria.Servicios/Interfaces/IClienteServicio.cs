
using Libreria.Entidades.Clientes;

namespace Libreria.Servicios.Interfaces
{
    public interface IClienteServicio
    {
        List<Cliente> ObtenerTodos();

        Cliente? ObtenerPorId(int clienteId);

        void Agregar(Cliente cliente);

        void Editar(Cliente cliente);

        void Eliminar(int clienteId);
    }
}
