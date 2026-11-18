using System.Linq.Expressions;

namespace ClinicManagementSystem.Repositories.IRepositories
{
    public interface IRepository<T> where T : class
    {
        
        Task<IEnumerable<T>> GetAllAsync(
            Expression<Func<T, bool>>? expression = null,
            Expression<Func<T, object>>[]? includes = null,
            bool tracked = true,
            bool ignoreFilters = false);

        Task<T?> GetOneAsync(
            Expression<Func<T, bool>>? expression = null,
            Expression<Func<T, object>>[]? includes = null,
            bool tracked = true,
            bool ignoreFilters = false);

        Task AddAsync(T entity, CancellationToken cancellationToken = default);
        void Update(T entity);
        void Delete(T entity);
        Task CommitAsync(CancellationToken cancellationToken = default);


    }
}
