using Microsoft.Extensions.Logging;
using Telegram.Bot;

namespace TelegramBot.Handler
{
    public class ErrorHandler
    {
        private readonly ILogger _logger;
        public ErrorHandler()
        {
            using var loggerFactory = LoggerFactory.Create(builder =>
            {
                builder
                    .AddFilter("Microsoft", LogLevel.Warning)
                    .AddFilter("System", LogLevel.Warning)
                    .AddFilter("LoggingConsoleApp.Program", LogLevel.Debug)
                    .AddConsole();
            });
            _logger = loggerFactory.CreateLogger<ErrorHandler>();
        }

        public async Task ErrorAsync(ITelegramBotClient botClient, Exception exception, CancellationToken cancellationToken)
        {
            _logger.LogInformation(Newtonsoft.Json.JsonConvert.SerializeObject(exception));
        }
    }
}
