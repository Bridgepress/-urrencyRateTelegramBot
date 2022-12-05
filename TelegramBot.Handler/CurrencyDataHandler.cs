using System.Text.RegularExpressions;
using Telegram.Bot;
using Telegram.Bot.Types;
using TelegramBot.Handler.Errors;
using TelegramBot.Handler.Interfaces;
using TelegramBot.Handler.Resources;

namespace TelegramBot.Handler
{
    public class CurrencyDataHandler : BaseBotDataHandler
    {
        private IApiRequest _loaderExchangeRates = new RecipientPrivatBankData();
        private BankCurrencyRates _currencyRates;
        private const string _pattern = @"^[a-zA-Z]{3} \d{1,2}.\d{1,2}.\d{4}$";

        public override async Task UpdateAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
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
            string message = string.Empty;
            const char spaceCharacter = ' ';
            if (Regex.IsMatch(userMessage, _pattern))
            {
                var words = userMessage.Split(spaceCharacter);
                if (DateTime.TryParse(words[1], out date))
                {
                    _currencyRates = await loaderExchangeRates.ApiRequest(date);
                    var newCurrency = _currencyRates.ExchangeRate.FirstOrDefault(x => x.Currency.ToLower() == words[0].ToLower());
                    if (newCurrency != null)
                    {
                        message = $"{newCurrency.BaseCurrency} : {newCurrency.Currency} - {Messages.SaleRate} " +
                                 $"{newCurrency.SaleRate}, {Messages.PurchaseRate} {newCurrency.PurchaseRate}";
                    }
                    else
                    {
                        message = await ErrorCurrencyBot.CurrencyNotSupported();
                    }
                }
            }
            else
            {
                message = await ErrorCurrencyBot.InvalidInput();
            }
            return message;
        }
    }
}
