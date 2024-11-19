using EmployeeAPI.Data;
using Microsoft.EntityFrameworkCore;

namespace EmployeeAPI.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly EmployeeContext _context;
        private readonly DbSet<T> _table;
        public Repository(EmployeeContext context)
        {
            _context = context;
            _table = _context.Set<T>();
        }
        public IQueryable<T> GetAll()
        {
            return _table.AsQueryable();
        }

        public T Get(Guid id)
        {
            return _table.Find(id);
        }

        public int Add(T entity)
        {
            _table.Add(entity);
            return _context.SaveChanges();
        }
    }
}
