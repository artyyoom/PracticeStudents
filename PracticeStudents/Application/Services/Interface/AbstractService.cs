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