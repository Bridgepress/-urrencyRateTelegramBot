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
        public static async Task<string> IsNullCurrency()
        {
            return Messages.CurrencyNotSupported;
        }

        public static async Task<string> InvalidInput()
        {
            return Messages.InvalidInput;
        }
    }
}
