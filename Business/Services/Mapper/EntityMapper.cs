using Business.Services.Mapper.map;

namespace Business.Services.Mapper;

public class EntityMapper : IEntityMapper
{
    public TaskMapper _taskMapper => new TaskMapper();
}