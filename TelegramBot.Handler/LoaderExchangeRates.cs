using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text.Json;
using TelegramBot.Handler.Interfaces;

namespace TelegramBot.Handler
{
    public class LoaderExchangeRates : IApiRequest
    {
        private const string _url = "https://api.privatbank.ua/p24api/";
        private HttpClient _httpClient = new HttpClient();

        public LoaderExchangeRates()
        {
            _httpClient.BaseAddress = new Uri(_url);
        }

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
