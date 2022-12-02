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
