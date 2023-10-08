using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Utilities.Helpers.Interface;
using Utilities.Utilities;
using Utilities.Utilities.Interfaces;
using Utilities.Wrappers;
using Utilities.Wrappers.Interfaces;

namespace Utilities;

public static class ServiceRegistration
{
    public static void AddUtilities(this IServiceCollection services, IConfiguration configuration)
    {
        #region Helpers

        services.AddTransient<IFileHelper, FileHelper>();

        #endregion

        #region Utilities

        services.AddSingleton<IDateTimeUtil, DateTimeUtil>();
        services.AddSingleton<ILoggerUtil, LoggerUtil>();

        #endregion

        #region Wrappers
 
        services.AddTransient<IPathWrapper, PathWrapper>();
        services.AddTransient<IFileWrapper, FileWrapper>();

        #endregion
    }
}