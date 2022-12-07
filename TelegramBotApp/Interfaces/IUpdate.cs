using Telegram.Bot;
using Telegram.Bot.Types;

namespace TelegramBot.Interfaces
{
    public interface IUpdate
    {
        public Task UpdateAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken);
    }
}
