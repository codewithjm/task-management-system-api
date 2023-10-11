using Business.Services.Mapper.map;

namespace Business.Services.Mapper;

public interface IEntityMapper
{
    TaskMapper _taskMapper { get; }
}