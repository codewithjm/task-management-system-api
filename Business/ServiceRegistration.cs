using System.Reflection;
using Business.Behaviors;
using Business.Services.Mapper;
using Business.Services.TaskServices;
using Business.Services.TaskServices.Interface;
using Business.Services.User;
using Business.Services.User.Interface;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Serilog;

namespace Business;

public static class ServiceRegistration
{

    public static void AddBusiness(this IServiceCollection services)
    {
        services.AddMediatR(Assembly.GetExecutingAssembly());
        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(PerformanceLoggingBehavior<,>));

        services.AddTransient<IUserService, UserService>();
        services.AddTransient<ITaskCreateService, TaskCreateService>();
        services.AddTransient<ITaskModifyService, TaskModifyService>();
        services.AddTransient<IEntityMapper, EntityMapper>();
        
        services.AddSingleton(Log.Logger);
    }
}