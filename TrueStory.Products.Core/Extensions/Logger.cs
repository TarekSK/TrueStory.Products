using Microsoft.Extensions.Logging;

namespace TrueStory.Products.Core.Extensions
{
    /// <summary>
    /// Logger extensions for the application.
    /// For improved performance, use the <see cref="LoggerMessage"/> class to create log messages.
    /// </summary>
    public static partial class Logger
    {
        public static Action<ILogger, string, object, Exception?> Info => LoggerMessage.Define<string, object>(
            logLevel: LogLevel.Information,
            eventId: 1,
            formatString: "INF: [Message: {Message} Info: {@Info}]");

        public static Action<ILogger, string, object, string, Exception?> Error => LoggerMessage.Define<string, object, string>(
            logLevel: LogLevel.Error,
            eventId: 2,
            formatString: "ERR: [Message: {ErrorMessage} Info: {@Info} TraceId: {TraceId}]");
    }
}
