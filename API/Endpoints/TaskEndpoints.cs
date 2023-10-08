using API.Extensions;
using Business.Features.TaskFeature.Command;
using Business.Features.TaskFeature.Query;
using Domain.Dto.Task.Input;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Utilities.Commons.Consts;

namespace API.Endpoints;

public static class TaskEndpoints
{
    public static WebApplication MapTaskEndpoints(this WebApplication app)
    {
        const string route = ApiRouteConst.API_PATH;

        
        _ = app.MapGet(route + "Task", [AllowAnonymous] async (IMediator mediator) =>
        {
            return Results.Ok(await mediator.Send(new TaskQuery()));
        }).AddSummary<int>(SwaggerTagsConst.TASK, "Get Task list", "\n GET /task");

        
        
        _ = app.MapPost(route + "Task", [AllowAnonymous] async (IMediator mediator, 
            TaskInputDto postData) =>
        {
            
            
            return Results.Ok(await mediator.Send(new CreateTaskCommand
            {
                input = postData
            }));
        }).AddSummary<int>(SwaggerTagsConst.TASK, 
            "Create Task", "\n POST /task");

        
        return app;
    }
}