
using Libreria.Datos.Interfaces;
using Libreria.DTOs.Ventas;
using Libreria.Entidades.Libros;
using Libreria.Entidades.Ventas;
using Libreria.Servicios.Interfaces;

namespace Libreria.Servicios.Servicios
{
    public class VentaServicio : IVentaServicio
    {
        private readonly IUnitOfWork _unitOfWork;

        public VentaServicio(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public int RegistrarVenta(VentaCreateDto ventaDto)
        {
            if (ventaDto == null)
                throw new Exception("Los datos de la venta son inválidos.");

            // Validar cliente
            var cliente = _unitOfWork.Clientes
                .ObtenerPorId(ventaDto.ClienteId);

            if (cliente == null || !cliente.Activo)
                throw new Exception("El cliente no existe o está inactivo.");

            // Validar detalles
            if (ventaDto.Detalles == null ||
                ventaDto.Detalles.Count == 0)
            {
                throw new Exception(
                    "La venta debe contener al menos un libro.");
            }

            if (ventaDto.Detalles.Any(d => d == null ||
                                            d.LibroId <= 0 ||
                                            d.Cantidad <= 0))
            {
                throw new Exception(
                    "Todos los libros deben tener una cantidad válida.");
            }

            // Agrupar libros repetidos
            var detallesAgrupados = ventaDto.Detalles
                .GroupBy(d => d.LibroId)
                .Select(g => new
                {
                    LibroId = g.Key,
                    Cantidad = g.Sum(d => (long)d.Cantidad)
                })
                .ToList();

            var venta = new Venta
            {
                ClienteId = cliente.ClienteId,
                FechaVenta = DateTime.Now,
                Anulada = false,
                Total = 0
            };

            decimal total = 0;

            foreach (var item in detallesAgrupados)
            {
                if (item.Cantidad > int.MaxValue)
                    throw new Exception("La cantidad supera el máximo permitido.");

                int cantidad = (int)item.Cantidad;

                var libro = _unitOfWork.Libros
                    .ObtenerPorId(item.LibroId);

                if (libro == null || !libro.Activo)
                {
                    throw new Exception(
                        $"El libro con ID {item.LibroId} no existe o está inactivo.");
                }

                if (libro.Precio <= 0)
                {
                    throw new Exception(
                        $"El libro '{libro.Titulo}' tiene un precio inválido.");
                }

                // Validar y descontar stock de libros físicos
                if (libro is LibroFisico libroFisico)
                {
                    if (libroFisico.Stock < cantidad)
                    {
                        throw new Exception(
                            $"Stock insuficiente para '{libro.Titulo}'. " +
                            $"Disponible: {libroFisico.Stock}.");
                    }

                    libroFisico.Stock -= cantidad;
                }

                decimal subtotal = libro.Precio * cantidad;

                venta.Detalles.Add(new DetalleVenta
                {
                    LibroId = libro.LibroId,
                    Cantidad = cantidad,
                    PrecioUnitario = libro.Precio,
                    Subtotal = subtotal
                });

                total += subtotal;
            }

            venta.Total = total;

            // Guardar venta, detalles y cambios de stock juntos
            _unitOfWork.Ventas.Agregar(venta);
            _unitOfWork.Guardar();

            return venta.VentaId;
        }

        public List<Venta> ObtenerTodos()
        {
            return _unitOfWork.Ventas.ObtenerTodos();
        }

        public Venta? ObtenerPorId(int ventaId)
        {
            return _unitOfWork.Ventas.ObtenerPorId(ventaId);
        }

        public void AnularVenta(int ventaId)
        {
            var venta = _unitOfWork.Ventas.ObtenerPorId(ventaId);

            if (venta == null)
                throw new Exception("La venta no existe.");

            if (venta.Anulada)
                throw new Exception("La venta ya está anulada.");

            var detalles = _unitOfWork.DetalleVentas
                .ObtenerTodos()
                .Where(d => d.VentaId == ventaId)
                .ToList();

            if (detalles.Count == 0)
                throw new Exception("La venta no tiene detalles.");

            foreach (var detalle in detalles)
            {
                var libro = _unitOfWork.Libros
                    .ObtenerPorId(detalle.LibroId);

                // Restaurar stock únicamente de libros físicos
                if (libro is LibroFisico libroFisico)
                {
                    libroFisico.Stock += detalle.Cantidad;
                }
            }

            venta.Anulada = true;

            _unitOfWork.Guardar();
        }
    }
}
