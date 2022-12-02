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
        private IApiRequest _loaderExchangeRates = new LoaderExchangeRates();
        private BankCurrencyRates _currencyRates;

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
            string pattern = @"^[a-zA-Z]{3} \d{1,2}.\d{1,2}.\d{4}$";
            string message = "";
            if (Regex.IsMatch(userMessage, pattern))
            {
                var words = userMessage.Split(' ');
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
                        message = await ErrorCurrencyBot.IsNullCurrency();
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
