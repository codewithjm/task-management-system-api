using Domain.Dto.Task;
using Domain.Entities.TMS;

namespace Business.Services.Mapper.map;

public class TaskMapper : IMapperBase<TaskEntity, TaskBaseDto>
{
    public TaskBaseDto Map(TaskEntity source)
    {
        return new TaskBaseDto
        {
            ident = source.ID,
            task_title = source.TITLE,
            body = source.BODY_PATH,
            created_utc_date = source.CREATED_UTC_DATE,
            updated_utc_date = source.UPDATED_UTC_DATE,
            task_status = source.STATUS,
            task_level = source.LEVEL,
            due_date = source.DUE_UTC_DATE,
            requestor_ident = source.REQUESTOR
        };
    }

    public TaskEntity Reverse(TaskBaseDto destination)
    {
        return new TaskEntity
        {
            ID = destination.ident,
            TITLE = destination.task_title,
            BODY_PATH = destination.body,
            CREATED_UTC_DATE = destination.created_utc_date,
            UPDATED_UTC_DATE = destination.updated_utc_date,
            STATUS = destination.task_status,
            LEVEL = destination.task_level,
            DUE_UTC_DATE = destination.due_date,
            REQUESTOR = destination.requestor_ident
        };
    }
}