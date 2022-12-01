using System.Text.RegularExpressions;
using Telegram.Bot;
using Telegram.Bot.Types;
using TelegramBot.Handler.Errors;
using TelegramBot.Handler.Resources;

namespace TelegramBot.Handler
{
    public class CurrencyDataHandler : BaseBotDataHandler
    {
        private LoaderExchangeRates _loaderExchangeRates = new LoaderExchangeRates();
        private BankCurrencyRates _currencyRates;

        public override async Task UpdateAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
        {
            string pattern = @"^[a-zA-Z]{3} \d{1,2}.\d{1,2}.\d{4}$";
            if (update.Type == Telegram.Bot.Types.Enums.UpdateType.Message)
            {
                if (update.Message.Text == Messages.Start)
                {
                    await botClient.SendTextMessageAsync(update.Message.Chat, Messages.Instruction);
                }
                if (Regex.IsMatch(update.Message.Text, pattern))
                {
                    var words = update.Message.Text.Split(' ');
                    await SerchEnterCurrencyData(botClient, update, words[1], words[0]);
                }
                else
                {
                    await ErrorCurrencyBot.InvalidInput(botClient, update);
                }
            }
        }

        private async Task SerchEnterCurrencyData(ITelegramBotClient botClient, Update update, string receivedDate, string currency)
        {
            DateTime date;
            if (DateTime.TryParse(receivedDate, out date))
            {
                _currencyRates = await _loaderExchangeRates.ApiRequest(date);
                var newCurrency = _currencyRates.exchangeRate.FirstOrDefault(x => x.Currency.ToLower() == currency.ToLower());
                if (newCurrency != null)
                {
                    await botClient.SendTextMessageAsync(update.Message.Chat, $"{newCurrency.BaseCurrency} : " +
                                $"{newCurrency.Currency} - {Messages.SaleRate} {newCurrency.SaleRate}, {Messages.PurchaseRate} {newCurrency.PurchaseRate}");
                    return;
                }
                else
                {
                    await ErrorCurrencyBot.IsNullCurrency(botClient, update);
                }
            }
        }
    }
}
