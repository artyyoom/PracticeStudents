using System.Linq.Expressions;

public interface IService<T>
{
    Task<TResDto> Create<TDto, TResDto>(TDto dto);
    Task<IEnumerable<TResDto>> GetAll<TResDto>();
    Task<TResDto> Get<TResDto>(int id);
    Task Update<TReqDto>(int id, TReqDto dto);
    Task Delete(int id);
    
}