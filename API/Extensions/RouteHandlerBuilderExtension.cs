using System.Net.Mime;
using Swashbuckle.AspNetCore.Annotations;
using Utilities.Commons.Exceptions;

namespace API.Extensions;

public static class RouteHandlerBuilderExtension
{
    public static RouteHandlerBuilder AddSummary<TResponse>(this RouteHandlerBuilder builder, string tags = "", string title = "", string description = "")
    {
        _ = builder
            .WithTags(tags)
            .WithMetadata(new SwaggerOperationAttribute(title, description))
            .Produces<TResponse>(StatusCodes.Status200OK, MediaTypeNames.Application.Json)
            .Produces<ApiErrorException>(StatusCodes.Status500InternalServerError, MediaTypeNames.Application.Json);

        return builder;
    }
}