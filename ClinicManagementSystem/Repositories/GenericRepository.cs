using ClinicManagementSystem.Data;
using System.Linq.Expressions;

namespace ClinicManagementSystem.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly ApplicationDbContext _context;
        internal DbSet<T> _dbSet;

        public GenericRepository(ApplicationDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public async Task<IEnumerable<T>> GetAllAsync(
            Expression<Func<T, bool>>? predicate = null,
            bool ignoreFilters = false,
            params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> query = _dbSet;

            if (ignoreFilters)
                query = query.IgnoreQueryFilters();

            if (predicate != null)
                query = query.Where(predicate);

            foreach (var include in includes)
            {
                query = query.Include(include);
            }

            return await query.ToListAsync();
        }

        public async Task<T?> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task<T?> FindAsync(
            Expression<Func<T, bool>> predicate,
            bool ignoreFilters = false,
            params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> query = _dbSet;

            if (ignoreFilters)
                query = query.IgnoreQueryFilters();

            foreach (var include in includes)
            {
                query = query.Include(include);
            }

            return await query.FirstOrDefaultAsync(predicate);
        }

        public async Task AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
        }

        public void Update(T entity)
        {
            _dbSet.Update(entity);
        }

        public void Delete(T entity)
        {
            _dbSet.Remove(entity);
        }
    }
}
