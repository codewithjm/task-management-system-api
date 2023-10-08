using Serilog;
using Utilities.Utilities.Interfaces;

namespace Utilities.Utilities;

public class LoggerUtil : ILoggerUtil
{
    private readonly ILogger _logger;

    public LoggerUtil(ILogger logger)
    {
        this._logger = logger;
    }

    public void WriteLogError(string message)
    {
        _logger.Error(message);
    }
}