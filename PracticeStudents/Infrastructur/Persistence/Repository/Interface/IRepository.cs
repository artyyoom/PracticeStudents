public interface IRepository<T>
{
    Task<T> AddAsync(T entity);
    Task<IEnumerable<T>> GetAllAsync();
    Task<T?> GetByIdAsync(int id);
    Task UpdateAsync(T entity);
    Task DeleteByIdAsync(int id);    
}
