using AutoMapper;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TelegramBot.Handler.AutoMapperProfiles;
using TelegramBot.Handler.Enums;

namespace TelegramBot.Handler
{
    public class RecipientPrivatBankData : BaseRecipientOfBankData
    {
        private const string _prefixToRequest = "exchange_rates?json&date=";
        private const string BankName = "PrivatBank";
        private readonly string _url = "https://api.privatbank.ua/p24api/";

        public RecipientPrivatBankData()
        {
            _httpClient.BaseAddress = new Uri(_url);
        }

        public override async Task<BankCurrencyRates> ApiRequest(DateTime dateTime)
        {
            BankCurrencyRates currencyRates = new BankCurrencyRates()
            {
                ArchiveDate = dateTime.ToString("dd.MM.yyyy"),
                Currency = CurrencyCodes.UAH,
                Bank = BankName
            };
            HttpResponseMessage response = _httpClient.GetAsync(GetUrl(dateTime)).Result;
            if (response.IsSuccessStatusCode)
            {
                string json = await response.Content.ReadAsStringAsync();
                currencyRates.ExchangeRate = ConvertCurrencyRateBankDataToInternalFormat(json).ExchangeRate
                    .Where(x=>x.Currency != 0).ToList();
            }
            return currencyRates;
        }

        private string GetUrl(DateTime dateTime)
        {
            return _prefixToRequest + dateTime.ToString("dd.MM.yyyy");
        }

        private BankCurrencyRates ConvertCurrencyRateBankDataToInternalFormat(string json)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<JObject, BankCurrencyRates>();
                cfg.AddProfile<BankCurrencyRatesProfile>();
            });
            var mapper = config.CreateMapper();
            var jsonObject = JObject.Parse(json);
            return mapper.Map<BankCurrencyRates>(jsonObject);
        }
    }
}
