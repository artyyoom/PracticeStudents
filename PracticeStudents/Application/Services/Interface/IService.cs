using Microsoft.AspNetCore.Mvc;

public interface IService<T, D>
{
    Task<T> Create(D dto);
    Task<List<T>> GetAll();
    Task<T> Get(int id, T entity);
    Task<T> Update(int id, T entity);
    Task<T> Delete(int id, T entity);

}