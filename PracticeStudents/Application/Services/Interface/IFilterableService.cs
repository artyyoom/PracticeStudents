public interface IFilterableService<T>
{
    Task<IEnumerable<TDto>> GetByFilterAsync<TDto>(string filter);
}