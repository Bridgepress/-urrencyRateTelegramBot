using Telegram.Bot;
using Telegram.Bot.Types;
using TelegramBot.Handler.Interfaces;

namespace TelegramBot.Handler
{
    public abstract class BaseBotDataHandler : IUpdate
    {
        private const string _token = "5729784390:AAEWnWtuXzRrQfMy0Q9q65smUIdiwoND5lc";
        public ITelegramBotClient Bot = new TelegramBotClient(_token);

        public abstract Task UpdateAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken);
    }
}
