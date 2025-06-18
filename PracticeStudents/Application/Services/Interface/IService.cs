public interface IService<T>
{
    Task<TResDto> Create<TDto, TResDto>(TDto dto);
    Task<IEnumerable<T>> GetAll();
    Task<T?> Get(int id);
    Task Update(T entity);
    Task Delete(int id);
}