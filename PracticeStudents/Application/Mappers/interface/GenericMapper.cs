using AutoMapper;

public class GenericMapper : IGenericMapper
{
    private readonly IMapper _mapper;

    public GenericMapper(IMapper mapper)
    {
        _mapper = mapper;
    }
    public TDestination Map<TSource, TDestination>(TSource source)
    {
        return _mapper.Map<TDestination>(source);
    }
}