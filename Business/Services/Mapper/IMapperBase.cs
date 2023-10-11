namespace Business.Services.Mapper;

public interface IMapperBase<TSource, TDestination>
{
    TDestination Map(TSource source);
    TSource Reverse(TDestination destination);
}