using Microsoft.Extensions.Logging;
using Telegram.Bot;

namespace TelegramBot.Handler
{
    public class ErrorHandler
    {
        private readonly ILogger _logger;

        public async Task ErrorAsync(ITelegramBotClient botClient, Exception exception, CancellationToken cancellationToken)
        {
            using (StreamWriter writer = new StreamWriter($"log_{DateTime.Now.ToString("yyyy-MM-dd_HH_mm")}.log", true))
            {
                writer.WriteLine($"{DateTime.Now.ToString("yyyy-MM-dd_HH_mm")}-{Newtonsoft.Json.JsonConvert.SerializeObject(exception)}");
            }
        }
    }
}
