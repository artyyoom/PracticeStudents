public interface IRepository<T>
{
    Task<T> AddAsync(T entity);
    Task<T?> GetByIdAsync(int id);
    Task<int> DeleteByIdAsync(int id);
    Task UpdateAsync(T entity);
    Task<IEnumerable<T>> GetAllAsync();
}
