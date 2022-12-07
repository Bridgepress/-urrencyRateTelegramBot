using Newtonsoft.Json;
using TelegramBot.Handler.Enums;
using TelegramBot.Handler.Interfaces;

namespace TelegramBot.Handler
{
    public abstract class BaseRecipientOfBankData : IApiRequest
    {
        protected HttpClient _httpClient = new HttpClient();

        public abstract Task<BankCurrencyRates> ApiRequest(DateTime dateTime);
    }
}
