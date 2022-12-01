using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot.Types;
using Telegram.Bot;
using TelegramBot.Handler.Resources;

namespace TelegramBot.Handler.Errors
{
    public static class ErrorCurrencyBot
    {
        public static async Task IsNullCurrency(ITelegramBotClient botClient, Update update)
        {
            await botClient.SendTextMessageAsync(update.Message.Chat, Messages.CurrencyNotSupported);
        }

        public static async Task InvalidInput(ITelegramBotClient botClient, Update update)
        {
            await botClient.SendTextMessageAsync(update.Message.Chat, Messages.InvalidInput);
        }
    }
}
