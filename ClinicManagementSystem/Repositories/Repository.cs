using ClinicManagementSystem.Data;
using ClinicManagementSystem.Repositories.IRepositories;
using System.Linq.Expressions;

namespace ClinicManagementSystem.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly ApplicationDbContext _context;
        private readonly DbSet<T> _dbSet;

        public Repository(ApplicationDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public async Task<IEnumerable<T>> GetAllAsync(
            Expression<Func<T, bool>>? expression = null,
            Expression<Func<T, object>>[]? includes = null,
            bool tracked = true,
            bool ignoreFilters = false)
        {
            IQueryable<T> query = _dbSet;

            if (ignoreFilters)
                query = query.IgnoreQueryFilters();

            if (!tracked)
                query = query.AsNoTracking();

            if (expression is not null)
                query = query.Where(expression);

            if (includes is not null)
            {
                foreach (var include in includes)
                {
                    query = query.Include(include);
                }
            }

            return await query.ToListAsync();
        }

        public async Task<T?> GetOneAsync(
            Expression<Func<T, bool>>? expression = null,
            Expression<Func<T, object>>[]? includes = null,
            bool tracked = true,
            bool ignoreFilters = false)
        {
            return (await GetAllAsync(expression, includes, tracked, ignoreFilters)).FirstOrDefault();
        }

        public async Task AddAsync(T entity, CancellationToken cancellationToken = default)
        {
            await _dbSet.AddAsync(entity, cancellationToken);
        }

        public void Update(T entity)
        {
            _dbSet.Update(entity);
        }

        public void Delete(T entity)
        {
            _dbSet.Remove(entity);
        }

        public async Task CommitAsync(CancellationToken cancellationToken = default)
        {
            await _context.SaveChangesAsync(cancellationToken);
        }

    }
}
