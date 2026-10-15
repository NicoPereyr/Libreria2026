
using Libreria.Datos.DbContext;
using Libreria.Datos.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Libreria.Datos.Repositorios
{
    public class Repositorio<T> : IRepositorio<T> where T : class
    {
        protected readonly LibreriaDbContext _context;
        protected readonly DbSet<T> _dbSet;

        public Repositorio(LibreriaDbContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }

        public List<T> ObtenerTodos()
        {
            return _dbSet.ToList();
        }

        public T? ObtenerPorId(int id)
        {
            return _dbSet.Find(id);
        }

        public void Agregar(T entidad)
        {
            _dbSet.Add(entidad);
        }

        public void Editar(T entidad)
        {
            _dbSet.Update(entidad);
        }

        public void Eliminar(T entidad)
        {
            _dbSet.Remove(entidad);
        }

        public void Guardar()
        {
            _context.SaveChanges();
        }
    }
}

