using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot.Types;
using Telegram.Bot;

namespace TelegramBot.Handler.Interfaces
{
    internal interface IUpdate
    {
        public Task UpdateAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken);
    }
}
