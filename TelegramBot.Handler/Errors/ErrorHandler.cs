using Telegram.Bot;

namespace TelegramBot.Handler
{
    public class ErrorHandler
    {
        public async Task ErrorAsync(ITelegramBotClient botClient, Exception exception, CancellationToken cancellationToken)
        {
            Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(exception));
        }
    }
}
