namespace MovieAPI.Services.Interfaces;

public interface IRepository<T>
{
    /// <summary>
    ///     Get an entity by Id from the database.
    /// </summary>
    /// <param name="id">The Id of the entity you want to get.</param>
    /// <returns>The entity object.</returns>
    Task<T?> GetByIdAsync(int id);

    /// <summary>
    ///     Get all entities from the database.
    /// </summary>
    /// <returns>An array of entity objects.</returns>
    Task<ICollection<T>> GetAllAsync();

    /// <summary>
    ///     Check if an entity exists by Id.
    /// </summary>
    /// <param name="id">The Id of the entity you want to check exists.</param>
    /// <returns>True if the entity exists.</returns>
    Task<bool> ExistsWithIdAsync(int id);

    /// <summary>
    ///     Add a new entity to the database.
    /// </summary>
    /// <param name="entity">The new entity to add.</param>
    /// <returns>The Id of the newly added entity.</returns>
    Task<int> AddAsync(T entity);

    /// <summary>
    ///     Update an entity in the database.
    /// </summary>
    /// <param name="entity">The updated entity object.</param>
    Task UpdateAsync(T entity);

    /// <summary>
    ///     Delete an entity from the database.
    /// </summary>
    /// <param name="entity">The entity you want to delete.</param>
    Task DeleteAsync(T entity);
}