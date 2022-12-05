using Newtonsoft.Json;
using TelegramBot.Handler.Interfaces;

namespace TelegramBot.Handler
{
    public abstract class BaseRecipientOfBankData : IApiRequest
    {
        protected HttpClient _httpClient = new HttpClient();

        public async Task<BankCurrencyRates?> ApiRequest(DateTime dateTime)
        {
            HttpResponseMessage response = _httpClient.GetAsync($"exchange_rates?json&date={dateTime.ToString("dd.MM.yyyy")}").Result;
            if (response.IsSuccessStatusCode)
            {
                string json = await response.Content.ReadAsStringAsync();
                BankCurrencyRates? currencyRates = JsonConvert.DeserializeObject<BankCurrencyRates>(json);
                return currencyRates;
            }
            return null;
        }
    }
}
