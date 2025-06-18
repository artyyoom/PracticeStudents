public interface IService<T>
{
    Task<TResDto> Create<TDto, TResDto>(TDto dto);
    Task<IEnumerable<T>> GetAll();
    Task<T?> Get(int id);
    Task<TResDto> Update<TReqDto, TResDto>(TReqDto dto);
    Task Delete(int id);
}