using API.Extensions;
using Business.Features.TaskFeature.Query;
using Business.Features.Users.Query;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Utilities.Commons.Consts;

namespace API.Endpoints;

public static class UserEndpoints
{
    public static WebApplication MapUserEndpoints(this WebApplication app)
    {
        const string route = ApiRouteConst.API_PATH;
        
        
        _ = app.MapGet(route + "User", [AllowAnonymous] async (IMediator mediator) =>
        {
            return Results.Ok(await mediator.Send(new UserQuery()));
        }).AddSummary<int>(SwaggerTagsConst.USER, "Get User list", "\n GET /User");
        
        
        return app;
    }
}