using Newtonsoft.Json;
using TelegramBot.Handler.Enums;
using TelegramBot.Handler.Interfaces;

namespace TelegramBot.Handler
{
    public abstract class BaseRecipientOfBankData : IApiRequest
    {
        protected HttpClient _httpClient = new HttpClient();
        private const string _prefixToRequest = "exchange_rates?json&date=";

        public async Task<BankCurrencyRates> ApiRequest(DateTime dateTime)
        {
            BankCurrencyRates currencyRates = new BankCurrencyRates();
            HttpResponseMessage response = _httpClient.GetAsync($"{_prefixToRequest}{dateTime.ToString("dd.MM.yyyy")}").Result;
            if (response.IsSuccessStatusCode)
            {
                string json = await response.Content.ReadAsStringAsync();
                currencyRates = JsonConvert.DeserializeObject<BankCurrencyRates>(json);
                currencyRates.ExchangeRate = currencyRates.ExchangeRate.Where(p => Enum.IsDefined(typeof(CurrencyCodes), p.Currency)).ToList();
            }
            return currencyRates;
        }
    }
}
