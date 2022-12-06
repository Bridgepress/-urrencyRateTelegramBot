using TelegramBot.Handler.Resources;

namespace TelegramBot.Handler.Errors
{
    public static class ErrorsMessenger
    {
        public static async Task<string> CurrencyNotSupported()
        {
            return Messages.CurrencyNotSupported;
        }

        public static async Task<string> BadRequest()
        {
            return Messages.BadRequest;
        }
    }
}
