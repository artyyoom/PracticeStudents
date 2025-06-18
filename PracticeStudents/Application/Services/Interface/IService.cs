using Microsoft.AspNetCore.Mvc;

public interface IService<T>
{
    Task<T> Create(T entity);
    Task<IEnumerable<T>> GetAll();
    Task<T?> Get(int id);
    Task Update(T entity);
    Task Delete(int id);

}