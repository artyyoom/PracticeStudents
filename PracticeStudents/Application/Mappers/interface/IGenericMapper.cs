public interface IGenericMapper
{
    TDestination Map<TSource, TDestination>(TSource source);
}