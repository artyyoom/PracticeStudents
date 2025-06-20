using System.Linq.Expressions;

public abstract class AbstractService<T> : IService<T> where T : class, IEntity
{

    protected readonly IRepository<T> _repository;
    protected readonly IGenericMapper _mapper;

    public AbstractService(IRepository<T> repository, IGenericMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<TResDto> Create<TReqDto, TResDto>(TReqDto dto)
    {
        var entity = _mapper.Map<TReqDto, T>(dto);
        var result = await _repository.AddAsync(entity);

        return _mapper.Map<T, TResDto>(result);
    }

    public virtual Task Delete(int id)
    {
        return _repository.DeleteByIdAsync(id);
    }

    public async Task<TResDto> Get<TResDto>(int id)
    {
        var entity = await _repository.GetByIdAsync(id);

        if (entity == null)
            throw new KeyNotFoundException($"Entity with id {id} not found.");

        return _mapper.Map<T, TResDto>(entity);
        }

    public async Task<IEnumerable<TResDto>> GetAll<TResDto>()
    {
        var entities = await _repository.GetAllAsync();
        var dtos = _mapper.Map<IEnumerable<T>, IEnumerable<TResDto>>(entities);
        return dtos;
    }

    public async Task Update<TReqDto>(int id, TReqDto dto)
    {

        var existingEntity = await _repository.GetByIdAsync(id);

        if (existingEntity == null)
        {
            throw new KeyNotFoundException($"Entity with id {id} not found.");
        }

        _mapper.Map(dto, existingEntity);

        await _repository.UpdateAsync(existingEntity);

    }
}