using System.Linq.Expressions;
using PracticeStudents.Domain.Entities;

public interface IRepository<T>
{
    Task<T> AddAsync(T entity);
    Task<IEnumerable<T>> GetAllAsync();
    Task<T?> GetByIdAsync(int id);
    Task<T?> GetByFuncAsync(Expression<Func<T, bool>> predicate);
    Task<IEnumerable<T>> GetListByFuncAsync(Expression<Func<T, bool>> predicate);
    Task UpdateAsync(T entity);
    Task DeleteByIdAsync(int id);
    Task<bool> ExistsAsync(Expression<Func<T, bool>> predicate);
    Task AddRangeAsync(List<T> entities);
}
