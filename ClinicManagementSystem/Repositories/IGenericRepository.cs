using System.Linq.Expressions;

namespace ClinicManagementSystem.Repositories
{
    public interface IGenericRepository<T> where T : class
    {
        // Retrieves all entities of type T, with optional filtering and eager loading of related entities.
        Task<IEnumerable<T>> GetAllAsync(
            Expression<Func<T, bool>>? predicate = null,
            bool ignoreFilters = false,
            params Expression<Func<T, object>>[] includes);


        // Retrieves a single entity of type T by its primary key, with optional eager loading of related entities.
        Task<T?> GetByIdAsync(int id);


        // Finds a single entity of type T based on a specified predicate, with optional eager loading of related entities.
        Task<T?> FindAsync(
            Expression<Func<T, bool>> predicate,
            bool ignoreFilters = false,
            params Expression<Func<T, object>>[] includes);


        // Adds a new entity of type T to the repository.
        Task AddAsync(T entity);


        // Updates an existing entity of type T in the repository.
        void Update(T entity);


        // Deletes an entity of type T from the repository.
        void Delete(T entity);

    }
}
