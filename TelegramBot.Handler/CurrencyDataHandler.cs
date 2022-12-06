using System.Text.RegularExpressions;
using Telegram.Bot;
using Telegram.Bot.Types;
using TelegramBot.Handler.Errors;
using TelegramBot.Handler.Interfaces;
using TelegramBot.Handler.Resources;

namespace TelegramBot.Handler
{
    public class CurrencyDataHandler : IUpdate
    {
        public ITelegramBotClient Bot = new TelegramBotClient(_token);
        private IApiRequest _loaderExchangeRates = new RecipientPrivatBankData();
        private BankCurrencyRates _currencyRates;
        private const string _pattern = @"^[a-zA-Z]{3} \d{1,2}.\d{1,2}.\d{4}$";
        private const string _token = "5729784390:AAEWnWtuXzRrQfMy0Q9q65smUIdiwoND5lc";

        public async Task UpdateAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
        {
            if (update.Type == Telegram.Bot.Types.Enums.UpdateType.Message)
            {
                if (update.Message.Text == Messages.Start)
                {
                    await botClient.SendTextMessageAsync(update.Message.Chat, Messages.Instruction);
                }
                else
                {
                    await botClient.SendTextMessageAsync(update.Message.Chat, await SerchEnterCurrencyData(update.Message.Text, _loaderExchangeRates));
                }
            }
        }

        public async Task<string> SerchEnterCurrencyData(string userMessage, IApiRequest loaderExchangeRates)
        {
            DateTime date;
            string message = await ErrorsMessenger.BadRequest();
            const char spaceCharacter = ' ';
            if (Regex.IsMatch(userMessage, _pattern))
            {
                var words = userMessage.Split(spaceCharacter);
                if (DateTime.TryParse(words[1], out date))
                {
                    _currencyRates = await loaderExchangeRates.ApiRequest(date);
                    message = await ErrorsMessenger.CurrencyNotSupported();
                    var newCurrency = _currencyRates.ExchangeRate.FirstOrDefault(x => x.Currency.ToLower() == words[0].ToLower());
                    if (newCurrency != null)
                    {
                        message = $"{newCurrency.BaseCurrency} : {newCurrency.Currency} - {Messages.SaleRate} " +
                                 $"{newCurrency.SaleRate}, {Messages.PurchaseRate} {newCurrency.PurchaseRate}";
                    }
                }
            }
            return message;
        }
    }
}
