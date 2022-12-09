using System.Globalization;
using System.Text.RegularExpressions;
using Telegram.Bot;
using Telegram.Bot.Types;
using TelegramBot.Handler;
using TelegramBot.Handler.Interfaces;
using TelegramBot.Interfaces;
using TelegramBotApp.Resources;

namespace TelegramBot
{
    public class CurrencyDataHandler : IUpdate
    {
        private const string _pattern = @"^[a-zA-Z]{3} \d{1,2}.\d{1,2}.\d{4}$";
        private const string _token = "5729784390:AAEWnWtuXzRrQfMy0Q9q65smUIdiwoND5lc";
        public ITelegramBotClient Bot = new TelegramBotClient(_token);
        private IApiRequest _loaderExchangeRates = new RecipientPrivatBankData();
        private BankCurrencyRates _currencyRates;

        public async Task UpdateAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
        {
            if (update.Type != Telegram.Bot.Types.Enums.UpdateType.Message)
            {
                return;
            }
            string message = Messages.Instruction;
            if (update.Message.Text != Messages.Start)
            {
                message = await SearchEnterCurrencyData(update.Message.Text, _loaderExchangeRates);
            }
            await botClient.SendTextMessageAsync(update.Message.Chat, message);
        }

        public async Task<string> SearchEnterCurrencyData(string userMessage, IApiRequest loaderExchangeRates)
        {
            DateTime date;
            var cultureTime = new CultureInfo("en-Us");
            var formats = new[] { "M-d-yyyy", "dd-MM-yyyy", "MM-dd-yyyy", "M.d.yyyy", "dd.MM.yyyy", "MM.dd.yyyy" }
                            .Union(cultureTime.DateTimeFormat.GetAllDateTimePatterns()).ToArray();
            string message = Messages.BadRequest;
            const char spaceCharacter = ' ';
            if (Regex.IsMatch(userMessage, _pattern))
            {
                var words = userMessage.Split(spaceCharacter);
                if (DateTime.TryParseExact(words[1], formats, cultureTime, DateTimeStyles.AssumeLocal, out date))
                {
                    _currencyRates = await loaderExchangeRates.ApiRequest(date);
                    message = Messages.CurrencyNotSupported;
                    var newCurrency = _currencyRates.ExchangeRate.FirstOrDefault(x => x.Currency.ToString() == words[0].ToString().ToUpper());
                    if (newCurrency != null)
                    {
                        message = $"{_currencyRates.Currency.ToString()} : {newCurrency.Currency.ToString()} - {Messages.SaleRate} " +
                                 $"{newCurrency.SaleRate}, {Messages.PurchaseRate} {newCurrency.PurchaseRate}";
                    }
                }
            }
            return message;
        }
    }
}
