
public abstract class AbstractService<T> : IService<T> where T : class, IEntity
{

    protected readonly IRepository<T> _repository;

    public AbstractService(IRepository<T> repository)
    {
        _repository = repository;
    }

    public Task<T> Create(T entity)
    {
        return _repository.AddAsync(entity);
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