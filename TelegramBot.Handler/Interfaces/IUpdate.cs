using Telegram.Bot;
using Telegram.Bot.Types;

namespace TelegramBot.Handler.Interfaces
{
    internal interface IUpdate
    {
        public Task UpdateAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken);
    }
}
