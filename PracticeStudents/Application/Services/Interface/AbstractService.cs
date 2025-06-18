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

    public Task Delete(int id)
    {
        return _repository.DeleteByIdAsync(id);
    }

    public Task<T?> Get(int id)
    {
        return _repository.GetByIdAsync(id);
    }

    public Task<IEnumerable<T>> GetAll()
    {
        return _repository.GetAllAsync();
    }

    public Task Update(T entity)
    {
        return _repository.UpdateAsync(entity);
    }
}